using dummy_auth.client1;
using dummy_auth.idm.client;

using Microsoft.Extensions.Http;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddHttpClient("IdManagementHttpClient", client => {
    var settingKey = $"{Constants.Settings.ApiSectionName}:BaseUrl";

    client.BaseAddress = new Uri(builder.Configuration[settingKey] ?? throw new ApplicationException(message: $"Missing configuration value for '{settingKey}'"));

    client.DefaultRequestHeaders.Add("Accept", "application/json");
});

builder.Services.AddScoped<IdManagementApiClient>(sp => {
    var httpClientFactory = sp.GetRequiredService<IHttpClientFactory>();
    var httpClient = httpClientFactory.CreateClient("IdManagementHttpClient");
    return new IdManagementApiClient(httpClient.BaseAddress!.ToString(), httpClient);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
