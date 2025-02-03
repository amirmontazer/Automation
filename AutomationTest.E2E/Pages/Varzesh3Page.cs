using AutomationTest.E2E.Constants;
using OpenQA.Selenium;

namespace AutomationTest.E2E.Pages;

public class Varzesh3Page
{
    IWebDriver driver;
    public Varzesh3Page(IWebDriver driver)
    {
        this.driver = driver;
    }

    public Varzesh3Page GoToVarzesh3Page()
    {
        driver.Navigate().GoToUrl(GlobalConstant.BaseUrl);
        return this;
    }

    public Varzesh3Page ClickOnLiveScore()
    {
        IWebElement liveResultsLink = driver.FindElement(By.XPath("//a[contains(text(), 'نتایج زنده')]"));
        liveResultsLink.Click();
        return this;
    }

    public bool IsDisplayedLiveScoreHeader()
    {
        IWebElement liveMatchesHeader = driver.FindElement(By.XPath("//h1[contains(text(), 'نتایج زنده')]"));
        return liveMatchesHeader.Displayed;
    }

    public Varzesh3Page ClickOnSearchButton()
    {
        driver.FindElement(By.ClassName("search-btn")).Click();
        return this;
    }

    public Varzesh3Page SearchText(string text)
    {
        IWebElement searchBox = driver.FindElement(By.Id("main-search"));
        searchBox.SendKeys(text);
        searchBox.SendKeys(Keys.Enter);
        return this;
    }

    public bool IsDisplayedNewsHeader()
    {
        IWebElement liveMatchesHeader = driver.FindElement(By.XPath("//div[contains(text(), 'اخبار')]"));
        return liveMatchesHeader.Displayed;
    }

    public Varzesh3Page Sleep(int sec)
    {
        Thread.Sleep(sec * 1000);
        return this;
    }
}
