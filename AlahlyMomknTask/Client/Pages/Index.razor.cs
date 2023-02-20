using AlahlyMomknTask.Core.Converters;
using AlahlyMomknTask.Enums.Requests;
using AlahlyMomknTask.Infrastructure.Managers;
using AlahlyMomknTask.Infrastructure.Services;
using AlahlyMomknTask.Infrastructure.Statics;
using AlahlyMomknTask.Models.Business;
using AlahlyMomknTask.Models.Request;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Text.RegularExpressions;
using static MudBlazor.CategoryTypes;

namespace AlahlyMomknTask.Client.Pages
{
    public partial class Index
    {
        #region Properties
        private List<TabStep> StepsList = new();


        private TabStep _currentStep = new();

        public TabStep CurrentStep
        {
            get { return _currentStep; }
            set { _currentStep = value; }
        }

        private List<StepItem> CurrentStepItems = new();
        [Inject]
        private ITabStepsManager tabStepsManager { get; set; }
        [Inject]
        private IStepItemsManager stepItemsManager { get; set; }

        #endregion

        #region Overrides
        protected override async void OnInitialized()
        {
            await LoadAllSteps(true);
        }
        #endregion

        #region Data Actions

        #region Steps
        private async Task LoadAllSteps(bool first = false)
        {
            if (!loadingContainer.TriggerLoading(snackBar)) return;

            var results = await tabStepsManager.GetListAsync();
            loadingContainer.ReleaseLoading();

            if (results.Status == APIReturnStatus.Success)
            {
                StepsList = results.Result.OrderBy(s=>s.Index).ToList();
                if(first)
                {
                    if (StepsList.Count < 1)
                    {
                        CurrentStep = new();
                        CurrentStepItems = new();
                    }
                    else
                    { 
                        CurrentStep = StepsList[0];
                        await LoadAllStepsItems(CurrentStep.ID);

                    }

                }
                StateHasChanged();
            }

        }
        private async Task AddNewStep()
        {
            if (!loadingContainer.TriggerLoading(snackBar)) return;

            int nextIndex = GetNextIndexValueFromList();
            var step = new TabStep()
            {
                ID = Guid.NewGuid(),
                Name = "Step " + nextIndex,
                Index = nextIndex,
            };

            var results = await tabStepsManager.CreateAsync(step);
            loadingContainer.ReleaseLoading();

            if (results == APIReturnStatus.Success)
            {
                await LoadAllSteps();

                SetCurrentStep(step.ID);
                SnackBarHelper.ShowSuccess(snackBar, $"Step ({step.Name}) added successfuly.");
            }

        }
        private async Task DeleteStep(TabStep step)
        {
            bool? result = await DialogService.ShowMessageBox("Delete Step", $"Are you sure you want to delete this step ({step.Name}) ?",
               yesText: "Yes",
               cancelText: "No");
            if (result != null)
            {
                if (!loadingContainer.TriggerLoading(snackBar)) return;

                var results = await tabStepsManager.DeleteAsync(step.ID);
                loadingContainer.ReleaseLoading();

                if (results == APIReturnStatus.Success)
                {
                    await LoadAllSteps();

                    SetCurrentStep(CurrentStep.ID);
                    SnackBarHelper.ShowSuccess(snackBar, $"Step ({step.Name}) deleted successfuly.");
                }
            }

        }
        #endregion

