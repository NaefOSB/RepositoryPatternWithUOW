using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace RepositoryPatternWithUOW.Core.General
{
    public static class ModuleCoreDependencies
    {
        public static IServiceCollection AddCoreDependencies(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
