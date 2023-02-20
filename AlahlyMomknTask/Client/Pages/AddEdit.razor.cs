using AlahlyMomknTask.Models.Business;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace AlahlyMomknTask.Client.Pages
{
    public partial class AddEdit
    {
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        private bool IsEdit => entity.ID != Guid.Empty;
        private StepItem _entity = new()
        {
            ID = Guid.Empty,
        };
        [Parameter]
        public StepItem entity
        {
            get { return _entity; }
            set
            {

                _entity = value;

            }
        }
        private void DoSubmit()
        {

            if (!IsEdit)
                entity.ID = Guid.NewGuid();
            MudDialog.Close(DialogResult.Ok(entity));
        }
    }
}
