using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using EasyAbp.Elsa.Web.Options;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace EasyAbp.Elsa.Web.Pages.Elsa;

public class Elsa : PageModel
{
    private Dictionary<string, string> AbpLangToElsaLangMapping { get; } = new()
    {
        { "zh-Hans", "zh-CN" },
        { "zh-Hant", "zh-CN" },
        { "nl", "nl-NL" },
    };

    private AbpElsaWebOptions Options { get; }

    public string ServerUrl { get; set; }

    public Elsa(IOptions<AbpElsaWebOptions> options)
    {
        Options = options.Value;
    }

    public virtual Task OnGetAsync()
    {
        ServerUrl = Options.ServerUrl;

        return Task.CompletedTask;
    }

    public virtual Task<string> GetLangOrDefaultAsync()
    {
        var abpLanguageName = CultureInfo.CurrentUICulture.Name;

        return Task.FromResult(AbpLangToElsaLangMapping.ContainsKey(abpLanguageName)
            ? AbpLangToElsaLangMapping[abpLanguageName]
            : abpLanguageName);
    }

    public virtual Task<string> GetServerUrlOrDefaultAsync()
    {
        return Task.FromResult(ServerUrl ?? $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}");
    }
}