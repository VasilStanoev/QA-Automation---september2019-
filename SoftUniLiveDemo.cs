using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.IO;
using System.Reflection;

namespace SeleniumBasics
{
    [TestFixture]
    public class SoftUniLiveDemo
    {
        [Test]
        public void LogoSRC()
        {
            ChromeDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)); //starting chrome

            driver.Manage().Window.Maximize(); // maximize browser window

            driver.Url = "https://softuni.bg"; //input in search bar this URL

            var logo = driver.FindElement(By.XPath(@"//*[@id=""page-header""]/div[1]/div/div/div[1]/a/img[1]")); //initialize logo by XPath

            var imageSrc = logo.GetAttribute("src"); //initialize image by SRC

            driver.Quit(); //closing Chrome

            Assert.AreEqual("https://softuni.bg/content/images/svg-logos/software-university-logo.svg", imageSrc); 
            //asser are equal 
        }

        [Test]
        public void LoginWithValidCreadentials()
        {
            ChromeDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)); //starting chrome

            driver.Manage().Window.Maximize(); // maximize browser window

            driver.Url = "https://softuni.bg"; //input in search bar this URL

            var loginButton = driver.FindElement(By.XPath(@"//*[@id=""header-nav""]/div[2]/ul/li[2]/span/a")); //initialize loginButton

            loginButton.Click(); //click on loginButton

            var userNameField = driver.FindElement(By.Id("username")); //initialize usernameField

            userNameField.SendKeys("vasilstanoev"); //input username in usernameField

            var passwordField = driver.FindElement(By.Id("password")); //initialize passwordField

            passwordField.SendKeys("94040245"); //input password in passwordField

            var enterButton = driver.FindElement(By.XPath(@"/html/body/main/div[2]/div/div[2]/div[1]/form/div[4]/input")); //initializeEnterButton

            enterButton.Click(); //click on enterButton

            driver.Quit(); //close browser
        }
    }
}
