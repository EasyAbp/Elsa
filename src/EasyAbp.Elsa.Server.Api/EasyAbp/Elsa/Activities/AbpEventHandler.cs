using System.Threading.Tasks;
using Elsa;
using Elsa.ActivityResults;
using Elsa.Attributes;
using Elsa.Services;
using Elsa.Services.Models;

namespace EasyAbp.Elsa.Activities;

[Activity(
    Category = "ABP framework",
    DisplayName = "Event Handler",
    Description = "(NOT IMPLEMENTED YET!) Create an ABP local/distributed event handler.",
    Outcomes = new[] { OutcomeNames.Done }
)]
public class AbpEventHandler : Activity
{
    [ActivityInput(
        Label = "Event Type",
        Hint = "Specify an ABP event type"
    )]
    public AbpEventType EventType { get; set; }

    [ActivityInput(
        Label = "ETO Type Full Name",
        Hint = "e.g. `EntityCreatedEventData<MyApp.Articles.Article>`, `MyApp.Articles.ArticleCreatedEto`"
    )]
    public string EtoTypeFullName { get; set; }

    protected override ValueTask<IActivityExecutionResult> OnExecuteAsync(ActivityExecutionContext context)
    {
        return base.OnExecuteAsync(context);
    }
    
    public enum AbpEventType
    {
        Local,
        Distributed
    }
}