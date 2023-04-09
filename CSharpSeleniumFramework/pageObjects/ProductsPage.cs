using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.PageObjects;

namespace CSharpSeleniumFramework.pageObjects
{
    public class ProductsPage
    {
        IWebDriver driver;
        By cardTitle = By.CssSelector(".card-title a");
        By cartbutton = By.CssSelector(".card-footer button");
        public ProductsPage(IWebDriver driver) 
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void waitForPageDisplay()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));                  //after hitting signbutton from Login.cs wait for 3 seconds
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText("Checkout ")));
        }
        //IList<IWebElement> products = driver.FindElements(By.TagName("app-card"));
        [FindsBy(How = How.TagName, Using = "app-card")]
        private IList<IWebElement> cards;                                               //as per the expected products look into those products from UI and store it list
        public IList<IWebElement> getCards()
        {
            return cards;
        }

        public By getCardTitle()
        {
            return cardTitle;
        }
        
        
        public By addToCartbtton()
        { 
            return cartbutton; 
        }
        [FindsBy(How = How.XPath, Using = "//div[@id='navbarResponsive']//ul//li//a")]
        private IWebElement checkoutbtn;
        public CheckoutPage CheckoutButton()
        {
            checkoutbtn.Click();
            return new CheckoutPage(driver);        //after clicking on the Checkoutbutton it will redirect to a new page and here it is returning the object of new page ie checkoutpage
        }
    }
}
