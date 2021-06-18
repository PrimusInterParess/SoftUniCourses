using System;
using System.Collections.Generic;
using System.Text;

namespace ListPractice
{
    class StartUp
    {

        static void Main()
        {

            List<int> list = new List<int>();

            list.Add(5);
            list.Add(4);
            list.Add(3);
            list.Add(2);
            list.Add(1);

            list.Insert(4,14);


        }

    }
}
