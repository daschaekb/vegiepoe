using System.Globalization;
using NUnit.Framework;
using NUnit.Framework.Internal.Execution;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SeleniumTests.Pages;

namespace SeleniumTests
{
    
    public class FirstSeleniumTests : SeleniumTestBase
    {
        [Test]
        public void MyFirstSeleniumTest()
        {
            driver.Navigate().GoToUrl("https://ru.wikipedia.org/");
            IWebElement queryInput = driver.FindElement(By.Name("search"));
            IWebElement searchButton = driver.FindElement(By.Name("go"));
            queryInput.SendKeys("Selenium");
            searchButton.Click();
            
            Assert.IsTrue(driver.Title.Contains("Selenium — Википедия"), "Не перешли на страницу про Selenium");
            Assert.AreEqual("Selenium — Википедия", driver.Title, "Не перешли на страницу про Selenium");
        }

        [Test]

        public void Practice()
        {
            driver.Navigate().GoToUrl("https://www.labirint.ru/");
            var input = By.Id("search-field");
            var blocks = driver.FindElements(By.ClassName("product-padding"));
            var search = driver.FindElement(By.Name("labsearch"));
            var allGoods = driver.FindElement(By.XPath("//span[text()='Все товары']"));
            allGoods = driver.FindElement(By.CssSelector(".sorting-items.sorting-active"));
            var years = driver.FindElements(By.CssSelector("select[name='year_begin'] option:not([selected])"));
            var link = driver.FindElement(By.LinkText("Как сделать заказ"));
        }
            
        
        [Test]
        public void Labirint_AuthorizeViaMyLabirintLink_LightboxWasShown()
        {
            // Сохраним локаторы
            var myLabirintlocator = By.ClassName("top-link-main_cabinet");
            var authorizeButtonLocator =
                By.CssSelector(".dropdown-block-opened [data-sendto='authorize'].b-menu-list-title");
            var LightboxLocator = By.ClassName("lab-modal-content");
           //Перейти на страницу
           driver.Navigate().GoToUrl("https://www.labirint.ru/");
           //Навести на "Мой лабиринт" + возможно подождать раскрытия
           new Actions(driver)
               .MoveToElement(driver.FindElement(myLabirintlocator))
               .Build()
               .Perform();
           //Кликаем "Вход"
           wait.Until(ExpectedConditions.ElementIsVisible(authorizeButtonLocator)); // установила package DotNetSeleniumExtras.WaitHelpers
               driver.FindElement(authorizeButtonLocator).Click(); 
            //Проверяем, что ЛБ отобразился
           Assert.IsTrue(driver.FindElement(LightboxLocator).Displayed,"После клика на 'Вход или регистрация в Лабиринте' не отобразился ЛБ");
        }

