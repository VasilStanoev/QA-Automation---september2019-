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
    class DroppableTestPositive
    {
        private ChromeDriver _driver;
        private WebDriverWait _wait;

        [SetUp]

        public void ClassInit()//This init variables
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));//Init chrome web driver
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(2));//Init wait
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);//Define wait time
            _driver.Navigate().GoToUrl("https://demoqa.com/droppable/");
        }

        [Test]

        public void PositiveTest()
        {
            var drag = _driver.FindElement(By.Id("draggable"));//Finding element
            var dropped = _driver.FindElement(By.Id("droppable"));//Finding element

            var dragX = drag.Location.X;
            var dragY = drag.Location.Y;

            var target = dropped.GetCssValue("style");//Finding element

            Actions builder = new Actions(_driver);
            builder.DragAndDrop(drag, dropped).Perform();

            var afterX = drag.Location.X;//Finding element
            var afterY = drag.Location.Y;//Finding element

            var afterColor = dropped.GetCssValue("style");//Finding element

            Assert.AreEqual(515, drag.Location.X, "X coordinates are wrong");
            Assert.AreEqual(387, drag.Location.Y, "Y coordinates are wrong");
        }

        [TearDown]

        public void TeadDown()
        {
            _driver.Quit();
        }

    }
}