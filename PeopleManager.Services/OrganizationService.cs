using Microsoft.EntityFrameworkCore;
using PeopleManager.Core;
using PeopleManager.Dto.Filters;
using PeopleManager.Dto.Organization;
using PeopleManager.Model;
using PeopleManager.Services.Extensions.Filters;
using PeopleManager.Services.Extensions.Projection;
using PeopleManager.Services.Extensions.Validation;
using Vives.Services.Model;
using Vives.Services.Extensions;

namespace PeopleManager.Services
{
    public class OrganizationService
    public class OrganizationService(PeopleManagerDbContext dbContext)
    {
        private readonly PeopleManagerDbContext _dbContext = dbContext;

        //Find
        public async Task<IList<OrganizationResult>> Find(Paging paging, OrganizationFilter? filter)
        {
            return await _dbContext.Organizations
                .Project()
                .ApplyFilter(filter)
                .ApplyPaging(paging)
                .ToListAsync();
        }

        //Get (by Id)
        public async Task<OrganizationResult?> Get(int id)
        {
            return await _dbContext.Organizations
                .Project()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        //Create
        public async Task<ServiceResult<OrganizationResult>?> Create(OrganizationRequests requests)
        {
            var serviceResult = new ServiceResult<OrganizationResult>();
            
            //ValidateRequest
            serviceResult.Validate(requests);

            if(!serviceResult.IsSuccess)
            {
                return serviceResult;
            }

            var organization = new Organization
            {
                Name = requests.Name,
                Description = requests.Description
            };

            _dbContext.Organizations.Add(organization);
            await _dbContext.SaveChangesAsync();

            var result = await Get(organization.Id);

            serviceResult.Data = result;
            if (result is null)
            {
                serviceResult.NotFound(nameof(Organization),0);
            }

            return serviceResult;
        }

        //Update
        public async Task<ServiceResult<OrganizationResult>> Update(int id, OrganizationRequests request)
        {
            var serviceResult = new ServiceResult<OrganizationResult>();

            //ValidateRequest
            serviceResult.Validate(request);

            if(!serviceResult.IsSuccess) {
                return serviceResult;
            }

            var dbOrganization = await _dbContext.Organizations
                .FirstOrDefaultAsync(p => p.Id == id);

            if (dbOrganization is null)
            {
                serviceResult.NotFound(nameof(Organization),id);
                return serviceResult;
            }

            dbOrganization.Name = request.Name;

            await _dbContext.SaveChangesAsync();

            var result = await Get(dbOrganization.Id);

            serviceResult.Data = result;
            if (result is null)
            {
                serviceResult.NotFound(nameof(Organization), dbOrganization.Id);
            }
            return serviceResult;
        }

        //Delete
        public async Task<ServiceResult> Delete(int id)
        {
            var serviceResult = new ServiceResult();

            var organization = await _dbContext.Organizations
                .FirstOrDefaultAsync(p => p.Id == id);

            if (organization is null)
            {
                serviceResult.NotFound(nameof(Organization), id);
                return serviceResult;
            }

            _dbContext.Organizations.Remove(organization);
            await _dbContext.SaveChangesAsync();

            serviceResult.Deleted(nameof(Organization));
            return serviceResult;
        }
    }
}
