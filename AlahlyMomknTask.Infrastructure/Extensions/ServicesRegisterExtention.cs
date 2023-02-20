using AlahlyMomknTask.Infrastructure.Managers;
using AlahlyMomknTask.Infrastructure.Services;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor;
using MudBlazor.Services;

namespace AlahlyMomknTask.Infrastructure.Extensions
{
    public static class ServicesRegisterExtention
    {
        public static void RegisterMudServices(this WebAssemblyHostBuilder builder)
        {
            builder.Services.AddMudServices(config =>
            {
                config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.TopCenter;
                config.SnackbarConfiguration.MaxDisplayedSnackbars = 6;
                config.SnackbarConfiguration.PreventDuplicates = false;
                config.SnackbarConfiguration.NewestOnTop = true;
                config.SnackbarConfiguration.ShowCloseIcon = true;
                config.SnackbarConfiguration.VisibleStateDuration = 5000;
                config.SnackbarConfiguration.HideTransitionDuration = 300;
                config.SnackbarConfiguration.ShowTransitionDuration = 300;
                config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
            });
        }
        public static void RegisterManagers(this WebAssemblyHostBuilder builder)
        {
            builder.Services.AddScoped<IUserManager, UserManager>();
            builder.Services.AddScoped<ITabStepsManager, TabStepsManager>();
            builder.Services.AddScoped<IStepItemsManager, StepItemsManager>();         
        }
        public static void RegisterCustomServices(this WebAssemblyHostBuilder builder)
        {
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddScoped<SessionManager>();
            builder.Services.AddSingleton<LoadingContainer>();
        }
    }
}
