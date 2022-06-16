using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace AbpElsaSample;

[Dependency(ReplaceServices = true)]
public class AbpElsaSampleBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "AbpElsaSample";
}
