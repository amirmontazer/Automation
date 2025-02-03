using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using AutomationTest.E2E.Pages;

namespace AutomationTest.E2E.Tests;

public class Varzesh3
{
    IWebDriver driver;
    Varzesh3Page page;

    [SetUp]
    public void Setup()
    {
        //// headless
        //ChromeOptions options = new ChromeOptions();
        //options.AddArgument("--headless");
        //driver = new ChromeDriver(options);

        driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
    }

    [Test]
    public void LiveScore()
    {
        page = new Varzesh3Page(driver);

        page.GoToVarzesh3Page()
            .Sleep(2)
            .ClickOnLiveScore();

        Assert.That(driver.Url, Does.Contain("livescore"));

        Assert.That(page.IsDisplayedLiveScoreHeader(), Is.True);

        Assert.That(driver.Title, Does.Contain("نتایج زنده"));
    }

    [Test]
    public void SearchTeamMelliIran()
    {
        page = new Varzesh3Page(driver);

        page.GoToVarzesh3Page()
            .Sleep(2)
            .ClickOnSearchButton()
            .SearchText("تیم ملی ایران")
            .Sleep(2);

        Assert.That(page.IsDisplayedNewsHeader(), Is.True);

        Assert.That(driver.Title, Does.Contain("تیم ملی ایران"));
    }

    [TearDown]
    public void TearDown()
    {
        driver.Dispose();
        driver.Quit();
    }
}