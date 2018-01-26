using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    // Demonstration of an abstract class
    public abstract class GradeTracker : IGradeTracker
    {
        public abstract void AddGrade(float grade);
        public abstract GradeStatistics ComputeStatistics();
        public abstract void WriteGrades(TextWriter destination);
        public abstract IEnumerator GetEnumerator();

        protected string name;
        public event NameChangedDelegate NameChanged;

        // An example of a property
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                // If the value of the name pass is null or empty
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or empty!");
                }

                // If there was a change in the name and NameChanged has a method passed to it
                if (name != value && NameChanged != null)
                {
                    // Instantiate args and add the existing and new names
                    NameChangedEventArgs args = new NameChangedEventArgs();
                    args.existingName = name;
                    args.newName = value;

                    NameChanged(this, args);
                }

                name = value;

            }
        }

        public void OnNameChanged(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine($"Grade Book changing name from {args.existingName} to {args.newName}");
        }
    }
}
