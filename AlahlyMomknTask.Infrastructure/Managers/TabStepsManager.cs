using AlahlyMomknTask.Enums.Requests;
using AlahlyMomknTask.Infrastructure.EndPoints;
using AlahlyMomknTask.Infrastructure.Extensions;
using AlahlyMomknTask.Infrastructure.Services;
using AlahlyMomknTask.Models.Business;
using AlahlyMomknTask.Models.Request;
using MudBlazor;
using System.Net.Http.Json;

namespace AlahlyMomknTask.Infrastructure.Managers
{
    public class TabStepsManager : ITabStepsManager
    {
        private readonly HttpClient httpClient;
        private readonly SessionManager sessionManager;
        private readonly ISnackbar snackbar;
        public TabStepsManager(HttpClient httpClient, SessionManager sessionManager, ISnackbar snackbar)
        {
            this.httpClient = httpClient;
            this.sessionManager = sessionManager;
            this.snackbar = snackbar;
        }

        public async Task<ResponseResults<List<TabStep>>> GetListAsync()
        {
            var response = await httpClient.GetAsync(TabStepsEndPoints.List);
            if (response.IsSuccessStatusCode)
            {
                var value = await response.ToResult<APIReturnObj<List<TabStep>>>();
                return new()
                {
                    Result = value.ReturnValue,
                    Status = value.Status
                };
            }
            else
            {
                GlobalResponseErrorHandler.DoCheckHttpResult(response.StatusCode, sessionManager, snackbar);

                return new()
                {
                    Result = null,
                    Status = APIReturnStatus.InternalError
                };
            }
        }
        public async Task<APIReturnStatus> CreateAsync(TabStep entity)
        {
            var response = await httpClient.PostAsJsonAsync(TabStepsEndPoints.Create, entity);
            if (response.IsSuccessStatusCode)
            {
                var value = await response.ToResult<APIReturnObj<object>>();
                return value.Status;
            }
            else
            {
                GlobalResponseErrorHandler.DoCheckHttpResult(response.StatusCode, sessionManager, snackbar);

                return APIReturnStatus.InternalError;
            }
        }
        public async Task<APIReturnStatus> UpdateAsync(TabStep entity)
        {
            var response = await httpClient.PutAsJsonAsync(TabStepsEndPoints.Update, entity);
            if (response.IsSuccessStatusCode)
            {
                var value = await response.ToResult<APIReturnObj<object>>();
                return value.Status;
            }
            else
            {
                GlobalResponseErrorHandler.DoCheckHttpResult(response.StatusCode, sessionManager, snackbar);

                return APIReturnStatus.InternalError;
            }
        }
        public async Task<APIReturnStatus> DeleteAsync(Guid ID)
        {
            var response = await httpClient.DeleteAsync(TabStepsEndPoints.Delete + "/" + ID);
            if (response.IsSuccessStatusCode)
            {
                var value = await response.ToResult<APIReturnObj<object>>();
                return value.Status;
            }
            else
            {
                GlobalResponseErrorHandler.DoCheckHttpResult(response.StatusCode, sessionManager, snackbar);

                return APIReturnStatus.InternalError;
            }
        }

       

       
    }
}
