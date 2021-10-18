using System;
using System.Collections.Generic;
using System.Text;

namespace Shirt
{
    class Bear
    {

        public string Name { get; set; }
        public int DaysSinceEaten { get; set; }
        public int  Age { get; set; }

        public void Eat()
        {
            Console.WriteLine($"The bear {Name} just ate and is happy!");
        }
    }
}
