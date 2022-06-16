using Volo.Abp.Reflection;

namespace EasyAbp.Elsa.Permissions
{
    public class ElsaPermissions
    {
        public const string GroupName = "EasyAbp.Elsa";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(ElsaPermissions));
        }

        public class ElsaManagement
        {
            public const string Default = GroupName + ".ElsaManagement";
        }
    }
}