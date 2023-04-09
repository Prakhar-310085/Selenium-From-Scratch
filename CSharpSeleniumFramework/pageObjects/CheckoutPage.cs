using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumFramework.pageObjects
{
    public class CheckoutPage
    {
        IWebDriver driver;
        public CheckoutPage(IWebDriver driver) 
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);        
        }

        [FindsBy(How = How.CssSelector, Using = "h4 a")]
        private IList<IWebElement> checkout;

        public IList<IWebElement> getCheckoutListitems()
        { 
            return checkout;
        }

        [FindsBy(How = How.XPath, Using = "//button[@class='btn btn-success']")]
        private IWebElement checkoutButton;

        public FinalPage CheckButtonClick() 
        {
            checkoutButton.Click();
            return new FinalPage(driver);               //object of next page
        }

    }
}
