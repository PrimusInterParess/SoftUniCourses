using System;

namespace demo
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] _items = new int[8];

            int Count = 6;

            int index = 3;

            int item = 777;

            for (int i = 0; i < 6; i++)
            {
                _items[i] = i;
            }



            for (int i = Count; i > index; i--)
            {
                _items[i] = _items[i - 1];
            }

            _items[index] = item;
        }
    }
}
