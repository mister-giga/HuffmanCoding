using HuffmanCoding;
using HuffmanCoding.Models;
using HuffmanCoding.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<HuffmanCoder>();
builder.Services.AddScoped<PageStateValidator>();
builder.Services.AddSingleton<CharInfoStore>();

await builder.Build().RunAsync();
