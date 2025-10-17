using System.Linq;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using WebBackend.Core.Models;
using WebBackend.DataAccess.Entities;

namespace WebBackend.DataAccess.Repositories
{
    public class GoodReposytory
    {
        private WebBackendDbContext _context;
        public GoodReposytory(WebBackendDbContext context)
        {
            _context = context;
        }
        public async Task<Good> Get(Guid Id)
        {
            var goodEntities = await _context.Goods
                .AsNoTracking()
                .ToListAsync();
            var goodEntity = goodEntities
                .FirstOrDefault(g => g.Id == Id);
            Good good = Good.Create(goodEntity.Id,
                    goodEntity.Name,
                    goodEntity.Price,
                    goodEntity.Description,
                    goodEntity.IconURL,
                    MapToManufactureDomain(goodEntity.Manufacturer),
                    MapToReviewsDomain(goodEntity.Reviews),
                    DeserializeSpecifications(goodEntity.Specifications)
                    ).Good;

            return good;
        }
        public async Task<List<Good>> GetSome(List<Guid> Ids)
        {
            if (Ids == null || !Ids.Any())
                return new List<Good>();
            var goodEntities = await _context.Goods
                .Where(g => Ids.Contains(g.Id))
                .Include(g => g.Manufacturer)
                .Include(g => g.Reviews)
                .AsNoTracking()
                .ToListAsync();
            var Goods = goodEntities
                .Select(g => Good.Create(g.Id,
                    g.Name,
                    g.Price,
                    g.Description,
                    g.IconURL,
                    MapToManufactureDomain(g.Manufacturer),
                    MapToReviewsDomain(g.Reviews),
                    DeserializeSpecifications(g.Specifications)
                    ).Good)
                .ToList();

            return Goods;
        }
        public async Task<List<Good>> GetAll()
        {
            var goodEntities = await _context.Goods
                .Include(g => g.Manufacturer)
                .Include(g => g.Reviews)
                .AsNoTracking()
                .ToListAsync();
            var Goods = goodEntities
                .Select(g => Good.Create(g.Id,
                    g.Name,
                    g.Price,
                    g.Description,
                    g.IconURL,
                    MapToManufactureDomain(g.Manufacturer),
                    MapToReviewsDomain(g.Reviews),
                    DeserializeSpecifications(g.Specifications)
                    ).Good)
                .ToList();

            return Goods;
        }

        //Mapping and serialising
        private Manufacture MapToManufactureDomain( ManufactureEntity entity)
        {
            if (entity == null) return null;

            var (manufacture, error) = Manufacture.Create(entity.Id,
                entity.Name,
                entity.Description,
                new List<Good>()
                );
            if (!string.IsNullOrEmpty(error))
                return null;
            return manufacture;
        }
        private List<Review> MapToReviewsDomain(List<ReviewEntity> entities)
        {
            if(entities == null) return new List<Review>();

            var reviews = new List<Review>();
            foreach ( var entity in entities)
            {
                var (review, error) = Review.Create(entity.Id, null, null, null);
                if (string.IsNullOrEmpty(error)) reviews.Add(review);
            }
            return reviews;
        }
        private string SerializeSpecifications(List<Specification> specifications)
        {
            if (specifications == null || !specifications.Any())
                return null;

            var specificationsArray = specifications.Select(s => new object[]
            {
                s.Name,
                s.Context
            }).ToArray();

            return JsonSerializer.Serialize(specificationsArray);
        }
        private List<Specification> DeserializeSpecifications(string specificationsJson)
        {
            if (string.IsNullOrEmpty(specificationsJson))
                return new List<Specification>();

            try
            {
                var specificationsArray = JsonSerializer.Deserialize<string[][]>(specificationsJson);

                var specifications = new List<Specification>();
                foreach (var item in specificationsArray)
                {
                    if (item.Length == 2)
                    {
                        var (spec, error) = Specification.Create(item[0], item[1]);
                        if (string.IsNullOrEmpty(error))
                            specifications.Add(spec);
                    }
                }
                return specifications;
            }
            catch
            {
                return new List<Specification>();
            }
        }
    }
}
