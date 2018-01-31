using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace WebDriverDemo2
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver(@"C:\Users\Mattk\webdrivers\");
            driver.Url = @"file:///C:/Users/mattk/source/repos/WebDriverDemo2/WebDriverDemo2/TestPage.html";

            CheckRadioButtons(driver);
            CheckCheckBoxes(driver);
            CheckSelectLists(driver);
            FindNestedTablesWithTagName(driver);
            FindNestedTablesWithXPath(driver);

        }

        static void CheckRadioButtons(IWebDriver driver)
        {
            var radioButtons = driver.FindElements(By.Name("color"));
            foreach (var radioButton in radioButtons)
            {
                if (radioButton.Selected)
                {
                    Console.WriteLine(radioButton.GetAttribute("value"));
                }
            }
        }

        static void CheckCheckBoxes(IWebDriver driver)
        {
            var checkBox = driver.FindElement(By.Id("check1"));
            checkBox.Click();
        }

        static void CheckSelectLists(IWebDriver driver)
        {
            var select = driver.FindElement(By.Id("select1"));

            var selectElement = new SelectElement(select);
            selectElement.SelectByText("Frank");
        }

        static void FindNestedTablesWithTagName(IWebDriver driver)
        {
            var outerTable = driver.FindElement(By.TagName("table"));
            var innerTable = outerTable.FindElement(By.TagName("table"));
            var rows = innerTable.FindElements(By.TagName("td"));

            foreach (var row in rows)
            {
                Console.WriteLine("TagName Row: " + row.Text);
            }
        }
        static void FindNestedTablesWithXPath(IWebDriver driver)
        {
            var row = driver.FindElement(By.XPath("/ html / body / table / tbody / tr / td[2] / table / tbody / tr[2] / td"));
            Console.WriteLine("XPath Row: " + row.Text);
        }
    }
}
