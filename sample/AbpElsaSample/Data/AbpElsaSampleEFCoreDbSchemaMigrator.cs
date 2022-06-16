using Microsoft.EntityFrameworkCore;
using Volo.Abp.DependencyInjection;

namespace AbpElsaSample.Data;

public class AbpElsaSampleEFCoreDbSchemaMigrator : ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public AbpElsaSampleEFCoreDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the AbpElsaSampleDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<AbpElsaSampleDbContext>()
            .Database
            .MigrateAsync();
    }
}
