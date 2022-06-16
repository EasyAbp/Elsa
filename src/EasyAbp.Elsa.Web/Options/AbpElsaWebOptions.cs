using System;

namespace EasyAbp.Elsa.Web.Options;

public class AbpElsaWebOptions
{
    private string _serverUrl;

    /// <summary>
    /// It will fall back to the current root-url if <c>null</c>.
    /// </summary>
    public string ServerUrl
    {
        get => _serverUrl;
        set => _serverUrl = value.RemovePostFix("/");
    }
}