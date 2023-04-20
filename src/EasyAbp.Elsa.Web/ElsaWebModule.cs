using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using EasyAbp.Elsa.Localization;
using EasyAbp.Elsa.Web.Menus;
using Volo.Abp.AspNetCore.Mvc.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;
using Volo.Abp.VirtualFileSystem;

namespace EasyAbp.Elsa.Web;

[DependsOn(
    typeof(ElsaSharedModule),
    typeof(AbpAspNetCoreMvcUiThemeSharedModule)
)]
public class ElsaWebModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.PreConfigure<AbpMvcDataAnnotationsLocalizationOptions>(options =>
        {
            options.AddAssemblyResource(typeof(ElsaResource), typeof(ElsaWebModule).Assembly);
        });

        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(ElsaWebModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpNavigationOptions>(options => { options.MenuContributors.Add(new ElsaMenuContributor()); });

        Configure<AbpVirtualFileSystemOptions>(options => { options.FileSets.AddEmbedded<ElsaWebModule>(); });

        Configure<RazorPagesOptions>(options =>
        {
            //Configure authorization.
        });
        
    }
}