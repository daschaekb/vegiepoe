using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;


namespace SeleniumTests.Pages;

public class CourierDeliveryLightbox
{
    private IWebDriver driver;
    private WebDriverWait wait;

    public CourierDeliveryLightbox(IWebDriver driver, WebDriverWait wait)
    {
        this.driver = driver;
        this.wait = wait;
    }
    
    private By city = By.Id("deliveryAddress");
    private By cityError = By.CssSelector(".error-informer");
    private By suggestedCity = By.CssSelector("ymaps[data-suggest='true']");
    //private By firstDeliveryCompany = By.CssSelector("div[class^='delivery--courier-delivery'] li:first-child");
    private By firstDeliveryCompany = By.ClassName("cdp-container");
    private By confirm = By.ClassName("button-save");
    private By courierDeliveryLightbox = By.ClassName("delivery--controls-block");
    private By loader = By.CssSelector("img['loading-height.set-height']");

  public void EnterInvalidCity()
    {
        //11. Ввести адрес некорректный
        driver.FindElement(city).SendKeys("^&()");
        //12. Убираем фокус с поля, например, кликаем Tab
        //driver.FindElement(city).SendKeys(Keys.Tab);
    }
    
    public void EnterValidAddress()
    {

        wait.Until(ExpectedConditions.ElementIsVisible(cityError));
        //13. Удалить весь текст
        driver.FindElement(city).Clear();
        //14. Ввести корректный адрес
        driver.FindElement(city).SendKeys("Первомайская улица, 77, Екатеринбург");
        //15. Выбрать предложенный вариант из выпадающего списка
        //wait.Until(ExpectedConditions.ElementIsVisible(suggestedCity));
        //driver.FindElement(suggestedCity).Click();
        // Убираем фокус с поля, например, кликаем Tab
        driver.FindElement(city).SendKeys(Keys.Tab);

    }
    
    public void ChooseDeliveryCompany()
    {
        //16. Выбрать конкретную службу доставки
        //wait.Until(ExpectedConditions.ElementIsVisible(firstDeliveryCompany));
        driver.FindElement(firstDeliveryCompany).Click();
        //17. Подтвердить выбор (здесь блок с доставкой должен закрыться)
        driver.FindElement(confirm).Click();
    }

    public bool IsVisibleErrorCity()
    {
        return driver.FindElement(cityError).Displayed;
    }
    
    public bool IsVisibleLightbox()
    {
        return driver.FindElement(courierDeliveryLightbox).Displayed;
    }

}