using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> reservation = new HashSet<string>();

            bool end = false;

            while (true)
            {
                string data = Console.ReadLine();

                if (data.Length == 8)
                {
                    reservation.Add(data);
                }

                if (data == "PARTY")
                {
                    while (data != "END")
                    {
                        reservation.Remove(data);

                        data = Console.ReadLine();
                    }

                    end = true;

                    break;
                }
            }

            Console.WriteLine(reservation.Count);

            foreach (var item in reservation)
            {
                char[] ch = item.ToCharArray();

                if (char.IsDigit(ch[0]))
                {
                    Console.WriteLine(item);
                }
            }
            foreach (var item in reservation)
            {
                char[] ch = item.ToCharArray();

                if (char.IsLetter(ch[0]))
                {
                    Console.WriteLine(item);
                }
            }


        }
    }
}
