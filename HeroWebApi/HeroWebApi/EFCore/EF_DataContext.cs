using Microsoft.EntityFrameworkCore;

namespace HeroWebApi.EFCore
{
    public class EF_DataContext: DbContext
    {

        public EF_DataContext(DbContextOptions<EF_DataContext> options) : base(options) { }
        
        

        public DbSet<Hero> Heroes { get; set; }

    }
}