        [Test]
        public void Labirint_FillFormsOnGuestbook_Success()
        {
            //локаторы
            var searchInArchive = By.Id("btwo");
            var fieldNameLocator = By.Name("sname");
            var fieldKeyWordsLocator = By.CssSelector("input[name=keywords]");
            var yearEndLocator = By.Name("year_end");
            var notForThisLinkLocator = By.Id("hd");
            var lightboxLocator = By.Id("notForGuestbook");
            //переходим на страницу
            driver.Navigate().GoToUrl("https://www.labirint.ru/guestbook/");
            
            //Кликнуть “Поиск в архиве”
            driver.FindElement(searchInArchive).Click();
            
            //В поле "Имя" ввести свое имя
            driver.FindElement(fieldNameLocator).SendKeys("Дарья");
            
            //В поле "Ключевые слова" ввести какой-либо текст
            driver.FindElement(fieldKeyWordsLocator).SendKeys("какой-то текст");
            
            //Очистить поле "Ключевые слова"
            driver.FindElement(fieldKeyWordsLocator).Clear();
            
            //Выбрать год окончания поиска 2019
            var selectElement = new SelectElement(driver.FindElement(yearEndLocator));
            selectElement.SelectByText("2019");
            
            //Проверить, что выбрался год окончания поиска 2019
            var selectedYear = selectElement.SelectedOption.Text;
            Assert.AreEqual("2019", selectedYear, "Неверно выбран год окончания поиска");
            
            //Кликнуть по “Для чего он не предназначен” (справа вверху формы)
            driver.FindElement(notForThisLinkLocator).Click();
            
            //Проверить видимость подсказки после клика по “Для чего он не предназначен”
            Assert.IsTrue(driver.FindElement(lightboxLocator).Displayed, "Не отобразился ЛБ 'Для чего он не предназначен'");
            
        }

        
        [Test]
        public void Locators()
        {
            driver.Navigate().GoToUrl("https://www.labirint.ru/");
            var cookiePolicyAgree = By.ClassName("js-cookie-policy-agree");
            var booksMenu = By.CssSelector("[data_event_content='Книги']");
            var allBooks = By.CssSelector("a.b-menu-list-title-first[href='/books/']"); //fixed
            var addBookInCart = By.XPath("(//*[contains(@onclick,'shopingnew')])[1]"); //fixed
            var issueOrder = By.CssSelector("a.btn-primary.btn-more");//fixed
            var beginOrder = By.CssSelector("#cart-total-default button");//fixed
            var chooseDeliveryType = By.CssSelector("button[class*='delivery__profiles-change-btn']");
            var chooseCourierDelivery = By.CssSelector("li[class$='pointer']");
            var city = By.Id("deliveryAddress");
            var cityError = By.CssSelector(".error-informer");//fixed
            var suggestedCity = By.CssSelector("ymaps[data-suggest='true']");
            //var firstDeliveryCompany = By.CssSelector("div[class^='delivery--courier-delivery'] li:first-child");
            var firstDeliveryCompany = By.ClassName("cdp-container");
            var confirm = By.ClassName("button-save");
            var courierDeliveryLightbox = By.ClassName("delivery--controls-block");
        }

        [Test]
        public void BasketPage_EnterInvalidCity_ErrorCity()
        {
            //arrange
            var homePage = new HomePage(driver, wait);
            homePage.OpenPage();
            homePage.AddBookToCard();

            var basketPage = new BasketPage(driver, wait);
            basketPage.ChooseCourierDelivery();
            
            //act
            var courier = new CourierDeliveryLightbox(driver, wait);
            courier.EnterInvalidCity();
            
            //assert
            Assert.IsTrue(courier.IsVisibleErrorCity(), "Не появилось сообщение об ошибке при вводе некорретного названия города");
        }

        [Test]
        //[Repeat(5)]
        public void BasketPage_FillAll_Success()
        {
            //arrange
            var homePage = new HomePage(driver, wait);
            homePage.OpenPage();
            homePage.AddBookToCard();

            var basketPage = new BasketPage(driver, wait);
            basketPage.ChooseCourierDelivery();
            
            //act
            var courier = new CourierDeliveryLightbox(driver, wait);
            courier.EnterValidAddress();
            courier.ChooseDeliveryCompany();
            
            //assert
            Assert.IsFalse(courier.IsVisibleLightbox(), "ЛБ с выбором доставки не закрылся");
        }

        [Test]
        public void CalendarDatePicker()
        {
            /*Сценарий:
            1. Открыть https://jqueryui.com/datepicker/
            2. Выставить дату = сегодня + 8 дней
            3. Проверить, что выставилась дата = сегодня + 8 дней*/
            //var datePicker = By.Id("datepicker");
            var date = DateTime.Today.AddDays(8);
            var expectedDate = date.ToString("d", DateTimeFormatInfo.InvariantInfo);
            driver.Navigate().GoToUrl("https://jqueryui.com/datepicker/");
            var frameElement = driver.FindElement(By.TagName("iframe"));
            driver.SwitchTo().Frame(frameElement);
            (driver as IJavaScriptExecutor).ExecuteScript("$('#datepicker').datepicker( 'setDate' , '+ 8')");
            var resultDate = (driver as IJavaScriptExecutor).ExecuteScript("return $('.hasDatepicker').val()").ToString();
            Assert.AreEqual(expectedDate, resultDate, "Дата не соответствует");
        }
       
  }
}