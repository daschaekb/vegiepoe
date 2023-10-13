using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests.Pages;

public class BasketPage
{
    private IWebDriver driver;
    private WebDriverWait wait;

    public BasketPage(IWebDriver driver, WebDriverWait wait)
    {
        this.driver = driver;
        this.wait = wait;
    }
    private By chooseDeliveryType = By.CssSelector("button[class*='delivery__profiles-change-btn']");
    private By chooseCourierDelivery = By.CssSelector("li[class$='pointer']");
    
    public void ChooseCourierDelivery()
    {
        //9. Выбрать место и способ доставки (клик по ссылке)
        driver.FindElement(chooseDeliveryType).Click();
        //10. Выбрать курьерскую доставку
        driver.FindElement(chooseCourierDelivery).Click();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
    }
}