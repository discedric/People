using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PeopleManager.Dto.Filters;
using PeopleManager.Dto.Person;
using PeopleManager.Model;
using PeopleManager.Services;
using Vives.Services.Model;

namespace PeopleManager.Api.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class PeopleController(PersonService personService) : ControllerBase
    {
        private readonly PersonService _personService = personService;
        //Find (more) : Get
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Find([FromQuery]Paging paging, [FromQuery]PersonFilter filter, [FromQuery]Sorting sorting)
        {
            var results = await _personService.Find(paging, filter, sorting);
            return Ok(results);
        }

        //get (one) : Get
        [AllowAnonymous]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get([FromRoute]int id)
        {
            var results = await _personService.Get(id);
            return Ok(results);
        }

        //create : Post
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]PersonRequests person)
        {
            var result = await _personService.Create(person);
            return Ok(result);
        }

        //update : Put
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute]int id, [FromBody] PersonRequests person)
        {
            var result = await _personService.Update(id, person);
            return Ok(result);
        }

        //delete : Delete
        [HttpDelete("{id:int}")]
        // testing
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            var result = await _personService.Delete(id);
            return Ok(result);
        }
    }
}
