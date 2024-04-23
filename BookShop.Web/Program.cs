using BookShop.Data.Extensions;
using BookShop.Data.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//tat ca controller muon su dung phai dang nhap
builder.Services.AddControllersWithViews(o => o.Filters.Add(new AuthorizeFilter()));

builder.Services.AddAuthentication(options =>
                {
                    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    //options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
                })
                .AddCookie()
                //.AddCookie(options =>
                //{
                //    options.Events = new CookieAuthenticationEvents
                //    {
                //        OnValidatePrincipal = async (c) =>
                //        {
                //            your logic here
                //            c.RejectPrincipal();
                //        }
                //    };
                //})
                .AddGoogle(options =>
                {
                    options.ClientId = "949690618501-9m42r7iglop2k432din46hfl9frmj7v5.apps.googleusercontent.com";
                    options.ClientSecret = "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";
                });

//builder.Services.AddScoped<IUserRepository, UserRepository>();
ServicesInjection.AddProjectModules(builder.Services);

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
