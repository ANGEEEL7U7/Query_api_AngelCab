using System.Collections;
using Microsoft.AspNetCore.Mvc;
using QueryApi.Repositories;
using QueryApi.Domain;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        [HttpGet]
        [Route("GetDate")]
        
        public IActionResult GetDate()
        {
           
            var repository = new PersonRepository();
            var persons = repository.GetDate();
            return Ok(persons);
        }
        [HttpGet]
        [Route("GetGenero")]
        
        public IActionResult GetGenero(char gender)
        {
           
            var repository = new PersonRepository();
            var persons = repository.GetGenero(gender);
            return Ok(persons);
        }
        [HttpGet]
        [Route("GetEdades")]
         public IActionResult GetEdades(int minAge, int maxAge)
        {
            var repository = new PersonRepository();
            var persons = repository.GetEdades(minAge, maxAge);
            return Ok(persons);
        }
        [HttpGet]
        [Route("GetarWith")]
        public IActionResult GetarWith(string ar)
        {
            var repository = new PersonRepository();
            var persons = repository.GetarWith(ar);
            return Ok(persons);
        }
        [HttpGet]
        [Route("GetListAge")]
        public IActionResult GetListAge(int ageone, int agetwo, int agethree)
        {
            var repository = new PersonRepository();
            var persons = repository.GetListAge(ageone,agetwo,agethree );
            return Ok(persons);
        }
        [HttpGet]
        [Route("GetOrder")]
        public IActionResult GetOrder(int age)
        {
            var repository = new PersonRepository();
            var persons = repository.GetOrder(age);
            return Ok(persons);
        }
        [HttpGet]
        [Route("GetDesc")]
        public IActionResult GetDesc(int edadmin, int edadmax, char Genero)
        {
            var repository = new PersonRepository();
            var persons = repository.GetDesc(edadmin,edadmax,Genero);
            return Ok(persons);
        }
        [HttpGet]
        [Route("GetFemale")]
        public IActionResult GetFemale(char gender)
        {
            var repository = new PersonRepository();
            var persons = repository.GetFemale(gender);
            return Ok(persons);
        }
        [HttpGet]
        [Route("Exist")]
        public IActionResult Exist(string Shemelt)
        {
            var repository = new PersonRepository();
            var persons = repository.Exist(Shemelt);
            return Ok(persons);
        }
        [HttpGet]
        [Route("GetOneperson")]
        public IActionResult GetOneperson(int edad, string onejob)
        {
            var repository = new PersonRepository();
            var persons = repository.GetOneperson(edad, onejob);
            return Ok(persons);
        }
        [HttpGet]
        [Route("TakePerson")]
        public IActionResult TakePerson(string TakeJob, int list)
        {
            var repository = new PersonRepository();
            var persons = repository.TakePerson(TakeJob, list);
            return Ok(persons);
        }
        [HttpGet]
        [Route("TakLastPerson")]
        public IActionResult TakLastPerson(string TakeJob, int list)
        {
            var repository = new PersonRepository();
            var persons = repository.TakeLastPerson(TakeJob, list);
            return Ok(persons);
        }
        [HttpGet]
        [Route("TakeandLastPerson")]
        public IActionResult TakeandLastPerson(string TakeJob, int list)
        {
            var repository = new PersonRepository();
            var persons = repository.TakeandLastPerson(TakeJob, list);
            return Ok(persons);
        }
       
    }
}