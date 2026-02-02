using Microsoft.Playwright;
using Microsoft.Playwright.Xunit.v3;
using System.Reflection;
using Xunit.Sdk;
using FactAttribute = Xunit.FactAttribute;

namespace PlaywrightTests;

public class UnitTest1 : PageTest
{
    public override async ValueTask InitializeAsync()
    {
        await base.InitializeAsync().ConfigureAwait(false);
        await Context.Tracing.StartAsync(new()
        {
            Title = $"{TestContext.Current.Test.TestDisplayName}",
            Screenshots = true ,
            Snapshots = true ,
            Sources = true
        });
    }

    public override async ValueTask DisposeAsync()
    {
        var testName = TestContext.Current.Test.TestDisplayName ?? "UnknownTest";
        await Context.Tracing.StopAsync(new()
        {
            Path = Path.Combine(
                Environment.CurrentDirectory ,
                "playwright-traces" ,
               $"{testName}.zip"
            )
        });
        await base.DisposeAsync().ConfigureAwait(false);
    }

    [Fact] // 現在可以直接使用 Fact 了
    public async Task GetStartedLink()
    {
        await Page.GotoAsync("https://playwright.dev/dotnet/docs/intro");
        // 測試代碼...
    }
}
