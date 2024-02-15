using Serilog;
using TiraCiptaLogistik.Web.Interface;
using TiraCiptaLogistik.Web.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var logger = new LoggerConfiguration()
    .WriteTo.BetterStack(sourceToken: builder.Configuration.GetSection("BetterStack").Value)
    //.WriteTo.
    .MinimumLevel.Information()
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);
builder.Services.AddHttpClient();

builder.Services.AddScoped<IGetDataService, GetDataService>();
builder.Services.AddScoped<ISendDataService, SendDataService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
