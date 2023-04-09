using CSharpSeleniumFramework.pageObjects;
using CSharpSeleniumFramework.utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace CSharpSeleniumFramework
{
    public class E2ETest : Base
    {
        [Test]
        public void EndToEndFlow()
        {
            string[] expectedProducts = { "iphone X", "Blackberry" };
            string[] actualproducts = new string[2];
            LoginPage loginPage = new LoginPage(driver);
            ProductsPage prod = loginPage.validLogin("rahulshettyacademy", "learning");       //valid login is a method inside Login class //we have saved the object creation step for pruct class
            prod.waitForPageDisplay();                                                    //we accessed the method of waitforpagedisplay in the prdouct class


            IList<IWebElement> products = prod.getCards();            //as per the expected products look into those products from UI and store it list
            foreach (var item in products)
            {                                                                                               //iterate throught the product list 
                if (expectedProducts.Contains(item.FindElement(prod.getCardTitle()).Text))      //and get the text out of it and compare it with actula products
                {
                    item.FindElement(prod.addToCartbtton()).Click();                        //then click on add to cart button 
                }

            }
            CheckoutPage checkout = prod.CheckoutButton();            //click on checkout button
            IList<IWebElement> checkoutList = checkout.getCheckoutListitems();                 //for comparison we checked that in media class those 2 added item from cart are showing or not
            for (int i = 0; i < checkoutList.Count; i++)
            {
                actualproducts[i] = checkoutList[i].Text;
            }
            Assert.That(actualproducts, Is.EqualTo(expectedProducts));                                    //compare actual(values from UI) with expected(known values)
            TestContext.Progress.WriteLine("Assert passed");
            FinalPage final = checkout.CheckButtonClick();                //click on th echeckout button
            //string deleiveryLocation = "India";
            final.EnterLocation().SendKeys("ind");                      //pass ind as a search keyword in the location text box
            final.WaitforLocationDisplay();                             //wait for the india element to be displayed in the dropdown list
            final.ClickonLinkText().Click();                                               //click on the India in search result in dropdown
            final.AgrreCheckbox().Click();        //click on checkbox
            final.ClickPurchase().Click();               //click on purchase 

            string confirText = final.SucessALert().Text;              //to check whether the perfored steps is correct ot not grab the text from selector

            StringAssert.Contains("Success", confirText);                                               //performed assertions on top of it to validte 

        }
        
    }
}
