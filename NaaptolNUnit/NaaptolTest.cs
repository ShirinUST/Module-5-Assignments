using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaaptolNUnit
{
    [TestFixture]
    internal class NaaptolTest//:PageTest
    {
        //[SetUp]
        //public async Task SetUp()
        //{
        //    Console.WriteLine("Opened Browser");
        //    await Page.GotoAsync("https://www.naaptol.com/");
        //    Console.WriteLine("Page Loaded");

        //}
        //[Test]
        //public async Task SearchTest()
        //{
        //    await Expect(Page).ToHaveURLAsync("https://www.naaptol.com/");
        //    await Console.Out.WriteLineAsync("On home page");

        //    await Page.FillAsync("#header_search_text", "eyewear");
        //    await Console.Out.WriteLineAsync("Typed");

        //    //await Page.Keyboard.PressAsync("Enter");
        //    await Page.Keyboard.DownAsync("Enter");
        //    await Page.Keyboard.UpAsync("Enter");
        //    await Console.Out.WriteLineAsync("New Page");
        //    await Expect(Page).ToHaveTitleAsync(" Welcome to naaptol :- Search Result for eyewear");
        //    await Console.Out.WriteLineAsync("eyewear");
        //}

        [Test]
        //Manual instance
        public async Task Test1()
        {
            //playwright startup
            using var playwright = await Playwright.CreateAsync();

            //launch browser
            await using var browser = await playwright.Chromium.LaunchAsync(
                new BrowserTypeLaunchOptions
                {
                    Headless = false
                });

            //page instance
            var context = await browser.NewContextAsync();
            var page = await context.NewPageAsync();

            Console.WriteLine("Opened Browser");
            await page.GotoAsync("https://www.naaptol.com/");
            Console.WriteLine("Page Loaded");

            //string title = await page.TitleAsync();
            //Console.WriteLine(title);
            await page.FillAsync("#header_search_text", "eyewear");
            await page.Locator("(//div[@class='search'])[2]").ClickAsync();
            await Console.Out.WriteLineAsync("Typed");

            await page.Keyboard.PressAsync("Enter");
       
            await Console.Out.WriteLineAsync("New Page");
            Thread.Sleep(5000);
            //await Expect(page).ToHaveTitleAsync(" Welcome to naaptol :- Search Result for eyewear");
            await Console.Out.WriteLineAsync("eyewear");


        }
    }
}
