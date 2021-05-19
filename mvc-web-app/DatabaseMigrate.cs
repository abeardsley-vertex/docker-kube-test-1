using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace mvc_web_app
{
    public static class DatabaseMigrate
    {
        public static void MigrateDatabaseToLatest(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<dataaccess.BloggingContext>();
                context.Database.Migrate();
            }
        }
    }
}