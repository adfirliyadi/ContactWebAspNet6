using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MyContactManagerData
{
    public class MyContactManagerDbContext : DbContext
    {
        private static IConfigurationRoot _configuration;

        public MyContactManagerDbContext()
        {

        }

        public MyContactManagerDbContext(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsetting.json", optional: true, reloadOnChange: true);
            _configuration = builder.Build();

            var cnstr = _configuration.GetConnectionString("MyContactManager");
            optionsBuilder.UseSqlServer(cnstr);
        }
    }
}