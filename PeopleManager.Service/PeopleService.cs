using PeopleManager.Dto.Person;
using PeopleManager.Sdk;

namespace PeopleManager.Service
{
    public class PeopleService
    {
        private readonly PeopleApiClient _apiClient;

        public PeopleService(PeopleApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<IList<PersonResults>> GetPeopleAsync()
        {
            return await _apiClient.FindAsync();
        }

        public async Task<PersonResults?> GetPersonAsync(int id)
        {
            return await _apiClient.GetAsync(id);
        }

        public async Task<PersonResults?> AddPersonAsync(PersonRequests newPerson)
        {
            return await _apiClient.CreateAsync(newPerson);
        }

        public async Task<PersonResults?> UpdatePersonAsync(int id, PersonRequests updatedPerson)
        {
            return await _apiClient.UpdateAsync(id, updatedPerson);
        }

        public async Task DeletePersonAsync(int id)
        {
            await _apiClient.DeleteAsync(id);
        }
    }
}
