# Elsa

[![ABP version](https://img.shields.io/badge/dynamic/xml?style=flat-square&color=yellow&label=abp&query=%2F%2FProject%2FPropertyGroup%2FAbpVersion&url=https%3A%2F%2Fraw.githubusercontent.com%2FEasyAbp%2FElsa%2Fmaster%2FDirectory.Build.props)](https://abp.io)
[![NuGet](https://img.shields.io/nuget/v/EasyAbp.Elsa.Shared.svg?style=flat-square)](https://www.nuget.org/packages/EasyAbp.Elsa.Shared)
[![NuGet Download](https://img.shields.io/nuget/dt/EasyAbp.Elsa.Shared.svg?style=flat-square)](https://www.nuget.org/packages/EasyAbp.Elsa.Shared)
[![Discord online](https://badgen.net/discord/online-members/xyg8TrRa27?label=Discord)](https://discord.gg/xyg8TrRa27)
[![GitHub stars](https://img.shields.io/github/stars/EasyAbp/Elsa?style=social)](https://www.github.com/EasyAbp/Elsa)

An Abp module integrates [Elsa workflows](https://github.com/elsa-workflows/elsa-core) and provides some preset Elsa activities for the ABP framework.

![UI](/docs/images/Workflows.png)
![UI](/docs/images/Activities.png)

## Installation

1. Install the following NuGet packages. ([see how](https://github.com/EasyAbp/EasyAbpGuide/blob/master/docs/How-To.md#add-nuget-packages))

    * EasyAbp.Elsa.Server.Api _(install at the server host project)_
    * EasyAbp.Elsa.Web _(install at the UI host project)_

2. Add `DependsOn(typeof(ElsaXxxModule))` attribute to configure the module dependencies. ([see how](https://github.com/EasyAbp/EasyAbpGuide/blob/master/docs/How-To.md#add-module-dependencies))

3. Install an Elsa persistence provider package for the server project, see https://elsa-workflows.github.io/elsa-core/docs/next/installation/installing-persistence.

## Usage

1. Configure the server host project.
    ```c#
    context.Services.AddElsa(options =>
    {
        options.UseEntityFrameworkPersistence(
            x => x.UseSqlServer(configuration.GetConnectionString("Default")));
        options.AddConsoleActivities();
        options.AddSomeOtherActives();
        options.AddAbpActivities(); // Add if you need the preset activities for ABP.
    });
    ```

2. Configure the Web host project.
    ```c#
    Configure<AbpElsaWebOptions>(options =>
    {
        // The ServerUrl will fall back to the current root-url if null.
        options.ServerUrl = "https://myapp.com";
    });
    ```

3. Grant the `EasyAbp.Elsa.ElsaManagement` permission to admin users.

> Please notice this module has implemented Elsa's multi-tenant support.
> That means tenant admins can create their workflows with tenant-isolated.

## Road map

Todo.