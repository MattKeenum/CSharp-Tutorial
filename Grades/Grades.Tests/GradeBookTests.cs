using Grades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Grades.Tests
{
    [TestClass]
    public class GradeBookTests
    {

        [TestMethod]
        public void ComputesLetterGrade()
        {
            GradeBook book = new GradeBook();

            book.NameChanged += book.OnNameChanged;

            book.AddGrade(95);
            book.AddGrade(100);
            book.AddGrade(87.5f);
            book.Name = "Matthew";
            

            GradeStatistics result = book.ComputeStatistics();
            Assert.AreEqual("A", result.LetterGrade);
        }

        // Test to assert that the Highest Grade is working correctly
        [TestMethod]
        public void ComputesHighestGrade()
        {
            GradeBook book = new GradeBook();
            book.NameChanged += book.OnNameChanged;

            book.AddGrade(10);
            book.AddGrade(90);
            book.Name = "Matthew";

            // Call to compute the statisticis and verify the results
            GradeStatistics result = book.ComputeStatistics();
            Assert.AreEqual(90, result.HighestGrade);
        }

        // Test to assert that the Lowest Grade is working correctly
        [TestMethod]
        public void ComputesLowestGrade()
        {
            GradeBook book = new GradeBook();
            book.NameChanged += book.OnNameChanged;

            book.AddGrade(10);
            book.AddGrade(90);
            book.Name = "Matthew";

            // Call to compute the statisticis and verify the results
            GradeStatistics result = book.ComputeStatistics();
            Assert.AreEqual(10, result.LowestGrade);
        }

        // Test to assert that the Average Grade is working correctly
        [TestMethod]
        public void ComputesAverageGrade()
        {
            GradeBook book = new GradeBook();
            book.NameChanged += book.OnNameChanged;

            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);
            book.Name = "Matthew";

            // Call to compute the statisticis and verify the results
            GradeStatistics result = book.ComputeStatistics();
            Assert.AreEqual(85.16, result.AverageGrade, 0.01);
        }
    }
}
