using AlahlyMomknTask.Enums.Requests;
using AlahlyMomknTask.Infrastructure.EndPoints;
using AlahlyMomknTask.Infrastructure.Extensions;
using AlahlyMomknTask.Infrastructure.Services;
using AlahlyMomknTask.Models.Business;
using AlahlyMomknTask.Models.Request;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace AlahlyMomknTask.Infrastructure.Managers
{
    public class UserManager : IUserManager
    {
        private readonly HttpClient httpClient;
        private readonly SessionManager sessionManager;
        private readonly ISnackbar snackbar;
        public UserManager(HttpClient httpClient, SessionManager session, ISnackbar snack)
        {
            this.httpClient = httpClient;
            this.sessionManager = session;
            snackbar = snack;
        }
        public async Task<ResponseResults<User>> LoginAsync(LoginData loginData)
        {
            var response = await httpClient.PostAsJsonAsync(UsersEndPoints.Login, loginData);
            if (response.IsSuccessStatusCode)
            {
                var value = await response.ToResult<APIReturnObj<User>>();
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
    }
}
