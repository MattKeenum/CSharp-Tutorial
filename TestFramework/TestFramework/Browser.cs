using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace TestFramework
{
    public static class Browser
    {

        static IWebDriver webDriver = new FirefoxDriver();


        public static void Goto(string url)
        {
            webDriver.Url = url;
        }

        // Wait for the page to load
        public static void WaitForPageLoad(int seconds)
        {
            new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds)).Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
        }

        // Wait for an element to become clickable
        public static void WaitForClickable(string linkText)
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText(linkText)));
        }


        public static string Title
        {
            get { return webDriver.Title; }
        }


        public static ISearchContext Driver
        {
            get { return webDriver; }
        }

        public static void Close()
        {
            webDriver.Close();
        }
    }
}