using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlahlyMomknTask.Infrastructure.Statics
{
    public static class DialogStaticValues
    {
        public static readonly DialogOptions StandardOptions = new()
        {
            FullWidth = true,
            Position = DialogPosition.Center,
            CloseButton = true,
            CloseOnEscapeKey = false,
            DisableBackdropClick = true,
            MaxWidth = MaxWidth.Small,

        };
    }
}
