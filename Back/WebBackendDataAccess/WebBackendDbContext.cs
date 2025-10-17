using Microsoft.EntityFrameworkCore;
using WebBackend.DataAccess.Entities;
namespace WebBackend.DataAccess
{
    public class WebBackendDbContext:DbContext
    {
        public WebBackendDbContext(DbContextOptions<WebBackendDbContext> options) : base(options)
        {

        }
        public DbSet<GoodEntity> Goods { get; set; }
        public DbSet<ManufactureEntity> Manufactures { get; set; }
        public DbSet<ReviewEntity> Reviews { get; set; }
        public DbSet<UserEntity> Users { get; set; }
    }
}
