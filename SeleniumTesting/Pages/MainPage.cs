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
    class MainPage
    {

        String test_url = "https://www.epam.com/";

        private IWebDriver driver;
        private WebDriverWait wait;

        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//*[@id='wrapper']/div[2]/div[1]/header/div/ul/li[3]/div")]
        [CacheLookup]
        private IWebElement searchIcon;

        [FindsBy(How = How.XPath, Using = "//*[@id='new_form_search']")]
        [CacheLookup]
        private IWebElement searchPanel;

        [FindsBy(How = How.ClassName, Using = "header-search__submit")]
        [CacheLookup]
        private IWebElement searchButton;

        [FindsBy(How = How.XPath, Using = "//a[@href='/services']")]
        [CacheLookup]
        private IWebElement servicesButton;

        [FindsBy(How = How.XPath, Using = "//*[@id='wrapper']/div[2]/div[1]/header/div/ul/li[2]/div")]
        [CacheLookup]
        private IWebElement languagesIcon;

        [FindsBy(How = How.XPath, Using = "//a[@href='https://careers.epam-poland.pl']")]
        [CacheLookup]
        private IWebElement polandLangButton;

        [FindsBy(How = How.XPath, Using = "//a[@href='/careers']")]
        [CacheLookup]
        private IWebElement careersButton;


        //[FindsBy(How = How.XPath, Using = "//*[@id='tsf']/div[2]/div[1]/div[1]/div/div[2]/input")]
        //[FindsBy(How = How.Name, Using = "q")]
        //[CacheLookup]
        //private IWebElement elem_search_text;

        //[FindsBy(How = How.XPath, Using = "//*[@id='tsf']/div[2]/div/div[3]/center/input[1]")]
        //[FindsBy(How = How.Name, Using = "btnI")]
        //[CacheLookup]
        //private IWebElement elem_submit_button;

        //[FindsBy(How = How.XPath, Using = "//*[@id='hplogo']")]
        //[FindsBy(How = How.Id, Using = "hplogo")]
        //[CacheLookup]
        //private IWebElement elem_logo_img;

        // Go to the designated page
        public void goToPage()
        {
            driver.Navigate().GoToUrl(test_url);
        }

        // Returns the Page Title
        public String getPageTitle()
        {
            return driver.Title;
        }

        // Returns the search string
        public String getSearchText()
        {
            return searchPanel.Text;
        }

        // Checks whether the Logo is displayed properly or not
        //public bool getWebPageLogo()
        //{
          //  return elem_logo_img.Displayed;
        //}

        public SearchPage test_search(string input_search)
        {
            searchIcon.Click();
            searchPanel.Click();
            searchPanel.SendKeys(input_search);
            searchPanel.Submit();
            //wait.Until(ExpectedConditions.ElementToBeClickable(elem_submit_button)).Submit();
            //elem_search_text.Submit();
            //searchButton.Click();
            return new SearchPage(driver);
        }

        public ServicesPage test_services()
        {
            servicesButton.Click();
            return new ServicesPage(driver);
        }

        public CareersPage test_translate()
        {
            languagesIcon.Click();
            polandLangButton.Click();
            return new CareersPage(driver);
        }

        public CareersPage goto_careers()
        {
            careersButton.Click();
            return new CareersPage(driver);
        }
    
    }
}
