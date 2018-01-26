using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class GradeBook : GradeTracker
    {

        protected List<float> grades;


        // Constructor to have a new list for each new object of GradeBook
        public GradeBook()
        {
            grades = new List<float>();
            name = "Empty";
        }

        // Demonstration of a for loop
        public override void WriteGrades(TextWriter destination)
        {
            for (int i = 0; i < grades.Count; i++)
            {
                destination.WriteLine(grades[i]);
            }
        }

        // Method to add grades to the list
        public override void AddGrade(float grade)
        {
            grades.Add(grade);
        }

        // Method to compute the High, Low and Average grades
        public override GradeStatistics ComputeStatistics()
        {
            Console.WriteLine("GradeBook::ComputeStatistics");

            GradeStatistics stats = new GradeStatistics();
            float sum = 0;

            // Demonstration of a foreach loop
            foreach (var grade in grades)
            {
                stats.HighestGrade = Math.Max(grade, stats.HighestGrade);
                stats.LowestGrade = Math.Min(grade, stats.LowestGrade);
                sum += grade;
            }

            stats.AverageGrade = sum / grades.Count;
            return stats;
        }

        public override IEnumerator GetEnumerator()
        {
            return grades.GetEnumerator();
        }

    }
}
