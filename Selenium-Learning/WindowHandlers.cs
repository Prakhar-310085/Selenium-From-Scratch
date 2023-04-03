using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;



namespace Selenium_Learning
{
    public class WindowHandlers
    {
        IWebDriver driver;
        [SetUp]
        public void StartBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";

        }
        [Test]
        public void WindowHandler()
        {
            driver.FindElement(By.ClassName("blinkingText")).Click();
            Assert.That(driver.WindowHandles.Count, Is.EqualTo(2));
            string childwindow = driver.WindowHandles[1];
            Thread.Sleep(1000);
            driver.SwitchTo().Window(childwindow);
            var childpagecontent = driver.FindElement(By.XPath("//p[@class='im-para red']"));
            TestContext.Progress.WriteLine(childpagecontent.Text);
            






        }
        [TearDown]
        public void StopBrowser() 
        {
            
            //driver.Close();
            
        }
    }
}
