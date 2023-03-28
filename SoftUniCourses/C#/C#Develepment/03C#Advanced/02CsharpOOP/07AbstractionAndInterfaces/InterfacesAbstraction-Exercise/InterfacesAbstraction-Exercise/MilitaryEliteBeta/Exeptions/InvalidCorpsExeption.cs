using System;

namespace MilitaryElite.Exeptions
{
    public class InvalidCorpsExeption:Exception
    {
        private const string DEF_EX_MESSEGE = "Invalid corps!";

        public InvalidCorpsExeption()
        :base(DEF_EX_MESSEGE)
        {
            
        }

        public InvalidCorpsExeption(string massage)
        :base(massage)
        {
            
        }
    }
}