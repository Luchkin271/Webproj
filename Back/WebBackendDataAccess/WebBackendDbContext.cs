using Microsoft.EntityFrameworkCore;
namespace WebBackend.DataAccess
{
    public class WebBackendDbContext:DbContext
    {
        public WebBackendDbContext(DbContextOptions<WebBackendDbContext> options) : base(options)
        {
        }

    }
}
