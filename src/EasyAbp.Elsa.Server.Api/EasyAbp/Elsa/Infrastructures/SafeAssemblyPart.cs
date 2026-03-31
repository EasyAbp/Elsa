using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace EasyAbp.Elsa.Infrastructures;

/// <summary>
/// An AssemblyPart subclass that gracefully handles ReflectionTypeLoadException
/// when enumerating types from assemblies with incompatible dependencies
/// (e.g., Elsa 2.x types compiled against an older Swashbuckle version).
/// </summary>
public class SafeAssemblyPart : AssemblyPart, IApplicationPartTypeProvider
{
    public SafeAssemblyPart(Assembly assembly) : base(assembly)
    {
    }

    IEnumerable<TypeInfo> IApplicationPartTypeProvider.Types
    {
        get
        {
            try
            {
                return base.Types;
            }
            catch (ReflectionTypeLoadException ex)
            {
                return ex.Types.Where(t => t != null).Select(t => t!.GetTypeInfo());
            }
        }
    }
}
