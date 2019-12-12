using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Reflection;
using System.Threading;

namespace Homework_SELENIUM_ADVANCED
{
    class ActionsLiveDemo
    {
        private ChromeDriver _driver;
        private WebDriverWait _wait;

        [SetUp]

        public void ClassInit()//This initialize variables
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));//Init driver
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(2));//init  wait
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);//define wait time
            _driver.Navigate().GoToUrl("https://demoqa.com/droppable/");
        }

        [Test]

        public void EnterKey()
        {
            var draggable = _driver.FindElement(By.Id("draggable"));//Finding element
            var target = _driver.FindElement(By.Id("droppable"));//Finding element

            var dragX = draggable.Location.X;
            var dragY = draggable.Location.Y;

            var targetClor = target.GetCssValue("style");//Finding element

            Actions builder = new Actions(_driver);
            builder.DragAndDrop(draggable, target).Perform();
            //builder.DragAndDropToOffset(draggable, 145, 25).Perform(); This work like upper!!!
            //builder.MoveToElement(draggable).ClickAndHold().MoveByOffset(145, 25).Release().Perform(); This work like upper!!!

            var afterX = draggable.Location.X;//Finding element
            var afterY = draggable.Location.Y;//Finding element

            var afterColor = target.GetCssValue("style");//Finding element

            Assert.AreEqual(515, draggable.Location.X, "X coordinates are wrong");
            Assert.AreEqual(387, draggable.Location.Y, "Y coordinates are wrong");
        }

        [TearDown]

        public void TeadDown()
        {
            _driver.Quit();
        }
    }
}