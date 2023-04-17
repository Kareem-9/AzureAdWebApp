using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PatientInformationWebApp.Data;

[assembly: HostingStartup(typeof(PatientInformationWebApp.Areas.Identity.IdentityHostingStartup))]
namespace PatientInformationWebApp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<PatientInformationWebAppContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("PatientInformationWebAppContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<PatientInformationWebAppContext>();
            });
        }
    }
}