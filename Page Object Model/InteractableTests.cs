using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Reflection;
using System.Threading;

namespace SeleniumExercises
{
    [TestFixture]
    class InteractableTests
    {
        private ChromeDriver _driver;
        private WebDriverWait _wait;
        private RegistrationUser _user;

        [SetUp]

        public void CalssInit()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));//Init driver
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(2));//Init wait

        }

        [Test]

        public void ResizeBox()
        {
            _driver.Url = "https://demoqa.com/resizable/";//Go to URL

            var box = _driver.FindElement(By.Id("resizable"));//Finding box element
            double expectedboxWidth = box.Size.Width + 84;//Box element in expected widht
            double expectedboxHeight = box.Size.Height + 84;//Box element with expected height

            var resizeButton = _driver.FindElement(By.XPath("//*[@id='resizable']/div[3]"));//Finding resize button

            var builder = new Actions(_driver);//Click on rezise button
            builder.DragAndDropToOffset(resizeButton, 100, 100).Perform();//Drop-down resize button

            double actualWidth = box.Size.Width;//indent. new width on the box
            double actualHeight = box.Size.Height;//indent. new height on the box

            Assert.AreEqual(expectedboxWidth, actualWidth, 2);//Assert are equal expect width with actual width
            Assert.AreEqual(expectedboxHeight, actualHeight, 2);//Assert are equal expect height with actual height
        }

        [TearDown]

        public void TearDown()
        {
            _driver.Quit();//After every test driver is quitting
        }
    }
}