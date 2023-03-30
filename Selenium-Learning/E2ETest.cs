using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace Selenium_Learning
{
    public class E2ETest
    {
        IWebDriver driver;
        string [] expectedProducts = { "iphone X", "Blackberry" };
        [SetUp]
        public void StartBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait =TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
        }
        [Test]
        public void EndToEndFlow()
        {
            driver.FindElement(By.Id("username")).SendKeys("rahulshettyacademy");
            driver.FindElement(By.Name("password")).SendKeys("learning");
            driver.FindElement(By.XPath("//div[@class='form-group'][5]/label/span/input")).Click();
            driver.FindElement(By.XPath("//input[@value='Sign In']")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.
            ExpectedConditions.ElementIsVisible(By.PartialLinkText("Checkout ")));
            IList<IWebElement> products = driver.FindElements(By.TagName("app-card"));
            foreach (var item in products)
            {
                if (expectedProducts.Contains(item.FindElement(By.CssSelector(".card-title a")).Text))
                {
                    item.FindElement(By.CssSelector(".card-footer button")).Click();
                } 
                
            }
        }
        [TearDown]
        public void CloseBrowser() 
        {
            Thread.Sleep(2000);
            driver.Close();
        }
    }
}
