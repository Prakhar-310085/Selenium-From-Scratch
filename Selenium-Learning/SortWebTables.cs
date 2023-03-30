using AngleSharp.Dom;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace Selenium_Learning
{
    public class SortWebTables
    {
        IWebDriver driver;
        [SetUp]
        public void StartBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());             
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5); 
            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/seleniumPractise/#/offers";
        }
        [Test]
        public void Sort()
        {
            ArrayList arrayList = new ArrayList();
            IWebElement dropdown = driver.FindElement(By.Id("page-menu"));
            SelectElement select = new SelectElement(dropdown);
            select.SelectByValue("20");
            IList<IWebElement> elements = driver.FindElements(By.XPath("//tr/td[1]"));
            //step 1 we will take all the ememnts from the UI of Webtable and add it in our arrayList
            foreach (var item in elements)
            {
                arrayList.Add(item.Text);
                //TestContext.Progress.WriteLine(item);
            }
            TestContext.Progress.WriteLine("*********Before Sorting**************");

            //step 2 we have to print the array list conating all the elements in it, we can not directly print in above loop as we cannnot print arraylist directly
            foreach (var beforesort in arrayList)
            {
                TestContext.Progress.WriteLine(beforesort);
            }
            arrayList.Sort();
            TestContext.Progress.WriteLine("*********After Sorting**************");
            foreach (var afterSort in arrayList)
            {
                TestContext.Progress.WriteLine(afterSort);
            }
            driver.FindElement(By.CssSelector("th[aria-label='Veg/fruit name: activate to sort column ascending']")).Click();
            IList<IWebElement> sortedelements = driver.FindElements(By.XPath("//tr/td[1]"));
            ArrayList arrayList2 = new ArrayList();

            foreach (var sorted in sortedelements)
            {
                arrayList2.Add(sorted.Text);
            }
            Assert.AreEqual(arrayList2 , arrayList);
            TestContext.Progress.WriteLine("success case");
        }
        [TearDown]
        public void StopBrowser() 
        {
            Thread.Sleep(2000);
            driver.Close();
        }
    }
}
