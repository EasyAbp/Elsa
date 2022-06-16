using System.Threading;
using System.Threading.Tasks;
using Elsa.Services;
using Volo.Abp.DependencyInjection;
using Volo.Abp.MultiTenancy;

namespace EasyAbp.Elsa.Infrastructures;

public class AbpTenantAccessor : ITenantAccessor, ITransientDependency
{
    private readonly ICurrentTenant _currentTenant;

    public AbpTenantAccessor(ICurrentTenant currentTenant)
    {
        _currentTenant = currentTenant;
    }
        
    public virtual Task<string> GetTenantIdAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        return Task.FromResult(_currentTenant.Id?.ToString());
    }
}