using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace EasyAbp.Elsa;

[DependsOn(
    typeof(AbpVirtualFileSystemModule)
    )]
public class ElsaInstallerModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<ElsaInstallerModule>();
        });
    }
}