        #region StepItems
        private async Task LoadAllStepsItems(Guid StepID)
        {
            var results = await stepItemsManager.GetListAsync(StepID);
            if (results.Status == APIReturnStatus.Success)
            {
                CurrentStepItems = results.Result;
                StateHasChanged();
            }

        }
        private async Task AddNewItem()
        {
            var dialogOptions = DialogStaticValues.StandardOptions;
            var dialog = DialogService.Show<AddEdit>("Create New Item", dialogOptions);
            var result = await dialog.Result;
            if (!result.Canceled)
            {
                if (!loadingContainer.TriggerLoading(snackBar)) return;
                var sendValue = result.Data as StepItem;
                sendValue.TabStepID = CurrentStep.ID;
                var status = await stepItemsManager.CreateAsync(sendValue);
                loadingContainer.ReleaseLoading();
                if (status == APIReturnStatus.Success)
                {
                    await LoadAllStepsItems(CurrentStep.ID);
                    SnackBarHelper.ShowSuccess(snackBar, $"Item ({sendValue.Name}) added successfuly.");
                }

            }

        }
        private async Task EditItem(Guid ItemID)
        {
            if (!loadingContainer.TriggerLoading(snackBar)) return;
            var serverValue = await CheckItemExist(ItemID);
            loadingContainer.ReleaseLoading();
            if (serverValue == null)
            {
                await LoadAllStepsItems(CurrentStep.ID);
                SnackBarHelper.ShowInfo(snackBar, "Item not found, Data Refreshed.");
                return;
            }
            var dialogOptions = DialogStaticValues.StandardOptions;
            var parameters = new DialogParameters
            {
                ["entity"] = serverValue
            };
            var dialog = DialogService.Show<AddEdit>("Edit Item",parameters, dialogOptions);
            var result = await dialog.Result;
            if (!result.Canceled)
            {
                if (!loadingContainer.TriggerLoading(snackBar)) return;
                var sendValue = result.Data as StepItem;
                var status = await stepItemsManager.UpdateAsync(sendValue);
                loadingContainer.ReleaseLoading();
                if (status == APIReturnStatus.Success)
                {
                    await LoadAllStepsItems(CurrentStep.ID);
                    SnackBarHelper.ShowSuccess(snackBar, $"Item ({sendValue.Name}) Updated successfuly.");
                }

            }

        }
        private async Task DeleteItem(StepItem item)
        {
            bool? result = await DialogService.ShowMessageBox("Delete Item", $"Are you sure you want to delete this item ({item.Name}) ?",
                yesText: "Yes",
                cancelText: "No");
            if (result != null)
            {
                if (!loadingContainer.TriggerLoading(snackBar)) return;

                var status = await stepItemsManager.DeleteAsync(item.ID);
                loadingContainer.ReleaseLoading();
                await LoadAllStepsItems(CurrentStep.ID);
                SnackBarHelper.ShowInfo(snackBar, $"Item ({item.Name}) deleted successfuly.");
            }
        }
        private async Task<StepItem> CheckItemExist(Guid ItemID)
        {
            var result = await stepItemsManager.GetDetailsAsync(ItemID);
            return result.Result;
        }
        #endregion

        #endregion

        #region Helpers
        private int GetNextIndexValueFromList()
        {
            if (StepsList.Count == 0) return 0;
            return StepsList.Max(s => s.Index) + 1;
        }
        private async void SetCurrentStep(Guid StepID)
        {
            if (CurrentStep.ID == StepID) return;
            var step = StepsList.FirstOrDefault(s => s.ID == StepID);
            if (step == null)
                await LoadAllSteps(true);
            else
            { 
                CurrentStep = step;
                await LoadAllStepsItems(StepID);
            }
        }

        private void GoNext()
        {
            if(!CanGoNext()) return;

            SetCurrentStep(StepsList[StepsList.IndexOf(CurrentStep) + 1].ID);
        }
        private void GoPrevious()
        {
            if (!CanGoPrevious()) return;

            SetCurrentStep(StepsList[StepsList.IndexOf(CurrentStep) - 1].ID);
        }
        private bool CanGoNext()
        {
            if (StepsList.Count == 0) return false;
            return CurrentStep.Index != StepsList.Max(s => s.Index);
        }
        private bool CanGoPrevious()
        {
            if (StepsList.Count == 0) return false;
            return CurrentStep.Index != StepsList.Min(s => s.Index);
        }
        #endregion
    }
}
