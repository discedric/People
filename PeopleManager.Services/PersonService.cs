using Microsoft.EntityFrameworkCore;
using PeopleManager.Core;
using PeopleManager.Dto.Filters;
using PeopleManager.Dto.Person;
using PeopleManager.Model;
using PeopleManager.Services.Extensions.Filters;
using PeopleManager.Services.Extensions.Projection;
using PeopleManager.Services.Extensions.Validation;
using Vives.Services.Model;
using Vives.Services.Extensions;

namespace PeopleManager.Services
{
    public class PersonService(PeopleManagerDbContext dbContext)
    {
        private readonly PeopleManagerDbContext _dbContext = dbContext;

        //Find
        public async Task<IList<PersonResults>> Find(Paging paging, PersonFilter filter, Sorting sorting)
        {
            return await _dbContext.People
                .Project()
                .ApplyFilter(filter)
                .OrderBy(sorting)
                .ApplyPaging(paging)
                .ToListAsync();
        }

        //Get (by Id)
        public async Task<PersonResults?> Get(int id)
        {
            return await _dbContext.People
                .Project()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        //Create
        public async Task<ServiceResult<PersonResults>> Create(PersonRequests request)
        {
            var serviceResult = new ServiceResult<PersonResults>();

            //validate
            serviceResult.Validate(request);

            if (serviceResult.IsSuccess)
            {
                return serviceResult;
            }

            var person = new Person
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                OrganizationID = request.OrganizationId
            };
            _dbContext.People.Add(person);
            await _dbContext.SaveChangesAsync();

            var result = await Get(person.Id);

            serviceResult.Data = result;
            if (result is null)
            {
                serviceResult.NotFound(nameof(Person), person.Id);
            }
            return serviceResult;
        }

        //Update
        public async Task<ServiceResult<PersonResults>> Update(int id, PersonRequests request)
        {
            var serviceResult = new ServiceResult<PersonResults>();

            //validate
            serviceResult.Validate(request);

            if (serviceResult.IsSuccess)
            {
                return serviceResult;
            }

            var dbPerson = await _dbContext.People
                .FirstOrDefaultAsync(p => p.Id == id);

            if (dbPerson is null)
            {
                return null;
            }

            dbPerson.FirstName = request.FirstName;
            dbPerson.LastName = request.LastName;
            dbPerson.Email = request.Email;
            dbPerson.OrganizationID = request.OrganizationId;

            await _dbContext.SaveChangesAsync();

            var result = await Get(dbPerson.Id);

            serviceResult.Data = result;
            if (result is null)
            {
                serviceResult.NotFound(nameof(Person), dbPerson.Id);
            }

            return serviceResult;
        }

        //Delete
        public async Task<ServiceResult> Delete(int id)
        {
            var serviceResult = new ServiceResult<PersonResults>();

            var person = await _dbContext.People
                .FirstOrDefaultAsync(p => p.Id == id);


            if (person is null)
            {
                serviceResult.NotFound(nameof(Person), id);
                return serviceResult;
            }
            _dbContext.People.Remove(person);
            await _dbContext.SaveChangesAsync();

            serviceResult.Deleted(nameof(person));
            return serviceResult;
        }

    }
}
