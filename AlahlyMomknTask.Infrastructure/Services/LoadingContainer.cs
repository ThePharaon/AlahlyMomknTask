using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlahlyMomknTask.Infrastructure.Services
{
    public class LoadingContainer
    {
        private bool _loading = false;
        public bool IsLoading() => _loading;
        public event Action OnLoadingChanged;
        private void NotifyLoadingChanged() => OnLoadingChanged?.Invoke();
        public bool TriggerLoading(ISnackbar snackbar)
        {
            if (!_loading)
            {
                _loading = true;
                NotifyLoadingChanged();
                return true;
            }
            else
            {

                snackbar.Add("Another Action is loading please try again later !", Severity.Error);
                return false;
            }

        }
        public void ReleaseLoading()
        {
            _loading = false;
            NotifyLoadingChanged();
        }
    }
}
