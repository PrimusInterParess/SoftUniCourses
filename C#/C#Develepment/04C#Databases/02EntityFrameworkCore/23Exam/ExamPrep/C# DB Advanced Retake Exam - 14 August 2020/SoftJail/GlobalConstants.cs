using System;
using System.Collections.Generic;
using System.Text;

namespace SoftJail
{
    public static class GlobalConstants
    {

        public const string ErrorMessage = "Invalid Data";
        public const string SuccsessfulImportMessageDepartmentCell = "Imported {0} with {1} cells";
        public const string SuccsessfulImportMessagePrisoner = "Imported {0} {1} years old";


        public const string PrisonerNickNameRegexPattern = @"^The [A-Z]{1}[a-z]+$";
        public const string AddressRegexPattern = @"^[A-Za-z0-9 ]+ str.$";
    }
}
