using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace Selenium_Learning
{
    public class AlertActionAutosuggestive
    {
        IWebDriver driver;
        [SetUp]
        public void StartBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver= new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/AutomationPractice/";
        }
        [Test]
        public void Frames()
        {
            IWebElement scroll = driver.FindElement(By.Id("courses-iframe"));       
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;                   //we used JSExecutor to handle JS event with driver as scrolling in webpage can be handled using this 
            js.ExecuteScript("arguments[0].scrollIntoView(true);", scroll);

            driver.SwitchTo().Frame("courses-iframe");
            driver.FindElement(By.LinkText("All Access Plan")).Click();

        }
        [Test]
        public void Test_Alert() 
        {
            string name = "prakhar";
            driver.FindElement(By.XPath("//input[@id='name']")).SendKeys(name);
            driver.FindElement(By.Id("confirmbtn")).Click();
            string alert_text = driver.SwitchTo().Alert().Text;
            driver.SwitchTo().Alert().Accept();
            StringAssert.Contains(name, alert_text);
        }
        [Test]
        public void AutoSuggestivedropdowns()
        {
            driver.FindElement(By.Id("autocomplete")).SendKeys("ind");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("ui-menu-item")));
            IList <IWebElement> dropdownlist = driver.FindElements(By.XPath("//li[@class=\"ui-menu-item\"]"));
            foreach (IWebElement dropdowns in dropdownlist)
            {
                if (dropdowns.Text.Equals("India"))
                {
                    dropdowns.Click();
                }
            }
        }
        [Test]
        public void Test_Action()
        {
            driver.Url = "https://rahulshettyacademy.com/";
            Actions action = new Actions(driver);
            action.MoveToElement(driver.FindElement(By.CssSelector("a.dropdown-toggle"))).Perform();
            action.MoveToElement(driver.FindElement(By.XPath("//ul[@class='dropdown-menu']/li[2]/a"))).Click().Perform();

        }
        [Test]
        public void DragandDrop() 
        {
            driver.Url = "https://demoqa.com/droppable/";
            IWebElement source = driver.FindElement(By.Id("draggable"));
            IWebElement destination = driver.FindElement(By.Id("droppable"));
            Actions a = new Actions(driver);
            a.DragAndDrop(source, destination).Perform(); 
        }
        [TearDown]
        public void StopBrowser()
        {
            driver.Close();
        }
    }
}
