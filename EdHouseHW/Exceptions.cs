using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdHouseHW
{
    internal class InputException : Exception // exception thrown when error in input
    {
        public InputException(string message) : base(message) { }
    }

    internal class NoPlaceForLunchFoundException : Exception // exception thrown when no place for lunch found
    {
        public NoPlaceForLunchFoundException(string message) : base (message) { }
    }
}
