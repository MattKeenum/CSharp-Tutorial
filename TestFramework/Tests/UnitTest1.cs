using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestFramework;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Can_Go_To_HomePage()
        {
            Pages.HomePage.Goto();
            Assert.IsTrue(Pages.HomePage.IsAt());
        }

        [TestMethod]
        public void Can_Go_To_Course_Page()
        {
            Pages.HomePage.Goto();
            Pages.CoursePage.SelectCourse("Automated Web Testing with Selenium");
            Assert.IsTrue(Pages.CoursePage.IsAtCoursePage());
        }

        [TestCleanup]
        public void CleanUp()
        {
            Browser.Close();
        }
    }
}
