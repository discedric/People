using PeopleManager.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeopleManager.Dto.Organization;

namespace PeopleManager.Service
{
    public class OrganizationService
    {
        private readonly OrganizationApiClient _apiClient;

        public OrganizationService(OrganizationApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<IList<OrganizationResult>> GetPeopleAsync()
        {
            return await _apiClient.FindAsync();
        }

        public async Task<OrganizationResult?> GetPersonAsync(int id)
        {
            return await _apiClient.GetAsync(id);
        }

        public async Task<OrganizationResult?> AddPersonAsync(OrganizationRequests newPerson)
        {
            return await _apiClient.CreateAsync(newPerson);
        }

        public async Task<OrganizationResult?> UpdatePersonAsync(int id, OrganizationRequests updatedPerson)
        {
            return await _apiClient.UpdateAsync(id, updatedPerson);
        }

        public async Task DeletePersonAsync(int id)
        {
            await _apiClient.DeleteAsync(id);
        }
    }
}
