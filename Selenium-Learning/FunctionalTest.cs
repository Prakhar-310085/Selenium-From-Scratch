using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace Selenium_Learning
{   
    internal class FunctionalTest
    {
        IWebDriver driver;
        [SetUp] 
        public void StartBrowser()
        {
            driver= new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();            
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
        }
        [Test] 
        public void dropdown()
        {

            IWebElement dropdown = driver.FindElement(By.CssSelector("select.form-control"));
            SelectElement select = new SelectElement(dropdown);
            //select.SelectByIndex(0);
            select.SelectByText("Student");
            //select.SelectByValue("teach");
            //to print all the elements in the dropdown in the console below is the code
            IList<IWebElement> elementsfromdd = select.Options; 
            foreach (var element in elementsfromdd)
            {
                //TestContext.Progress.WriteLine(elementsfromdd.Count);
                TestContext.Progress.WriteLine(element.Text);
            }
            IList<IWebElement>radio= driver.FindElements(By.Id("usertype"));
            foreach (var radiobuttons in radio)
            {
                if (radiobuttons.GetAttribute("value").Contains("user"))
                {
                    radiobuttons.Click();
                }                
            }
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("okayBtn")));
            driver.FindElement(By.Id("okayBtn")).Click();
            Boolean result = driver.FindElement(By.Id("usertype")).Selected;
            //Assert.That(result, Is.True);
            //driver.Close();
        }
        
    }
}
