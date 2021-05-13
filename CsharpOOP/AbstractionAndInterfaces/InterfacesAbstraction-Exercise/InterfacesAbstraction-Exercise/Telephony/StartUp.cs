using System;
using System.Collections.Generic;
using System.Linq;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] numbersToCall = Console.ReadLine().Split();

            string[] webSitesToBrows = Console.ReadLine().Split();

            SmartPhone smart = new SmartPhone();

            StationaryPhone statphone = new StationaryPhone();

            foreach (var number in numbersToCall)
            {
                if (number.Length==10)
                {
                    statphone.Call(number);
                }
                else
                {
                    statphone.Call(number);
                }
            }

        }
    }
}
