using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AdPage.Api.Configuration;
using AdPage.Api.Model;
using RestSharp;

namespace AdPage.Api.Client
{
    
    public class BaseClient
    {

        private ApiConfiguration _configuration;
        private RestClient _client;

        public void Init(ApiConfiguration configuration)
        {
            _configuration = configuration;
            _client = new RestClient(configuration.url);
            _client.AddDefaultHeader("x-api-key", configuration.apiKey);
        }
        
        public void HandleException<T>(IRestResponse<T> result)
        {
            if (result.ErrorException != null)
            {
                throw new Exception(result.ErrorException.Message);
            }
            
            if (result.ErrorMessage != null)
            {
                throw new Exception(result.ErrorMessage);
            }
        }

        private Task<T> AsyncCall<T>(string url, Method method) where T : new()
        {
            var taskCompletionSource = new TaskCompletionSource<T>();
            _client.ExecuteAsync<T>(new RestRequest(url, method, DataFormat.Json),
                response =>
                {
                    HandleException(response);
                    taskCompletionSource.SetResult(response.Data);
                });
            return taskCompletionSource.Task;
        }

        public Task<AgencyDto> GetAgency()
        {
            return AsyncCall<AgencyDto>("/agency", Method.GET);
        }

        public Task<List<ProjectDto>> GetProjects()
        {
            return AsyncCall<List<ProjectDto>>("/project", Method.GET);
        }

        public Task<ProjectDto> GetProject(string uuid)
        {
            return AsyncCall<ProjectDto>($"/project/{uuid}", Method.GET);
        }

        public Task<ProjectDto> PublishUnPublishProject(string uuid)
        {
            return AsyncCall<ProjectDto>($"/project/{uuid}/publish", Method.PUT);
        }

        public Task<List<Dictionary<string, string>>> GetProjectLeads(string uuid)
        {
            return AsyncCall<List<Dictionary<string, string>>>($"/project/{uuid}/leads?format", Method.GET);
        }

        public Task<bool> DeleteLead(string projectUuid, string leadUuid)
        {
            var taskCompletionSource = new TaskCompletionSource<bool>();
            _client.ExecuteAsync<bool>(new RestRequest($"/project/{projectUuid}/leads/{leadUuid}", Method.PUT, DataFormat.Json),
                response =>
                {
                    HandleException(response);
                    taskCompletionSource.SetResult(response.StatusCode == HttpStatusCode.OK);
                });
            return taskCompletionSource.Task;
        }
        
    }
    
}