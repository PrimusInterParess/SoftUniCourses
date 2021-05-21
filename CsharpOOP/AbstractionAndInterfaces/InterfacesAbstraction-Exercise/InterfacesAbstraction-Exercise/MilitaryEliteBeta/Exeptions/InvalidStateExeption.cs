using System;

namespace MilitaryElite.Exeptions
{
    public class InvalidStateExeption:Exception
    {
        private const string DEF_EX_MESSEGE = "Invalid state!";

        public InvalidStateExeption()
            : base(DEF_EX_MESSEGE)
        {

        }

        public InvalidStateExeption(string massage)
            : base(massage)
        {

        }
    }
}