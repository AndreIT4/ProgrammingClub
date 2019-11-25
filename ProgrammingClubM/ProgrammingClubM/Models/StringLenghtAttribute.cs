using System;

namespace ProgrammingClubM.Models
{
    internal class StringLenghtAttribute : Attribute
    {
        private int v;
        private string errorMessage;

        public StringLenghtAttribute(int v, string ErrorMessage)
        {
            this.v = v;
            errorMessage = ErrorMessage;
        }
    }
}