using Microsoft.Playwright;
using System;
using System.Threading.Tasks;

var url = @"https://www.mirrormedia.mg/story/20260130fin002";
var titleXPathExpression = @"//*[starts-with(@class, 'normal__Title')]";
using var playwright = await Playwright.CreateAsync();
await using var browser = await playwright.Chromium.LaunchAsync(new()
{
    Headless = false ,
});
var context = await browser.NewContextAsync();
var page = await context.NewPageAsync();
await page.GotoAsync(url);
var titleLocator = page.Locator($"xpath={titleXPathExpression}");
Console.WriteLine($"The locator with XPath Expression {titleXPathExpression} can be found where its title is {await titleLocator.InnerTextAsync()}");


Console.WriteLine("Press any key to exit...");
Console.ReadKey();
