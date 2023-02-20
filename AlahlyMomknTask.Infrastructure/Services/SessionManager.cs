using AlahlyMomknTask.Enums.Requests;
using AlahlyMomknTask.Infrastructure.EndPoints;
using AlahlyMomknTask.Infrastructure.Statics;
using AlahlyMomknTask.Models.Business;
using AlahlyMomknTask.Models.Request;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AlahlyMomknTask.Infrastructure.Services
{
    public class SessionManager
    {
        private static readonly string UserDataKey = "qJDu2c6dF5mcFnAJ";
        private readonly HttpClient httpClient;
        private readonly ILocalStorageService storageService;
        private readonly NavigationManager navigationManager;

        public SessionManager(HttpClient httpClient,
            ILocalStorageService storageService,
            NavigationManager navigationManager)
        {
            this.httpClient = httpClient;
            this.storageService = storageService;
            this.navigationManager = navigationManager;

        }

        public async Task CheckUserData()
        {
            if (await storageService.ContainKeyAsync(UserDataKey))
            {
                string userDataCipher = await storageService.GetItemAsStringAsync(UserDataKey);
                User userData = ConvertFromString64<User>(userDataCipher);
                if (userData == null)
                    await ClearUserData();
                else
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", userData.Token);
                    var valid = await CheckTokenValidation();
                    if (valid)
                    {
                        SystemValues.CurrentUser = userData;
                    }
                    else
                    {
                        await ClearUserData();
                    }
                }
            }
            else
            {
                await ClearUserData();
            }
        }

        public async Task UpdateUserData()
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", SystemValues.CurrentUser.Token);
            await storageService.SetItemAsStringAsync(UserDataKey, ConvertToString64(SystemValues.CurrentUser));
        }
        public async Task ClearUserData()
        {

            SystemValues.CurrentUser = null;
            httpClient.DefaultRequestHeaders.Authorization = null;
            await storageService.RemoveItemAsync(UserDataKey);
            if (!navigationManager.ToAbsoluteUri(navigationManager.Uri).AbsolutePath.EndsWith("/") &&
   !navigationManager.ToAbsoluteUri(navigationManager.Uri).AbsolutePath.EndsWith("/Login"))
                navigationManager.NavigateTo("/");
        }
        private T ConvertFromString64<T>(string cipher)
        {
            byte[] buffer = Convert.FromBase64String(cipher);
            if (buffer == null) return default;
            string datavalue = Encoding.UTF8.GetString(buffer);
            if (string.IsNullOrEmpty(datavalue)) return default;
            return JsonConvert.DeserializeObject<T>(datavalue);
        }
        private string ConvertToString64<T>(T data)
        {
            if (data == null) return null;
            string objectJson = JsonConvert.SerializeObject(data);
            byte[] buffer = Encoding.UTF8.GetBytes(objectJson);
            return Convert.ToBase64String(buffer);
        }

        private async Task<bool> CheckTokenValidation()
        {
            var response = await httpClient.GetAsync(UsersEndPoints.CheckTokenValidation);
            return response.IsSuccessStatusCode;

        }
    }
}
