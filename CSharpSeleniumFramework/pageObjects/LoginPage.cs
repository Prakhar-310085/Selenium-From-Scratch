using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumFramework.pageObjects
{
    public class LoginPage
    {
        IWebDriver driver;
        public LoginPage(IWebDriver driver) 
        {
            this.driver = driver;
            PageFactory.InitElements(driver,this);            //init elelment will register all the find elements locators with driver interanlly using pagefactory class 
        }


        
        [FindsBy(How = How.Id, Using = "username")]
        private IWebElement username;

        [FindsBy(How =How.Id, Using= "password")]
        private IWebElement password;

        [FindsBy(How = How.XPath, Using = "//div[@class='form-group'][5]/label/span/input")]
        private IWebElement checkbox;

        [FindsBy(How =How.XPath, Using = "//input[@value='Sign In']")]
        private IWebElement SignIn;

        public ProductsPage validLogin(string enterusername, string enterpassword)
        {
            username.SendKeys(enterusername);
            password.SendKeys(enterpassword);
            checkbox.Click();
            SignIn.Click();
            return new ProductsPage(driver);        //here we have returned the object of product class because we know that after click it will go to product page
        }
    }
    
    
}
