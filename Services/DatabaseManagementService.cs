using Microsoft.EntityFrameworkCore;
using TechChallengeTwo.Data;

namespace TechChallengeTwo.Services
{
    public static class DatabaseManagementService
    {
        public static void MigrationInitialisation(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var serviceDb = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                serviceDb.Database.Migrate();
            }
        }
    }
}
