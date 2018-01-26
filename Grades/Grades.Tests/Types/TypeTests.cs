using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades.Tests.Types
{
    [TestClass]
    public class TypeTests
    {

        /* Test to demonstrate that arrays, 
         * even of value types, are reference types */
        [TestMethod]
        public void UsingArrays()
        {
            float[] grades;
            grades = new float[3];

            AddGrades(grades);

            Assert.AreEqual(95.2f, grades[0]);
            Assert.AreEqual(89.1f, grades[1]);
            Assert.AreEqual(100, grades[2]);

        }

        // Method to assign values to the array
        private void AddGrades(float[] grades)
        {
            grades[0] = 95.2f;
            grades[1] = 89.1f;
            grades[2] = 100;
        }


        /* Test to demonstrate that strings,
         * although references, are immutable */
        [TestMethod]
        public void UppercaseString()
        {
            string name = "matt";
            name = name.ToUpper();

            Assert.AreEqual("MATT", name);
        }

        /* Test to demonstrate that immutable objects 
         * cannot be changed by reference */
        [TestMethod]
        public void AddDaysToDateTime()
        {
            DateTime date = new DateTime(2018, 1, 24);
            date = date.AddDays(1);

            Assert.AreEqual(25, date.Day);
        }

        // Test to verify value types are passed by value
        [TestMethod]
        public void ValueTypesPassByValue()
        {
            int x = 100;
            IncrementNumber(x);

            Assert.AreEqual(100, x);
        }

        // Method to increase an integer by 1
        private void IncrementNumber (int number)
        {
            number++;
        }


        /* Test to show that refernce types, even though passed by value, 
         * they are still referencing the same object */
        [TestMethod]
        public void ReferenceTypesPassByValue()
        {
            GradeBook book1 = new GradeBook();
            GradeBook book2 = book1;

            book1.NameChanged += book1.OnNameChanged;

            GiveBookAName(book2);
            Assert.AreEqual("A GradeBook", book1.Name);

        }

        // Method to give a gradebook a name
        private void GiveBookAName(GradeBook book)
        {
            book.Name = "A GradeBook";
        }

        // Test to verify the comparisons of 2 strings
        [TestMethod]
        public void StringComparisons()
        {
            string name1 = "Matt";
            string name2 = "matt";
            bool result = string.Equals(name1, name2, StringComparison.InvariantCultureIgnoreCase);

            Assert.IsTrue(result);

        }
        
        // Test to verify that these variables are a value
        [TestMethod]
        public void IntVariablesHoldAValue()
        {
            // Instatiate a value type variables and reference 
            int x1 = 100;
            int x2 = x1;

            /* Change the value of x1 after assigning x2 = x1
             * and verify that they are not equal  */
            x1 = 4;
            Assert.AreNotEqual(x1, x2);

        }

        // Test to verify that these variables are a reference
        [TestMethod]
        public void GradeBookVariablesHoldAReference()
        {
            // Instantiate a gradebook and have 2 variables pointing to the same gradebook
            GradeBook g1 = new GradeBook();
            GradeBook g2 = g1;

            g1.NameChanged += g1.OnNameChanged;

            /* Set the name of the gradebook and verify that both 
             * variables are referencing the same gradebook  */
            g1.Name = "Matt's GradeBook";
            Assert.AreEqual(g1.Name, g2.Name);
        }

    }
}
