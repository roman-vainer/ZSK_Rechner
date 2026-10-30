using Microsoft.EntityFrameworkCore;
namespace ZSK_Rechner.Models
{
    public class EnsureDatabase
    {
        public static void Migrate(IApplicationBuilder app)

        {
            ZSKDBContext context = app.ApplicationServices
                .CreateScope()
                .ServiceProvider
                .GetRequiredService<ZSKDBContext>();
            if(context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
        }
    }
}
