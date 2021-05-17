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
                try
                {

                    string res =
                        number.Length == 10 ? 
                            smart.Call(number) : 
                            statphone.Call(number);

                    Console.WriteLine(res);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }


            foreach (var url in webSitesToBrows)
            {
                try
                {
                   var res = smart.Browse(url);
                    Console.WriteLine(res);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                    
                }
            }
        }
    }
}
