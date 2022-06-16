using EasyAbp.Elsa.Permissions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace EasyAbp.Elsa.Infrastructures;

public class ElsaControllerModelConvention : IControllerModelConvention
{
    public void Apply(ControllerModel controller)
    {
        var assemblyFullName = controller.ControllerType.Assembly.FullName;

        if (assemblyFullName is null || !assemblyFullName.StartsWith("Elsa."))
        {
            return;
        }

        foreach (var selector in controller.Selectors)
        {
            selector.EndpointMetadata.Add(new AuthorizeAttribute(ElsaPermissions.ElsaManagement.Default));
        }
    }
}