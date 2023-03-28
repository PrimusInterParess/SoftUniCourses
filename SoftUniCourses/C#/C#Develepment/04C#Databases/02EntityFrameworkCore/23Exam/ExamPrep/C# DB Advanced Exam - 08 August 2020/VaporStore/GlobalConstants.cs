using System;
using System.Collections.Generic;
using System.Text;

namespace VaporStore
{
    public static class GlobalConstants
    {
        //Game 
        public const string Min_Price_Range = "0.0";
        public const string Max_Price_Range = "79228162514264337593543950335";

        //Error message

        public const string ErrorMessage = "Invalid Data";

        //Successful message 

        public const string SuccsessfulMessageGameImport = "Added {0} ({1}) with {2} tags";

        //User

        public const string FullNameRegexPattern = @"^[A-Z][a-z]+ [A-Z][a-z]+$";

        public const string SuccsessfulMessageUserImport = "Imported {0} with {1} cards";

        //Card 

        public const string CardNumberRegexPattern = @"^[0-9]{4}\ [0-9]{4}\ [0-9]{4}\ [0-9]{4}$";
        public const string CVCRegexPattern = @"^[0-9]{3}$";

        //Purchase

        public const string ProductKeyRegexPattern = @"^[A-Z0-9]{4}\-[A-Z0-9]{4}\-[A-Z0-9]{4}$";

        public const string SuccsessfulMessagePurchaseImport = "Imported {0} for {1}";



    }
}
