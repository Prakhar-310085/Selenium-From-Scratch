using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Support.UI;

namespace Selenium_Learning
{
    public class Locators
    {
        IWebDriver driver;
        
        [SetUp] 
        public void StartBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            //driver.Manage().Timeouts().ImplicitWait= TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();

        }
        [Test]
        public void LocatorsIdentififcation()
        {
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
            //using ID, Name
            driver.FindElement(By.Id("username")).SendKeys("abcd");
            driver.FindElement(By.Id("username")).Clear();
            driver.FindElement(By.Id("username")).SendKeys("testuser");
            driver.FindElement(By.Name("password")).SendKeys("Password");
            
            driver.FindElement(By.XPath("//div[@class='form-group'][5]/label/span/input")).Click();
            // using CSS
            //driver.FindElement(By.CssSelector("input[value='Sign In']")).Click();
            //using Xpath
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();
            //Explicit wait
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElementValue(By.Id("signInBtn"), "Sign In"));
            string errormessage = driver.FindElement(By.ClassName("alert-danger")).Text;
            TestContext.Progress.WriteLine(errormessage);
            IWebElement link = driver.FindElement(By.LinkText("Free Access to InterviewQues/ResumeAssistance/Material"));
            String hrefAttr = link.GetAttribute("href");
            String expectedUrl = "https://rahulshettyacademy.com/documents-request";
            Assert.That(hrefAttr, Is.EqualTo(expectedUrl));
            //Thread.Sleep(3000);
            driver.Close();
        }
    }
}
