using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.GenericBoxOfString
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

<<<<<<< HEAD
            List<double> list = new List<double>();
=======
            List<double> strings = new List<double>();
>>>>>>> aa55df6124baaed060968785d44dc2aa03ed3e4a

            for (int i = 0; i < n; i++)
            {
                double input = double.Parse(Console.ReadLine());

<<<<<<< HEAD
               list.Add(input);

            }

            Box<double> newBox = new Box<double>(list);

            double indx = double.Parse(Console.ReadLine());

           

            Console.WriteLine(newBox.Count(indx));
=======
                strings.Add(input);
            }

            double toCompare = double.Parse(Console.ReadLine());


            Box<double> strigBox = new Box<double>(strings);

            Console.WriteLine(strigBox.CountGreaterElements(toCompare));
          

           





>>>>>>> aa55df6124baaed060968785d44dc2aa03ed3e4a

        }
    }
}
