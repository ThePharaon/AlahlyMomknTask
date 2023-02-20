using AlahlyMomknTask.Client;
using AlahlyMomknTask.Infrastructure.Extensions;
using AlahlyMomknTask.Infrastructure.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.RegisterMudServices();
builder.RegisterManagers();
builder.RegisterCustomServices();


var host = builder.Build();

var sessionManager = host.Services.GetRequiredService<SessionManager>();

await sessionManager.CheckUserData();


await host.RunAsync();
