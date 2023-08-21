using System.Threading.Tasks;
using EasyAbp.Elsa.Localization;
using EasyAbp.Elsa.Permissions;
using Volo.Abp.UI.Navigation;

namespace EasyAbp.Elsa.Web.Menus;

public class ElsaMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var l = context.GetLocalizer<ElsaResource>();
            
        if (await context.IsGrantedAsync(ElsaPermissions.ElsaManagement.Default))
        {
            context.Menu.GetAdministration().AddItem(new ApplicationMenuItem(ElsaMenus.Name,
                displayName: l["Menu:Elsa"], "~/Elsa", icon: "fa fa-code"));
        }
    }
}
