using System;

namespace EdHouseHW
{
    public class InputException : Exception // exception thrown when error in input
    {
        public InputException(string message) : base(message) { }
    }

    public class NoPlaceForLunchFoundException : Exception // exception thrown when no place for lunch found
    {
        public NoPlaceForLunchFoundException(string message) : base (message) { }
    }
}
