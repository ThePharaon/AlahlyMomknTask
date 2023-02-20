using AlahlyMomknTask.Infrastructure.Services;
using Microsoft.AspNetCore.Components;

namespace AlahlyMomknTask.Client.Shared
{
    public partial class InnerLayout
    {
        [Inject] public SessionManager sessionManager { get; set; }
        private async void DoLogout()
        {
            bool? result = await DialogService.ShowMessageBox("Logout", "Are you sure that you want to logout ?",
                yesText: "Yes",
                cancelText: "No");
            if (result != null)
            {
                if (!loadingContainer.TriggerLoading(snackBar)) return;


                await sessionManager.ClearUserData();
                loadingContainer.ReleaseLoading();
                SnackBarHelper.ShowInfo(snackBar, "You logged out successfly.");
            }

        }
    }
}
