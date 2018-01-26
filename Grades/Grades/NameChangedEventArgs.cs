using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class NameChangedEventArgs : EventArgs
    {
        // Declare the properties that can be used as arguments for NameChangedEvent
        public string existingName { get; set; }
        public string newName { get; set; }
    }
}
