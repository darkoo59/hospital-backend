using System;

namespace IntegrationLibrary.Features.Blood.Enums
{
    public enum BloodType
    {
        A_PLUS, A_MINUS, B_PLUS, B_MINUS, AB_PLUS, AB_MINUS, O_PLUS, O_MINUS
    }

    public class InvalidBloodTypeException : Exception
    {
        public InvalidBloodTypeException(string message) : base(message) { }
    }
}
