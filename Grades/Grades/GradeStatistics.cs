using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class GradeStatistics
    {

        public float AverageGrade;
        public float HighestGrade;
        public float LowestGrade;


        // Constructor
        public GradeStatistics()
        {
            // Set the Highest Grade to the lowest possible
            // Set the Lowest Grade to the highest possible
            HighestGrade = 0;
            LowestGrade = float.MaxValue;
        }

        // Demonstration of a Switch statement
        public string Description
        {
            get
            {
                string result;
                switch(LetterGrade)
                {
                    case "A":
                        result = "Excellent: A";
                        break;
                    case "B":
                        result = "Above Average: B";
                        break;
                    case "C":
                        result = "Average: C";
                        break;
                    case "D":
                        result = "Below Average: D";
                        break;
                    default:
                        result = "Failing: F";
                        break;   
                }

                return result;
            }
        }

        // Demonstration of branching
        public string LetterGrade
        {
            get
            {
                string result;
                if (Math.Round(AverageGrade) >= 90)
                {
                    result = "A";
                }
                else if(Math.Round(AverageGrade) >= 80)
                {
                    result = "B";
                }
                else if (Math.Round(AverageGrade) >= 70)
                {
                    result = "C";
                }
                else if (Math.Round(AverageGrade) >= 60)
                {
                    result = "D";
                }
                else
                {
                    result = "F";
                }

                return result;
            }
        }
    }
}
