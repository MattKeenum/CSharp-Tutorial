using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFramework
{
    public static class Pages
    {
        public static HomePage HomePage
        {
            get
            {
                HomePage homePage = new HomePage();
                PageFactory.InitElements(Browser.Driver, homePage);
                return homePage;
            }
        }

        public static CoursePage CoursePage
        {
            get
            {
                CoursePage coursePage = new CoursePage();
                PageFactory.InitElements(Browser.Driver, coursePage);
                return coursePage;
            }
        }
    }

    public class HomePage
    {

        static string Url = "http://pluralsight.com";
        static string pageTitle = "Pluralsight | Unlimited Online Developer, IT and Cyber Security Training";


        public void Goto()
        {
            Browser.Goto(Url);
        }

        public bool IsAt()
        {
            Browser.WaitForPageLoad(10);
            return Browser.Title == pageTitle;
        }

    }

    public class CoursePage
    {
        static string pageTitle = "Automated Web Testing with Selenium | Pluralsight";


        public bool IsAtCoursePage()
        {
            // Since there is page navigation, wait until the page is fully loaded.
            Browser.WaitForPageLoad(10);
            return Browser.Title == pageTitle;
        }

        public void SelectCourse(string courseName)
        {

            // Locate the search box and search for the course
            IWebElement searchBox = Browser.Driver.FindElement(By.ClassName("header_search--input"));
            searchBox.SendKeys(courseName);
            searchBox.SendKeys(Keys.Enter);

            // Wait until the course name is clickable
            Browser.WaitForClickable(courseName);
            var course = Browser.Driver.FindElement(By.LinkText(courseName));
            course.Click();

        }
    }
}
