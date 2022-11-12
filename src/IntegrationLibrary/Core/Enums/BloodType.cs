using System;

namespace IntegrationLibrary.Core.Enums
{
    public enum BloodType
    {
        A_PLUS,
        A_MINUS,
        B_PLUS,
        B_MINUS,
        O_PLUS, 
        O_MINUS,
        AB_PLUS, 
        AB_MINUS,
        NONE
    }

    public class InvalidBloodTypeException : Exception
    {
        public InvalidBloodTypeException(string message) : base(message) { }
    }
}
