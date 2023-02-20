using AlahlyMomknTask.Enums.Requests;
using AlahlyMomknTask.Infrastructure.Managers;
using AlahlyMomknTask.Infrastructure.Services;
using AlahlyMomknTask.Infrastructure.Statics;
using AlahlyMomknTask.Models.Request;
using Microsoft.AspNetCore.Components;

namespace AlahlyMomknTask.Client.Pages
{
    public partial class Login
    {
        #region Properties
        private LoginData User = new();
        [Inject]
        private IUserManager authenticationManager { get; set; }
        [Inject] public SessionManager sessionManager { get; set; }

        #endregion

        #region Overrides
        protected override void OnInitialized()
        {
            if (SystemValues.CurrentUser != null)
                navigation.NavigateTo("Index");

        }
        #endregion

        #region Data Actions
        private async Task DoLogin()
        {

            if (!loadingContainer.TriggerLoading(snackBar)) return;

            var apiResult = await authenticationManager.LoginAsync(User);
            loadingContainer.ReleaseLoading();

            switch (apiResult.Status)
            {
                case APIReturnStatus.Success:
                    SystemValues.CurrentUser = apiResult.Result;
                    await sessionManager.UpdateUserData();
                    navigation.NavigateTo("Index");
                    SnackBarHelper.ShowSuccess(snackBar, "Logged in successfly.");      
                    break;
                case APIReturnStatus.WrongUser:
                case APIReturnStatus.WrongPassword:
                    SnackBarHelper.ShowError(snackBar, "Wrong username or password please check your inputs and try again.");
                    break;
                case APIReturnStatus.NotActive:
                    SnackBarHelper.ShowWarning(snackBar, "Your user not active, please contact system admin to reactivate.");
                    break;

            }

        }

        #endregion
    }
}
