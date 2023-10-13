using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SeleniumTests.Pages;

public class HomePage
{
    private IWebDriver driver;
    private WebDriverWait wait;

    public HomePage(IWebDriver driver, WebDriverWait wait)
    {
        this.driver = driver;
        this.wait = wait;
    }

    private string url = "https://www.labirint.ru/";
    private By cookiePolicyAgree = By.ClassName("js-cookie-policy-agree");
    private By booksMenu = By.CssSelector("[data-event-content='Книги']");
    private By allBooks = By.CssSelector("a.b-menu-list-title-first[href='/books/']"); 
    private By addBookInCart = By.XPath("(//*[contains(@onclick,'shopingnew')])[1]"); 
    private By issueOrder = By.CssSelector("a.btn-primary.btn-more");
    private By beginOrder = By.CssSelector("#cart-total-default button");
    private By closeNotification = By.CssSelector("div.responsive-children span.fright.btn.btn-primary.btn-middle");

    public void OpenPage()
    {
        //1. Открыть страницу
        driver.Navigate().GoToUrl(url);
            
        //2. Принять куки
        driver.FindElement(cookiePolicyAgree).Click();
        //Альтернативное:
        //wait.Until(ExpectedConditions.ElementExists(cookiePolicyAgree));
        //(driver as IJavaScriptExecutor).ExecuteScript("$('.js-cookie-policy-agree').click();");
    }
    
    public void AddBookToCard()
    {
        //3. Навести на элемент в меню "Книги"
        new Actions(driver)
            .MoveToElement(driver.FindElement(booksMenu))
            .Build()
            .Perform();
        //4. Дождаться отображения "Все книги"
        wait.Until(ExpectedConditions.ElementIsVisible(allBooks));
        //5. Кликнуть по "Все книги"
        driver.FindElement(allBooks).Click();
        //6. Добавить первую книгу в корзину
        driver.FindElement(addBookInCart).Click();
        //7. Кликнуть по "Оформить" (там кнопка в корзину превратилась в оформить)
        driver.FindElement(issueOrder).Click();
        //Закрыть уведомление о предновогодних сроках доставки
        driver.FindElement(closeNotification).Click();
        //8. Перейти к оформлению
        driver.FindElement(beginOrder).Click();
    }

}