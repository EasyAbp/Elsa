using EasyAbp.Elsa.Activities;
using Elsa.Options;

namespace Microsoft.Extensions.DependencyInjection;

public static class ElsaOptionsBuilderExtensions
{
    public static ElsaOptionsBuilder AddAbpActivities(this ElsaOptionsBuilder builder)
    {
        builder.AddActivity<AbpEventHandler>();

        return builder;
    }
}