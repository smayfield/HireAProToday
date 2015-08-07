using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Data.Entity;
using HireAProToday.Models;

namespace HireAProToday
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Any migrations that haven't been applied before will
            // automatically be applied on Application Pool restart
            Database.SetInitializer<ApplicationDbContext>(
                new MigrateDatabaseToLatestVersion<ApplicationDbContext,
                Migrations.Configuration>()
                );

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
