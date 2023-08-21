using Microsoft.EntityFrameworkCore;
using WebApi_Services.Models;

namespace WebApi_Services.ContextoDB
{
    public class WebApiContext : DbContext
    {
        public WebApiContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Pessoa> pessoas { get; set; }

        
    }
}
