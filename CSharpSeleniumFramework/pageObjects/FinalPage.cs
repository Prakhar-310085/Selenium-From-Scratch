using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.WaitHelpers;

namespace CSharpSeleniumFramework.pageObjects
{
    public class FinalPage
    {
        IWebDriver driver;
        public FinalPage(IWebDriver driver) 
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "country")]
        private IWebElement location;

        public IWebElement EnterLocation() 
        {
            return location;
        }
        public void WaitforLocationDisplay()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("India")));
        }

        [FindsBy(How = How.LinkText, Using = "India")]
        private IWebElement link;

        public IWebElement ClickonLinkText()
        {
            return link;
        }

        [FindsBy(How = How.XPath, Using = "//div[@class='checkbox checkbox-primary']/label")]
        private IWebElement agrreCheckbox;
        public IWebElement AgrreCheckbox() 
        {
            return agrreCheckbox;
        }

        [FindsBy(How = How.XPath, Using = "//input[@class='btn btn-success btn-lg']")]
        private IWebElement purchaseButton;
        public IWebElement ClickPurchase()
        {
            return  purchaseButton;
        }

        [FindsBy(How = How.CssSelector, Using = ".alert-success")]
        private IWebElement sucessmessage;

        public IWebElement SucessALert() 
        {
            return sucessmessage;
        }

    }
    

}
