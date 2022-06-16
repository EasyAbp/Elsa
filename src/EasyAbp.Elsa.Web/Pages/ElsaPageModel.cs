using EasyAbp.Elsa.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace EasyAbp.Elsa.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class ElsaPageModel : AbpPageModel
{
    protected ElsaPageModel()
    {
        LocalizationResourceType = typeof(ElsaResource);
        ObjectMapperContext = typeof(ElsaWebModule);
    }
}
