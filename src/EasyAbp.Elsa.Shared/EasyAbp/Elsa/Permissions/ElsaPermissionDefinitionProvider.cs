using EasyAbp.Elsa.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace EasyAbp.Elsa.Permissions
{
    public class ElsaPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(ElsaPermissions.GroupName, L("Permission:Elsa"));

            myGroup.AddPermission(ElsaPermissions.ElsaManagement.Default, L("Permission:ElsaManagement"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<ElsaResource>(name);
        }
    }
}
