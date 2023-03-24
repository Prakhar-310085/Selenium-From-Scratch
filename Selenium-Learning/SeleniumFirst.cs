using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace Selenium_Learning
{
    internal class SeleniumFirst
    {
        IWebDriver driver;
        [SetUp]
        public void Start()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test1()
        {
            driver.Url= "https://rahulshettyacademy.com/loginpagePractise/";
            TestContext.Progress.WriteLine("Below is the tile of the page");
            TestContext.Progress.WriteLine(driver.Title);
            TestContext.Progress.WriteLine(driver.Url);
            driver.Close();
        }
    }
}
