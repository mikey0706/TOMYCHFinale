using Microsoft.EntityFrameworkCore;
using Persistance.DataContext;

namespace TOMYCHFinale.Utils
{
    public static class Extensions
    {
        public static void MigrateDatabase(this WebApplication application)
        {
            var scope = application.Services.CreateScope();
            var db = scope.ServiceProvider.GetService<MyAppDbContext>();
            db.Database.Migrate();
        }
    }
}
