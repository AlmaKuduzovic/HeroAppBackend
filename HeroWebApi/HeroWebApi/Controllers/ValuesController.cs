using HeroWebApi.EFCore;
using HeroWebApi.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Principal;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HeroWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValuesController : ControllerBase
    {

        private readonly DbHelper _db;

        public ValuesController(EF_DataContext eF_DataContext)
        {

            _db = new DbHelper(eF_DataContext);
        }

        // POST api/<ValuesController>

        [HttpPost("{int}")]
        public int Post([FromBody] Hero hero)
        {
            try
            {
                if (hero == null)
                {
                    throw new ArgumentException(nameof(hero));
                }

                _db.AddHero(hero);

                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");

                // return StatusCode(500, "An error occurred");
            }
            return -1; 
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{int}")]
        public void PutHero(int id, string name)
        {
            try
            {
                _db.ModifyHero(id, name);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");

                // return StatusCode(500, "An error occurred");
            }
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{int}")]
        public void Delete(int id)
        {
            try
            {
                _db.DeleteHero(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Hero> Get()
        {
            try
            {
                IEnumerable<Hero> data = _db.GetHeroes();
                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                // return StatusCode(500, "An error occurred");
            }
            return Enumerable.Empty<Hero>();
        }
    }
}
