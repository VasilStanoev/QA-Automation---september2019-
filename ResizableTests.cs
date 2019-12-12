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
    class ResizableTests
    {
        private ChromeDriver _driver;
        private WebDriverWait _wait;

        [SetUp]

        public void ClassInit()//This init variables
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));//Init chrome web driver
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(2));//Init wait
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);//Define wait time
            _driver.Navigate().GoToUrl("https://demoqa.com/resizable/");
        }

        [Test]

        public void ResizableTest()
        {
            var box = _driver.FindElement(By.Id("resizable"));//Finding box element
            double expectedboxWidth = box.Size.Width + 184;//Box element in default size + add size
            double expectedboxHeight = box.Size.Height + 184;//Box element in default size + add size

            var resizeButton = _driver.FindElement(By.XPath("//*[@id='resizable']/div[3]"));//Finding resize button

            var builder = new Actions(_driver);//Click on rezise button
            builder.DragAndDropToOffset(resizeButton, 200, 200).Perform();//Drop-down resize button, new size, new size

            double actualWidth = box.Size.Width;//indent. new width on the box
            double actualHeight = box.Size.Height;//indent. new height on the box

            Assert.AreEqual(expectedboxWidth, actualWidth, 2);//Assert are equal expect width with actual width
            Assert.AreEqual(expectedboxHeight, actualHeight, 2);//Assert are equal expect height with actual height
        }
        [TearDown]
        public void TeadDown()
        {
            _driver.Quit();
        }
    }
}
