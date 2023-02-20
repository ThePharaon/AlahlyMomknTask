using AlahlyMomknTask.Infrastructure.Statics;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AlahlyMomknTask.Infrastructure.Services
{
    public static class GlobalResponseErrorHandler
    {
        public async static void DoCheckHttpResult(HttpStatusCode code, SessionManager sessionManager, ISnackbar snackbar)
        {
            if (SystemValues.CurrentUser != null)
            {
                switch (code)
                {
                    case HttpStatusCode.Unauthorized:
                        snackbar.Add("Session ended please login again.", Severity.Info);
                        break;
                    case HttpStatusCode.InternalServerError:
                        snackbar.Add("Unknown error occure please relogin.", Severity.Info);
                        break;
                    case HttpStatusCode.NotFound:
                        snackbar.Add("Unknown error occure while requesting please relogin.", Severity.Info);
                        break;
                }
            }
            await sessionManager.ClearUserData();
        }
    }
}
