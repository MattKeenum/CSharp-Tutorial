using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    // Delegate to accept the object as the sender and arguments based on NameChangedEventArgs
    public delegate void NameChangedDelegate(object sender, NameChangedEventArgs args);
}
