using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorWASM;
using BlazorWASM.Auth;
using BlazorWASM.Services.ClientInterfaces;
using BlazorWASM.Services.Http;
using Microsoft.AspNetCore.Components.Authorization;
using Model.Auth;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(
    sp => 
        new HttpClient { 
            BaseAddress = new Uri("http://localhost:8888")//bussiness server uri
        }
);
AuthorizationPolicies.AddPolicies(builder.Services);
builder.Services.AddScoped<IListingService, ListingService>();
builder.Services.AddScoped<IAuthService, JwtAuthService>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthProvider>();
await builder.Build().RunAsync();