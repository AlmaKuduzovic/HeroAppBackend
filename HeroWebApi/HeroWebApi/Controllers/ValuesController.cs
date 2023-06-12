using HeroWebApi.EFCore;
using HeroWebApi.Model;
using Microsoft.AspNetCore.Mvc;

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


        // GET: api/<ValuesController>
    

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }



        [HttpGet]
 
        public IEnumerable<Hero> Get()
        {
            ResponseType type = ResponseType.Success;

            IEnumerable<Hero> data = _db.GetHeroes();

            return data;

        }
    }
}
