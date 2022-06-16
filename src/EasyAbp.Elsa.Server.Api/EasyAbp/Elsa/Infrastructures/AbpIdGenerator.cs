using Elsa.Services;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;

namespace EasyAbp.Elsa.Infrastructures;

public class AbpIdGenerator : IIdGenerator, ISingletonDependency
{
    private readonly IGuidGenerator _guidGenerator;

    public AbpIdGenerator(IGuidGenerator guidGenerator)
    {
        _guidGenerator = guidGenerator;
    }
        
    public virtual string Generate()
    {
        return _guidGenerator.Create().ToString();
    }
}