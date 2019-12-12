using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;

namespace HomeWork
{
    [TestFixture]
    public class GoogleSearch
    {
        [Test]
        public void browserSearch()
        {
            ChromeDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)); //starting chrome

            driver.Manage().Window.Maximize();// maximize browser window

            driver.Url = "https://www.google.com/"; //browsing to site

            var searchField = driver.FindElementByCssSelector(".gLFyf");//finding the element
            searchField.SendKeys("Selenium"); //writing in searchField

            searchField.SendKeys(Keys.Enter); //click Enter

            var link = driver.FindElement(By.XPath(@"//*[@id=""rso""]/div[1]/div/div/div/div[1]/a[1]/h3"));//finding the element
            ////*[@id="rso"]/div[1]/div/div/div/div[1]/a[1]/h3

            link.Click();//click on element

            string pageTitle = driver.Title; //get title of the page

            Assert.AreEqual("Selenium - Web Browser Automation", pageTitle);

            driver.Close();//closing window
        }
    }
}
