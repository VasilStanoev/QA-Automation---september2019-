using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Reflection;
using System.Threading;

namespace Homework_SELENIUM_ADVANCED
{
    public class LiveDemo
    {
        private ChromeDriver _driver;
        private WebDriverWait _wait;

        [SetUp]

        public void ClassInit()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));//Init chrome driver
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(2));//init  wait
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);//define wait time
        }

        [Test]

        public void Test1LiveDemo()
        {
            _driver.Navigate().GoToUrl("http://automationpractice.com/index.php?controller=authentication&back=my-account");//Open page

            var emailInput = _driver.FindElement(By.Id("email_create"));//Finding element
            //element ID = email_create
            emailInput.SendKeys("vasilvasilev@abv.bg");//input Email

            var createAccButton = _driver.FindElement(By.Id("SubmitCreate"));//Finding element
            //element ID = SubmitCreate
            createAccButton.Click();//Click on button

            var radioButtonGender =  _wait.Until(d => d.FindElements(By.XPath("//div[@class='radio']//input")));//Finding radio buttonS 
            radioButtonGender[0].Click();//Click on first radio button

            var firstNameField = _driver.FindElement(By.Id("customer_firstname"));//Finding element
            //element ID = customer_firstname
            firstNameField.SendKeys("vasil");//input firstName

            var lastNameField = _driver.FindElement(By.Id("customer_lastname"));//Finding element
            //element ID = customer_lastname
            lastNameField.SendKeys("stanoev");//input lastName

            var passWordField = _driver.FindElement(By.Id("passwd"));//Finding element
            //element ID = passwd
            passWordField.SendKeys("123567");//input password

            var dateDD = _driver.FindElement(By.Id("days"));//Finding DROP-DOWN element
            //element ID = days
            SelectElement date = new SelectElement(dateDD);//initialize DROP-DOWN element
            date.SelectByValue("2");//Select value

            var monthDD = _driver.FindElement(By.Id("months"));//Finding DROP-DOWN element
            //element ID = month
            SelectElement months = new SelectElement(monthDD);//initialize DROP-DOWN element
            months.SelectByValue("4");//Select value

            var yearDD = _driver.FindElement(By.Id("years"));//Finding DROP-DOWN element
            //element ID = years
            SelectElement years = new SelectElement(yearDD);//initialize DROP-DOWN element
            years.SelectByValue("1994");//Select value

            var firstNameSecTime = _driver.FindElement(By.Id("firstname"));
            //element ID = firstname
            firstNameSecTime.SendKeys("Vasil");//input firstName

            var secondNameSecTime = _driver.FindElement(By.Id("lastname"));
            //element ID = lastname
            secondNameSecTime.SendKeys("Stanoev");//input lastName

            //var companyField = _driver.FindElement(By.Id("company"));
            //companyField.SendKeys("SoftUni");

            var addressField = _driver.FindElement(By.Id("address1"));//Finding element
            //element ID = address1
            addressField.SendKeys("str.Plovdiv");//input address

            var addressFieldSec = _driver.FindElement(By.Id("address2"));//Finding element
            //element ID = address2
            addressFieldSec.SendKeys("ap");//input address

            var cityField = _driver.FindElement(By.Id("city"));//Finding element
            //element ID = city
            cityField.SendKeys("Plovdiv");//input city

            var stateDD = _driver.FindElement(By.Id("id_state"));//Finding DROP-DOWN element
            //element ID = id_state
            SelectElement state = new SelectElement(stateDD);//initialize DROP-DOWN element
            state.SelectByValue("2");//Select value

            var zipCode = _driver.FindElement(By.Id("postcode"));//Finding element
            //element ID = postcode
            zipCode.SendKeys("99555");//input zipCode

            var phoneNum = _driver.FindElement(By.Id("phone_mobile"));//Finding element
            //element ID = phone_mobile
            phoneNum.SendKeys("1235");//input phoneNumber

            var alias = _driver.FindElement(By.Id("alias"));//Finding element
            //element ID = alias
            Type(alias, "Home");//Typing in alias field

            var registerButton = _driver.FindElement(By.Id("submitAccount"));//Finding element
            //element ID = sublimAccount
            registerButton.Click();//Click on element

        }

        [TearDown]

            public void TeadDown()
        {
            _driver.Quit();//after every test driver is quitting
        }

        private void Type(IWebElement element, string text)//use element and typing in element
        {
            element.Clear();//Cleaning field
            element.SendKeys(text);//Typing in element
        }
    }
}
