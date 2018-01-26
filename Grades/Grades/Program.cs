using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instantiate a gradebook
            IGradeTracker book = CreateGradeBook();

            GetBookName(book);
            AddGrades(book);
            SaveGrades(book);
            WriteResults(book);

        }

        // Demonstration of Polymorphism
        private static IGradeTracker CreateGradeBook()
        {
            return new ThrowAwayGradeBook();
        }

        // Output the results of the grades
        private static void WriteResults(IGradeTracker book)
        {
            // Call to compute the statistics
            GradeStatistics stats = book.ComputeStatistics();

            foreach (float grade in book)
            {
                Console.WriteLine(grade);
            }


            WriteResult("Name", book.Name);
            WriteResult("Average", stats.AverageGrade);
            WriteResult("Highest", (int)stats.HighestGrade);
            WriteResult("Lowest", stats.LowestGrade);
            WriteResult("Grade", stats.Description);
        }


        // Outputs the grades to a text file
        private static void SaveGrades(IGradeTracker book)
        {
            using (StreamWriter outputFile = File.CreateText("grades.txt"))
            {
                book.WriteGrades(outputFile);
            }
        }

        // Add grades to the gradebook
        private static void AddGrades(IGradeTracker book)
        {
            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);
        }

        // Ensures a valid name is given for a gradebook
        private static void GetBookName(IGradeTracker book)
        {
            string name = null;

            // Demonstration of a while loop
            while (name == null || name == "")
            {
                Console.Write("Please Enter a name for the Grade Book: ");
                name = Console.ReadLine();
            }

            // Demonstration of a Try/Catch
            try
            {
                book.Name = name;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Methods to demonstrate overloading
        static void WriteResult(string description, int result)
        {
            // Demonstration of string concatenation
            Console.WriteLine(description + ": " + result);
        }

        static void WriteResult(string description, float result)
        {
            // Demonstration of interpolated string
            Console.WriteLine($"{description}: {result:F2}");
        }

        static void WriteResult(string description, string result)
        {
            // Demonstration of composite format string
            Console.WriteLine("{0}: {1}", description, result);
        }
    }
}
