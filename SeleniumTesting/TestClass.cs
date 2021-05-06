using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Text;
using SeleniumTesting.Pages;

namespace SeleniumTesting
{
    class TestClass
    {
        IWebDriver driver;

        [SetUp]
        public void startBrowser()
        {
            driver = new FirefoxDriver("D:\\3\\trpz\\driver\\");
        }

        [Test]
        public void KeywordSearch()
        {
            String expected_keyword = "devops";
            String result_PageTitle;
            String search_string = "devops";

            MainPage home_page = new MainPage(driver);
            home_page.goToPage();
            //home_page.test_search(search_string);

           // SearchPage search_page = new SearchPage(driver); ;
            SearchPage final_page = home_page.test_search(search_string);

            // Ensure that the page load is complete    
            final_page.load_complete();

            //As the web page is loaded, we just check if the page title matches or not.
            result_PageTitle = final_page.getPageTitle();

            if (result_PageTitle.Contains(expected_keyword) || driver.Url.ToLower().Contains(expected_keyword))
            {
                Console.WriteLine("Search Passed");
            }
            else
            {
                Console.WriteLine("Search Failed");
            }
        }

        [Test]
        public void ServicesPage()
        {
            String result_PageTitle;
            String expected_title = "services";
            MainPage home_page = new MainPage(driver);
            home_page.goToPage();

            ServicesPage final_page = home_page.test_services();

            // Ensure that the page load is complete    
            final_page.load_complete();

            //As the web page is loaded, we just check if the page title matches or not.
            result_PageTitle = final_page.getPageTitle();

            if (result_PageTitle.ToLower().Contains(expected_title) && driver.Url.ToLower().Contains(expected_title))
            {
                Console.WriteLine("Services Test Passed");
            }
            else
            {
                Console.WriteLine("Services Test Failed");
            }

        }

        [Test]
        public void TranslatingPage()
        {
            String result_PageTitle;
            String expected_title = "pl";
            MainPage home_page = new MainPage(driver);
            home_page.goToPage();

            CareersPage final_page = home_page.test_translate();

            // Ensure that the page load is complete    
            final_page.load_complete();

            //As the web page is loaded, we just check if the page title matches or not.
            result_PageTitle = final_page.getPageTitle();

            Console.WriteLine(result_PageTitle.ToLower());
            Console.WriteLine(driver.Url.ToLower());

            if (driver.Url.ToLower().Contains(expected_title))
            {
                Console.WriteLine("Translate Test Passed");
            }
            else
            {
                Console.WriteLine("Translate Test Failed");
            }
        }

        [Test]
        public void filterInsights()
        {
            String result_PageTitle;
            String expected_title = "healthcare";
            MainPage home_page = new MainPage(driver);
            home_page.goToPage();

            InsightsPage insights_page = home_page.goto_insights();

            SearchPage final_page = insights_page.test_filterInsights();

            // Ensure that the page load is complete    
            final_page.load_complete();

            //As the web page is loaded, we just check if the page title matches or not.
            result_PageTitle = final_page.getPageTitle();

            if (result_PageTitle.ToLower().Contains(expected_title) || driver.Url.ToLower().Contains(expected_title))
            {
                Console.WriteLine("Filter Test Passed");
            }
            else
            {
                Console.WriteLine("Filter Test Failed");
            }

        }

        [Test]
        public void filterInsights2()
        {
            String result_PageTitle;
            String expected_title = "healthcare";
            String expected_title_2 = "interview";
            MainPage home_page = new MainPage(driver);
            home_page.goToPage();

            InsightsPage insights_page = home_page.goto_insights();

            SearchPage final_page = insights_page.test_filterInsights_2();

            // Ensure that the page load is complete    
            final_page.load_complete();

            //As the web page is loaded, we just check if the page title matches or not.
            result_PageTitle = final_page.getPageTitle();

            if (result_PageTitle.ToLower().Contains(expected_title) && result_PageTitle.ToLower().Contains(expected_title_2) && driver.Url.ToLower().Contains(expected_title) && driver.Url.ToLower().Contains(expected_title_2))
            {
                Console.WriteLine("Filter Test Passed");
            }
            else
            {
                Console.WriteLine("Filter Test Failed");
            }

        }

        [Test]
        public void KeywordJobsSearch()
        {
            String expected_keyword = "Lviv";
            String result_PageTitle;
            String search_string = "Lviv";

            MainPage home_page = new MainPage(driver);
            home_page.goToPage();
            //home_page.test_search(search_string);

            // SearchPage search_page = new SearchPage(driver); ;
            CareersPage careers_page = home_page.goto_careers();

            careers_page.load_complete();

            SearchPage final_page = careers_page.test_search(search_string);

            // Ensure that the page load is complete    
            final_page.load_complete();

            //As the web page is loaded, we just check if the page title matches or not.
            result_PageTitle = final_page.getPageTitle();

            Console.WriteLine(result_PageTitle.ToLower());
            Console.WriteLine(driver.Url.ToLower());

            if (result_PageTitle.Contains(expected_keyword) || driver.Url.ToLower().Contains(expected_keyword))
            {
                Console.WriteLine("Job Search Passed");
            }
            else
            {
                Console.WriteLine("Job Search Failed");
            }
        }

        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }
    }
}
