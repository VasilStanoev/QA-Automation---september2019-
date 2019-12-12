using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Reflection;

namespace HomeWork
{
    [TestFixture]
    class AutomationPracticeRegistration
    {
        [Test]//This test should be update soon as possible
        public void automateRegistration()
        {
            var driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)); //starting chrome
            driver.Url = "http://automationpractice.com/index.php"; //browsing to site

            var singIn = driver.FindElementByCssSelector(".login");//finding the element

            singIn.Click();//click on element

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);//

            var createAcc = driver.FindElement(By.Id("email_create"));//finding the element
            //html/body/div/div[2]/div/div[3]/div/div/div[1]/form/div/div[2]/input
            //*[@id="email_create"]
            createAcc.SendKeys("vasilstanoev@abv.bg");//writing in E-MailField

            var createAccButton = driver.FindElement(By.Id(@"SubmitCreate"));//finding the element
            //id="SubmitCreate"
            createAccButton.Click();

            var header = driver.FindElement(By.TagName("h1"));//finding the element


            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //!!!!This is EXPLICIT WAIT wait unitl the time a particular condition //Make RECALL TO BROWSER FOR THIS ELEMENT


            var emailText = wait.Until(ExpectedConditions.ElementExists(By.XPath("//form[@id='account-creation_form']//input[@id='email']")));//waing to find element
            var text = emailText.GetAttribute("value");
            driver.Quit();

            Assert.AreEqual("vasilstanoev@abv.bg", text);
  
        }
    }
}
