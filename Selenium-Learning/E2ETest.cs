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
        string[] actualproducts = new string[2];
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
            driver.FindElement(By.Id("username")).SendKeys("rahulshettyacademy");       //username entered
            driver.FindElement(By.Name("password")).SendKeys("learning");               //password entered
            driver.FindElement(By.XPath("//div[@class='form-group'][5]/label/span/input")).Click();         //checkbox selected
            driver.FindElement(By.XPath("//input[@value='Sign In']")).Click();                              //signin button is clicked
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));                        //aftre sign in wait for 8 seconds
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText("Checkout ")));
            IList<IWebElement> products = driver.FindElements(By.TagName("app-card"));            //as per the expected products look into those products from UI and store it list
            foreach (var item in products)
            {                                                                                               //iterate throught the product list 
                if (expectedProducts.Contains(item.FindElement(By.CssSelector(".card-title a")).Text))      //and get the text out of it and compare it with actula products
                {
                    item.FindElement(By.CssSelector(".card-footer button")).Click();                        //then click on add to cart button 
                }
                
            }
            driver.FindElement(By.XPath("//div[@id='navbarResponsive']//ul//li//a")).Click();               //click on checkout button
            IList<IWebElement> checkoutList = driver.FindElements(By.CssSelector("h4 a"));                 //for comparison we checked that in media class those 2 added item from cart are showing or not
            for (int i = 0; i < checkoutList.Count; i++)
            {
                actualproducts[i] = checkoutList[i].Text;
            }
            Assert.That(actualproducts, Is.EqualTo(expectedProducts));                                    //compare actual(values from UI) with expected(known values)
            TestContext.Progress.WriteLine("Assert passed");
            driver.FindElement(By.XPath("//button[@class='btn btn-success']")).Click();                 //click on th echeckout button
            //string deleiveryLocation = "India";
            driver.FindElement(By.Id("country")).SendKeys("ind");                                   //pass ind as a search keyword in the location text box
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("India")));   //added as  a wait bcoz based on search it shpuld wait for sometime to load
            driver.FindElement(By.LinkText("India")).Click();                                               //click on the India in search result in dropdown
            driver.FindElement(By.XPath("//div[@class='checkbox checkbox-primary']/label")).Click();        //click on checkbox
            driver.FindElement(By.XPath("//input[@class='btn btn-success btn-lg']")).Click();               //click on purchase 

            String confirText = driver.FindElement(By.CssSelector(".alert-success")).Text;              //to check whether the perfored steps is correct ot not grab the text from selector

            StringAssert.Contains("Success", confirText);                                               //performed assertions on top of it to validte 

        }
        [TearDown]
        public void CloseBrowser() 
        {
            //Thread.Sleep(2000);
            driver.Close();
        }
    }
}
