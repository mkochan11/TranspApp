using ApplicationCore.Entities;
using Infrastructure.Data;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Web.Configuration;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddWebServices(builder.Configuration);
builder.Services.AddCoreServices(builder.Configuration);
builder.Services.AddRazorPages();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TranspAppDB")));

builder.Services.AddDbContext<AppIdentityDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TranspAppIdentityDB")));
builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<AppIdentityDbContext>();

/*builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
           .AddEntityFrameworkStores<AppIdentityDbContext>();
                           //.AddDefaultTokenProviders();
*/
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var scopedProvider = scope.ServiceProvider;
    try
    {
        var appDbContext = scopedProvider.GetRequiredService<AppDbContext>();
        await AppDbContextSeed.SeedAsync(appDbContext);
    }catch(Exception ex)
    {
        
    }
}

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
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
