using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ProfiledAi;
using ProfiledAi.DataBase;
using ProfiledAi.Services;
var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddBlazoredLocalStorage();
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<Gemini>();
builder.Services.AddScoped<LocalStorageCaching>();
builder.Services.AddScoped<PersonalModelDataHandler>();
await builder.Build().RunAsync();