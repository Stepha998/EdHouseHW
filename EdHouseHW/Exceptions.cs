using System;

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
