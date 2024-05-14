using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PeopleManager.Dto.Filters;
using PeopleManager.Dto.Organization;
using PeopleManager.Model;
using PeopleManager.Services;
using Vives.Services.Model;

namespace PeopleManager.Api.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class OrganizationController(OrganizationService organizationService) : ControllerBase
    {
        private readonly OrganizationService _organizationService = organizationService;
        //Find (more) : Get
        [HttpGet]
        public async Task<IActionResult> Find([FromQuery]Paging paging, [FromQuery] OrganizationFilter? filter)
        {
            var organizations = await _organizationService.Find(paging, filter);
            return Ok(organizations);
        }
        //get (one) : Get
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var result = await _organizationService.Get(id);
            return Ok(result);
        }
        //create : Post
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] OrganizationRequests organization)
        {
            var result = await _organizationService.Create(organization);
            return Ok(result);
        }
        //update : Put
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] OrganizationRequests organization)
        {
            var result = await _organizationService.Update(id, organization);
            return Ok(result);
        }
        //delete : Delete
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _organizationService.Delete(id);
            return Ok(result);
        }
    }
}
