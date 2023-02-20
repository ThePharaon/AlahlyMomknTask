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
    public class StepItemsManager : IStepItemsManager
    {
        private readonly HttpClient httpClient;
        private readonly SessionManager sessionManager;
        private readonly ISnackbar snackbar;
        public StepItemsManager(HttpClient httpClient, SessionManager sessionManager, ISnackbar snackbar)
        {
            this.httpClient = httpClient;
            this.sessionManager = sessionManager;
            this.snackbar = snackbar;
        }

        public async Task<ResponseResults<List<StepItem>>> GetListAsync(Guid StepID)
        {
            var response = await httpClient.GetAsync(StepItemsEndPoints.List+"/"+StepID);
            if (response.IsSuccessStatusCode)
            {
                var value = await response.ToResult<APIReturnObj<List<StepItem>>>();
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
        public async Task<ResponseResults<StepItem>> GetDetailsAsync(Guid ID)
        {
            var response = await httpClient.GetAsync(StepItemsEndPoints.GetByID + "/" + ID);
            if (response.IsSuccessStatusCode)
            {
                var value = await response.ToResult<APIReturnObj<StepItem>>();
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
        public async Task<APIReturnStatus> CreateAsync(StepItem entity)
        {
            var response = await httpClient.PostAsJsonAsync(StepItemsEndPoints.Create, entity);
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
        public async Task<APIReturnStatus> UpdateAsync(StepItem entity)
        {
            var response = await httpClient.PutAsJsonAsync(StepItemsEndPoints.Update, entity);
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
            var response = await httpClient.DeleteAsync(StepItemsEndPoints.Delete + "/" + ID);
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
