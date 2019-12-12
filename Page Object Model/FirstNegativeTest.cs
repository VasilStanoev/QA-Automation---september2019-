using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Reflection;
using System.Threading;


namespace SeleniumExercises
{
    class FirstNegativeTest
    {
        private ChromeDriver _driver;
        private WebDriverWait _wait;
        private RegistrationUser _user;

        [SetUp]

        public void CalssInit()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));//Init driver
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(2));//init  wait
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);//define wait time

            _user = UserFactory.CreateValidUser();//This return values from UserFactory
        }

        [Test]

        public void Test1LiveDemo()
        {
            _driver.Navigate().GoToUrl("http://automationpractice.com/index.php?controller=authentication&back=my-account#account-creation");

            var emailInput = _driver.FindElement(By.Id("email_create"));//Finding element
            //ID = email_create
            emailInput.SendKeys(_user.Email);//Getting EMail from UserFactory and write value in field
        }

        [TearDown]

        public void TeadDown()
        {
            _driver.Quit();//After every test driver is quitting
        }

        private void Type(IWebElement element, string text)//use element and typing in element
        {
            element.Clear();//Cleaning field
            element.SendKeys(text);//Typing in element
        }
    }
}