using HeroWebApi.EFCore;

namespace HeroWebApi.Model
{
    public class DbHelper
    {
        private EF_DataContext _context;

        public DbHelper(EF_DataContext context)
        {
            _context = context;
        }

        public List<Hero> GetHeroes() {
          
            List<Hero> dataList = _context.Heroes.ToList();
            //dataList.ForEach(row => response.Add(new Hero() { 
            // Id = row.Id,
            //Name = row.Name
            // }));
            return dataList;
         }
    }
}
