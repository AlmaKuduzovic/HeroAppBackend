 using HeroWebApi.EFCore;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

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
            return dataList;
         }
        public void AddHero(Hero hero)
        {
            int newId = _context.Heroes.Max(h => h.Id);

            hero.Id = newId + 1;

            _context.Heroes.Add(hero);
            _context.SaveChanges();
        }

        public void ModifyHero(int Id, string Name)
        {
            Hero hero = _context.Heroes.Where(x=>x.Id==Id).FirstOrDefault();

            hero.Name = Name;

            _context.SaveChanges();
        }

        public void DeleteHero(int Id)
        {
           Hero hero = _context.Heroes.Where(x => x.Id == Id).FirstOrDefault();

 
            _context.Heroes.Remove(hero);
            _context.SaveChanges();

        }

        public List<Hero> GetHeroes(string Name)
        {
            List<Hero> dataList = _context.Heroes.Where(h => h.Name == Name).ToList();
            return dataList;
        }


    }
}
