using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests;

public abstract class SeleniumTestBase
{
    protected IWebDriver driver;
    protected WebDriverWait wait;
    
    [SetUp]
    public void SetUp()
    {
        var options = new ChromeOptions();
        options.AddArgument("start-maximized");
        options.AddArgument("--incognito"); //Открыть в режиме инкогнито
        driver = new ChromeDriver(options);
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10)); //явное ожидание подходит для всего
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5); //неявное ожидание подходит только для появление элемента на странице
    }
    
    [TearDown]
    public void TearDown()
    {
        driver.Quit();
        driver = null;
    }    
}