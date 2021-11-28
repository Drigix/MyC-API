using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using WebApplication1.Data;

namespace WebApplication1
{
    public static class ServiceExtensions
    {
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentityCore<ApiUser>(q=> q.User.RequireUniqueEmail=true);

            builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole), services);

            builder.AddEntityFrameworkStores<DatabaseContext>().AddDefaultTokenProviders();
        }
    }
}
