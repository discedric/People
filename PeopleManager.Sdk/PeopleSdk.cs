using System.Net.Http.Json;
using PeopleManager.Dto.Filters;
using PeopleManager.Dto.Person;
using PeopleManager.Sdk.Extensions;
using Vives.Presentation.Authentication;
using Vives.Services.Model;

namespace PeopleManager.Sdk
{
    public class PeopleSdk(IHttpClientFactory httpClientFactory, IBearerTokenStore tokenStore)
    {
        private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;
        private readonly IBearerTokenStore _tokenStore = tokenStore;
        private readonly string Link = "people";

        public async Task<IList<PersonResults>> Find(Paging paging, PersonFilter? filter = null, Sorting? sorting = null)
        {
            var httpClient = _httpClientFactory.CreateClient("PeopleManagerApi");

            var route = $"{Link}?paging.offset={paging.Offset}&paging.limit={paging.Limit}";
            if (filter is not null)
            {
                route = $"{route}&filter.Seach={filter.Search}&filter.OrganizatinoId={filter.OrganizationId}";
            }
            if (sorting is not null)
            {
                route = $"{route}&sorting.PropertyName={sorting.PropertyName}&sorting.IsDescending={sorting.IsDescending}";
            }

            var response = await httpClient.GetAsync(route);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<IList<PersonResults>>();
            if (result is null)
            {
                return new List<PersonResults>();
            }
            return result;
        }

        public async Task<ServiceResult<PersonResults>> Get(int id)
        {
            var httpClient = _httpClientFactory.CreateClient("PeopleManagerApi");

            var response = await httpClient.GetAsync($"{Link}/{id}");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<ServiceResult<PersonResults>>();
            if (result is null)
            {
                return new ServiceResult<PersonResults>() { Data = new PersonResults() { FirstName = "NotFound", LastName = "NotFound"} };
            }
            return result;
        }

        public async Task<ServiceResult<PersonResults>> Create(PersonRequests person)
        {
            var httpClient = _httpClientFactory.CreateClient("PeopleManagerApi");

            var response = await httpClient.PostAsJsonAsync(Link, person);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<ServiceResult<PersonResults>>();
            if (result is null)
            {
                return new ServiceResult<PersonResults>() { Data = new PersonResults() { FirstName = "NotFound", LastName = "NotFound" } };
            }
            return result;
        }

        public async Task<ServiceResult<PersonResults>> Update(int id, PersonRequests person)
        {
            var httpClient = _httpClientFactory.CreateClient("PeopleManagerApi");

            var response = await httpClient.PutAsJsonAsync($"{Link}/{id}", person);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<ServiceResult<PersonResults>>();
            if (result is null)
            {
                return new ServiceResult<PersonResults>() { Data = new PersonResults() { FirstName = "NotFound", LastName = "NotFound" } };
            }
            return result;
        }

        public async Task<ServiceResult<PersonResults>> Delete(int id)
        {
            var httpClient = _httpClientFactory.CreateClient("PeopleManagerApi");

            var response = await httpClient.DeleteAsync($"{Link}/{id}");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<ServiceResult<PersonResults>>();
            if (result is null)
            {
                return new ServiceResult<PersonResults>() { Data = new PersonResults() { FirstName = "NotFound", LastName = "NotFound" } };
            }
            return result;
        }
    }
}
