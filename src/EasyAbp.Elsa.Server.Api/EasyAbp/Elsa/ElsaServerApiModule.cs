using EasyAbp.Elsa.Infrastructures;
using Localization.Resources.AbpUi;
using EasyAbp.Elsa.Localization;
using Elsa.Server.Api;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.Mvc.AntiForgery;

namespace EasyAbp.Elsa;

[DependsOn(
    typeof(ElsaSharedModule),
    typeof(AbpAspNetCoreMvcModule))]
public class ElsaServerApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(ElsaServerApiModule).Assembly);

            // Replace all AssemblyParts with SafeAssemblyParts that handle
            // ReflectionTypeLoadException (caused by Elsa 2.x's transitive dependencies
            // on older Swashbuckle versions incompatible with Swashbuckle 10.x).
            mvcBuilder.ConfigureApplicationPartManager(manager =>
            {
                var assemblyParts = manager.ApplicationParts.OfType<AssemblyPart>().ToList();
                foreach (var part in assemblyParts)
                {
                    manager.ApplicationParts.Remove(part);
                    manager.ApplicationParts.Add(new SafeAssemblyPart(part.Assembly));
                }
            });
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddElsaApiEndpoints();

        Configure<AbpAntiForgeryOptions>(options =>
        {
            options.AutoValidateFilter = type => type.Assembly != typeof(ElsaApiOptions).Assembly;
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<ElsaResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
        
        Configure<MvcOptions>(options =>
        {
            options.Conventions.Add(new ElsaControllerModelConvention());
        });
    }
}