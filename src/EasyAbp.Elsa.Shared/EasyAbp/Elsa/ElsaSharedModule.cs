using Volo.Abp.Modularity;
using Volo.Abp.Localization;
using EasyAbp.Elsa.Localization;
using Volo.Abp.Authorization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace EasyAbp.Elsa;

[DependsOn(
    typeof(AbpValidationModule),
    typeof(AbpAuthorizationAbstractionsModule)
)]
public class ElsaSharedModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<ElsaSharedModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Add<ElsaResource>("en")
                .AddBaseTypes(typeof(AbpValidationResource))
                .AddVirtualJson("/EasyAbp/Elsa/Localization");
        });

        Configure<AbpExceptionLocalizationOptions>(options =>
        {
            options.MapCodeNamespace("EasyAbp.Elsa", typeof(ElsaResource));
        });
    }
}
