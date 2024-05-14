using PeopleManager.Dto.Organization;
using PeopleManager.Sdk.Extensions;
using System.Net.Http.Json;
using System.Numerics;
using PeopleManager.Dto.Filters;
using Vives.Presentation.Authentication;
using Vives.Services.Model;

namespace PeopleManager.Sdk
{
    public class OrganizationSdk(IHttpClientFactory httpClientFactory, IBearerTokenStore tokenStore)
    {
        private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;
        private readonly IBearerTokenStore _tokenStore = tokenStore;
        private readonly string route = "organization";

        public async Task<IList<OrganizationResult>> Find(Paging paging, OrganizationFilter? filter = null)
        {
            var httpClient = _httpClientFactory.CreateClient("PeopleManagerApi");
            
            var Route = $"{route}?paging.offset={paging.Offset}&paging.limit={paging.Limit}";

            if (filter is not null)
            {
                Route = $"{Route}&filter.search={filter.Search}";
                if (filter.NumberOfPeopleBetween != null)
                {
                    Route = $"{Route}&filter.NumberOfPeopleBetween.To={filter.NumberOfPeopleBetween.To}&filter.NumberOfPeopleBetween.From={filter.NumberOfPeopleBetween.From}";
                }
            }
            
            var response = await httpClient.GetAsync(Route);

            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<IList<OrganizationResult>>();
            if (result is null)
            {
                return new List<OrganizationResult>();
            }
            return result;
        }

        public async Task<ServiceResult<OrganizationResult>> Get(int id)
        {
            var httpClient = _httpClientFactory.CreateClient("PeopleManagerApi");
            
            var response = await httpClient.GetAsync($"{route}/{id}");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<ServiceResult<OrganizationResult>>();
            if (result is null)
            {
                return new ServiceResult<OrganizationResult>() { Data = new OrganizationResult(){Name = "NotFound"} };
            }
            return result;
        }

        public async Task<ServiceResult<OrganizationResult>> Create(OrganizationRequests person)
        {
            var httpClient = _httpClientFactory.CreateClient("PeopleManagerApi");
            
            var response = await httpClient.PostAsJsonAsync(route, person);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<ServiceResult<OrganizationResult>>();
            if (result is null)
            {
                return new ServiceResult<OrganizationResult>() { Data = new OrganizationResult(){Name = "NotFound"} };
            }
            return result;
        }

        public async Task<ServiceResult<OrganizationResult>> Update(int id, OrganizationRequests person)
        {
            var httpClient = _httpClientFactory.CreateClient("PeopleManagerApi");
            
            var response = await httpClient.PutAsJsonAsync($"{route}/{id}", person);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<ServiceResult<OrganizationResult>>();
            if (result is null)
            {
                return new ServiceResult<OrganizationResult>() { Data = new OrganizationResult() { Name = "NotFound" } };
            }
            return result;
        }

        public async Task<ServiceResult<OrganizationResult>> Delete(int id)
        {
            var httpClient = _httpClientFactory.CreateClient("PeopleManagerApi");
            
            var response = await httpClient.DeleteAsync($"{route}/{id}");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<ServiceResult<OrganizationResult>>();
            if (result is null)
            {
                return new ServiceResult<OrganizationResult>() { Data = new OrganizationResult() { Name = "NotFound" } };
            }
            return result;
        }
    }
}
