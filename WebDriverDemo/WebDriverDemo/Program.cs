using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace WebDriverDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //IWebDriver driver = new ChromeDriver(@"C:\Users\mattk\webdrivers\");
            FirefoxOptions ffo = new FirefoxOptions();

            // Using Selenium Standalone Server v3.8.1
            Uri uri = new Uri("http://localhost:4444/wd/hub");
            RemoteWebDriver driver = new RemoteWebDriver(uri, ffo.ToCapabilities());

            driver.Url = "http://www.google.com";

            var searchBox = driver.FindElement(By.Id("lst-ib"));
            searchBox.SendKeys("Pluralsight");
            searchBox.Submit();


            //findByClassNameImplicitWait(driver);
            findByClassNameExplicitWait(driver);
            //findByXPath(driver);
            //findByCssSelector(driver);

            var img = driver.FindElement(By.ClassName("rg_i"));
            img.Click();
            

        }

        // Example of finding element by Class Name with an implicit wait
        static void findByClassNameImplicitWait(IWebDriver driver)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            /*  This specific example is finding a compound class name ("q qs"), which Selenium doesn't support
                To get around this, we are only searching on the last class ("qs") and then filtering the results */
            var links = driver.FindElements(By.ClassName("qs"));
            foreach (var link in links)
            {
                if (link.Text == "Images")
                {
                    link.Click();
                    break;
                }
            }

        }

        // Example of finding element by Class Name with an explicit wait
        static void findByClassNameExplicitWait(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var links = wait.Until(d =>
            {
                var elements = driver.FindElements(By.ClassName("qs"));
                if (elements.Count > 0)
                {
                    return elements;
                }
                return null;
            });

            /*  This specific example is finding a compound class name ("q qs"), which Selenium doesn't support
                To get around this, we are only searching on the last class ("qs") and then filtering the results */
            foreach (var link in links)
            {
                if (link.Text == "Images")
                {
                    link.Click();
                    break;
                }
            }

        }

        // Example of finding an element by XPath
        static void findByXPath(IWebDriver driver)
        {
            var link = driver.FindElement(By.XPath("//*[@id=\"hdtb-msb-vis\"]/div[4]/a"));
            link.Click();
        }

        // Example of finding an element by CssSelector
        static void findByCssSelector(IWebDriver driver)
        {
            var links = driver.FindElements(By.CssSelector(".q.qs"));
            foreach (var link in links)
            {
                if (link.Text == "Images")
                {
                    link.Click();
                    break;
                }
            }
        }
    }
}
