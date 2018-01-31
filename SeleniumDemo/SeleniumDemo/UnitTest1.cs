using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace SeleniumDemo
{
    [TestClass]
    public class UnitTest1
    {

        static IWebDriver driverFF;
        static IWebDriver driverGC;


        [AssemblyInitialize]
        public static void SetUp(TestContext context)
        {
            driverFF = new FirefoxDriver();
            driverGC = new ChromeDriver(@"C:\Users\mattk\webdrivers");
        }

        [TestMethod]
        public void TestFirefoxDriver()
        {
            driverFF.Navigate().GoToUrl("http://www.google.com");
            driverFF.FindElement(By.Id("lst-ib")).SendKeys("Selenium");
            driverFF.FindElement(By.Id("lst-ib")).SendKeys(Keys.Enter);
        }

        [TestMethod]
        public void TestChromeDriver()
        {
            driverGC.Navigate().GoToUrl("http://www.google.com");
            driverGC.FindElement(By.Id("lst-ib")).SendKeys("Selenium");
            driverGC.FindElement(By.Id("lst-ib")).SendKeys(Keys.Enter);
            Assert.IsTrue(driverGC.Title == "Selenium - Google Search");
        }
    }
}
