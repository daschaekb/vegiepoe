using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Roaming;

    public class RoamingTests
    {
        //Открыть браузер
        //Перейти на страницу: https://qa-course.kontur.host/roaming

        //Найти поле ввода Ваша организация id="Company"
        //var companyInput = driver.FindElement(By.Id("Company"));
        //Ввести название
        //var company = "";
        //driver.FindElement(By.Id("Company")).SendKeys(company);

        //Найти поле ввода ИНН id="Inn"
        //var innInput = driver.FindElement(By.Id("Inn"));
        //Ввести ИНН
        //var inn = "";
        //driver.FindElement(By.Id("Inn")).SendKeys(inn);

        //Найти поле ввода КПП id="Kpp"
        //var kppInput = driver.FindElement(By.Id("Kpp"));
        //Ввести КПП
        //var kpp = "";
        //driver.FindElement(By.Id("Kpp")).SendKeys(kpp);

        //Найти поле ввода ФИО id="Name"
        //var nameInput = driver.FindElement(By.Id("Name"));
        //Ввести ФИО
        //var name = "";
        //driver.FindElement(By.Id("Name")).SendKeys(name);

        //Найти поле ввода e-mail id="Email"
        // var emailInput = driver.FindElement(By.Id("Email"));
        //Ввести e-mail
        //var email = "";
        //driver.FindElement(By.Id("Email")).SendKeys(email);

        //Найти поле ввода Телефон id="Phone"
        //var phoneInput = driver.FindElement(By.Id("Phone"));
        //Ввести телефон
        //var phone = "";
        //driver.FindElement(By.Id("Phone")).SendKeys(phone);

        //Найти кнопку "Следующий шаг" class="btn btn-lg btn-lng btn-third js-roaming-next-step-button"
        //var buttonNextStep = driver.FindElement(By.ClassName("btn btn-lg btn-lng btn-third js-roaming-next-step-button"));
        //Нажать кнопку "Следующий шаг"
        //driver.FindElement(By.ClassName("btn btn-lg btn-lng btn-third js-roaming-next-step-button")).Click();


        //Проверить, что появился текст: "Хорошо, мы пришлём имя для вашего мальчика на e-mail:" class name="result-text"
        //var resultText = driver.FindElement(By.ClassName("result-text"));
        //Проверить, что появился текст: "Хорошо, мы пришлём имя для вашей девочки на e-mail:" class name="result-text"
        //var resultText = driver.FindElement(By.ClassName("result-text"));
        //Проверить, что e-mail совпадает с тем, что ввели class name = "your-email"
        //var resultEmail = driver.FindElement(By.ClassName("your-email"));
        //Проверить, что появилась ссылка "Указать другой e-mail"
        //var linkAnotherEmail = driver.FindElement(By.LinkText("указать другой e-mail"));
        [SetUp]
        public void SetUp()
        {
            //Открыть браузер, развернуть на полный экран
            var options = new ChromeOptions();
            options.AddArgument("start-maximized");
            driver = new ChromeDriver(options);
        }

        private ChromeDriver driver;
        private string urlRoaming = "https://qa-course.kontur.host/roaming";
        private By companyInputLocator = By.Id("Company");
        private By innInputLocator = By.Id("Inn");
        private By kppInputLocator = By.Id("Kpp");
        private By nameInputLocator = By.Id("Name");
        private By emailInputLocator = By.Id("Liame");
        private By phoneInputLocator = By.Id("Phone");
        private By buttonNextStepLocator = By.CssSelector("input[class='btn btn-lg btn-lng btn-third js-roaming-next-step-button']");
        private By resultTextLocator = By.CssSelector("div[class='progress active']");
        private By companyFullFieldLocator = By.CssSelector("span[data-valmsg-for='Company']");
        private By innFullFieldLocator = By.CssSelector("span[data-valmsg-for='Inn']");
        private By emailFullFieldLocator = By.CssSelector("span[data-valmsg-for='Liame']");
        private By fileUploadButtonLocator = By.CssSelector("input[id='file-upload-button']");

        [Test]
        public void StepOne_Success()
        {
            var expectedResultText = "2";
            //var expectedResultButton = driver.FindElement(fileUploadButtonLocator);

            driver.Navigate().GoToUrl(urlRoaming);
            
            var companyInput = driver.FindElement(companyInputLocator);
            var company = "Абрикос";
            driver.FindElement(companyInputLocator).SendKeys(company);

            var innInput = driver.FindElement(innInputLocator);
            var inn = "123";
            driver.FindElement(innInputLocator).SendKeys(inn);

            var kppInput = driver.FindElement(kppInputLocator);
            var kpp = "123";
            driver.FindElement(kppInputLocator).SendKeys(kpp);

            var nameInput = driver.FindElement(nameInputLocator);
            var name = "ФИО";
            driver.FindElement(nameInputLocator).SendKeys(name);

            var emailInput = driver.FindElement(emailInputLocator);
            var email = "test@mail.ru";
            driver.FindElement(emailInputLocator).SendKeys(email);

            var phoneInput = driver.FindElement(phoneInputLocator);
            var phone = "3435446879";
            driver.FindElement(phoneInputLocator).SendKeys(phone);

            var buttonNextStep =
                driver.FindElement(buttonNextStepLocator);
            driver.FindElement(buttonNextStepLocator).Click();
            
           // Assert.Multiple(() =>
            //{
                //Assert.IsFalse(driver.FindElement(companyFullFieldLocator).Displayed,
                    //"Ожидали, что ошибка 'Заполните поле' огранизация не появится");
              //  Assert.IsFalse(driver.FindElement(innFullFieldLocator).Displayed,
                //    "Ожидали, что ошибка 'Заполните поле' ИНН не появится");
                //data-valmsg-for="Liame"
                
               //Assert.IsTrue(driver.FindElement(emailFullFieldLocator).Displayed,
                // "Ожидали, что ошибка 'Заполните поле' e-mail не появится");
               // var resultText = driver.FindElement(resultTextLocator);
               // Assert.IsTrue(driver.FindElement(resultTextLocator).Displayed,
               //     "Переход на шаг 2 не произошел"); 
              //  Assert.AreEqual(expectedResultText, driver.FindElement(resultTextLocator).Text, 
               //     "Неверный шаг");
             //  var resultButton = driver.FindElement(fileUploadButtonLocator);
             //  Assert.IsTrue(driver.FindElement(fileUploadButtonLocator).Displayed,
                     //  "Переход на шаг 2 не произошел"); 
              // Assert.AreEqual(expectedResultButton, driver.FindElement(fileUploadButtonLocator), 
                 //    "Неверный шаг");
              // });

            
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)); 
            //wait.Until(e => e.FindElement(resultTextLocator)); 

        }   


        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

    }