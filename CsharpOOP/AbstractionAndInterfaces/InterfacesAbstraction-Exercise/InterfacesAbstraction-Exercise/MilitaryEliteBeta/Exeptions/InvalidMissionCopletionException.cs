using System;

namespace MilitaryElite.Exeptions
{
    public class InvalidMissionCopletionException:Exception
    {

        private const string DEF_EX_MESSEGE = "Mission already completed!";

        public InvalidMissionCopletionException()
            : base(DEF_EX_MESSEGE)
        {

        }

        public InvalidMissionCopletionException(string massage)
            : base(massage)
        {

        }
    }

}
