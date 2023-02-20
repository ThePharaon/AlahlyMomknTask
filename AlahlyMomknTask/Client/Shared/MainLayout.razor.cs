namespace AlahlyMomknTask.Client.Shared
{
    public partial class MainLayout : IDisposable
    {
        bool isLoading => loadingContainer.IsLoading();


        protected override void OnInitialized()
        {
            loadingContainer.OnLoadingChanged += DoRefrech;
            base.OnInitialized();
        }
        private void DoRefrech()
        {
            StateHasChanged();
        }
        public void Dispose()
        {
            loadingContainer.OnLoadingChanged -= DoRefrech;
        }
    }
}
