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
            if (hero == null) {
                throw new ArgumentException(nameof(hero));
            }
            _db.AddHero(hero);

            return 0;
        }

        [HttpPost("{action}")]
        public IActionResult Post3([FromBody] Hero hero)
        {
            if (hero == null)
            {
                return BadRequest("null");
            }

            try
            {
                _db.AddHero(hero);

            }catch (Exception b)
            {
                return BadRequest("Error");
            }

            return Ok(hero);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{int}")]
        public void PutHero(int id, string name)
        {
            _db.ModifyHero(id, name);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{int}")]
        public void Delete(int id)
        {

            _db.DeleteHero(id);
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Hero> Get()
        {
            

            IEnumerable<Hero> data = _db.GetHeroes();

            return data;

        }
    }
}
