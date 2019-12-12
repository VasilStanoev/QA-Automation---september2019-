using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Reflection;
using System.Threading;

namespace Homework_SELENIUM_ADVANCED.InteractionTests
{
    class DraggableTests

    {
        private ChromeDriver _driver;
        private WebDriverWait _wait;

        [SetUp]

        public void ClassInit()//This init variables
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));//Init chrome web driver
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(2));//Init wait
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);//Define wait time
            _driver.Navigate().GoToUrl("https://demoqa.com/draggable/");
        }

        [Test]

        public void DragTest()
        {
            var drag = _driver.FindElement(By.Id("draggable"));//Finding element

            Actions builder = new Actions(_driver);

            builder.DragAndDropToOffset(drag, 100, 2).Build().Perform();
        }

        [Test]

        public void DragTestNegativeNum()
        {
            var drag = _driver.FindElement(By.Id("draggable"));//Finding element

            Actions builder = new Actions(_driver);

            builder.DragAndDropToOffset(drag, -100, 2-2).Build().Perform();
        }

        [TearDown]

        public void TeadDown()
        {
            _driver.Quit();
        }
    }
}
