using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using NUnit.Framework;
using System.Threading;
using System.Linq;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
// For supporting Page Object Model
// Obsolete - using OpenQA.Selenium.Support.PageObjects;
using SeleniumExtras.PageObjects;

namespace SeleniumTesting.Pages
{
    class InsightsPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        Int32 timeout = 10000; // in milliseconds
        public InsightsPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//*[@id='main']/div[1]/div[4]/section/div/div[1]/div/div[2]/div/div/span[1]/div/div[1]")]
        [CacheLookup]
        private IWebElement filterField;

        [FindsBy(How = How.XPath, Using = "//*[@id='main']/div[1]/div[4]/section/div/div[1]/div/div[2]/div/div/span[2]/div/div[1]")]
        [CacheLookup]
        private IWebElement contentField;

        [FindsBy(How = How.XPath, Using = "//*[@id='main']/div[1]/div[4]/section/div/div[1]/div/div[2]/div/div/span[1]/div/div[2]/div/ul/li[8]/label/span")]
        [CacheLookup]
        private IWebElement healthcareCheck;

        [FindsBy(How = How.XPath, Using = "//*[@id='main']/div[1]/div[4]/section/div/div[1]/div/div[2]/div/div/span[2]/div/div[2]/div/ul/li[5]/label/span")]
        [CacheLookup]
        private IWebElement interviewsCheck;

        [FindsBy(How = How.XPath, Using = " //*[@id='main']/div[1]/div[4]/section/div/div[1]/div/div[3]/ul/li[1]/a/div[2]")]
        [CacheLookup]
        private IWebElement firstLink;

        [FindsBy(How = How.XPath, Using = "//*[@id='main']/div[1]/div[4]/section/div/div[1]/div/div[3]/ul/li/a/div[2]")]
        [CacheLookup]
        private IWebElement firstLink2;

        

        public String getPageTitle()
        {
            return driver.Title;
        }

        public void load_complete()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeout));

            // Wait for the page to load
            wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
        }

        public SearchPage test_filterInsights()
        {
            filterField.Click();
            healthcareCheck.Click();
//            filterField.Submit();
            firstLink.Click();
            return new SearchPage(driver);
        }

        public SearchPage test_filterInsights_2()
        {
            filterField.Click();
            healthcareCheck.Click();
            contentField.Click();
            interviewsCheck.Click();
            firstLink2.Click();
            return new SearchPage(driver);
        }
    }
}
