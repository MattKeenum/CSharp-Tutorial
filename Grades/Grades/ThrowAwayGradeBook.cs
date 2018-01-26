using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    // Demonstration of Inheritance
    public class ThrowAwayGradeBook : GradeBook
    {
        public override GradeStatistics ComputeStatistics()
        {

            // Debug line to show which ComputeStatistics the program is in
            Console.WriteLine("ThrowAwayGradeBook::ComputeStatistics");

            float lowest = float.MaxValue;

            // Determine the lowest grade
            foreach (float grade in grades)
            {
                lowest = Math.Min(grade, lowest);
            }

            grades.Remove(lowest);
            Console.WriteLine($"\n-- The lowest grade of {lowest} has been removed.\n");
            return base.ComputeStatistics();
        }
    }
}
