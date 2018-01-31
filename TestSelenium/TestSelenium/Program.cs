using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;

namespace TestSelenium
{
    class Program
    {
        static void Main(string[] args)
        {
            var driver = new ChromeDriver(@"C:\users\mattk\webdrivers");

            driver.Navigate().GoToUrl("http://www.google.com");

            var query = driver.FindElement(By.Name("q"));

            query.SendKeys("Hello Selenium!");
            query.Submit();

            driver.Close();

        }
    }
}
