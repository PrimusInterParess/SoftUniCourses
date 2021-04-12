using System;
using System.Collections;
using System.Collections.Generic;

namespace yieledRNumbs
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerator<int> enumerator = GetNum().GetEnumerator();

            var result = 0;

            enumerator.MoveNext();

            result += enumerator.Current;

            enumerator.MoveNext();


            result += enumerator.Current;

            enumerator.MoveNext();

            result += enumerator.Current;

            Console.WriteLine(result);


        }

        static IEnumerable<int> GetNum()
        {
            yield return 5;

            Console.WriteLine("After first return");

            yield return 6;
            yield return 7;
            yield return 8;
            yield return 9;
        }

        private class GetNumsEnumerator : IEnumerator<int>
        {
            private int index = -1;


            public bool MoveNext()
            {
                index++;

                if (index >= 3)
                {
                    return false;
                }
                return true;
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }

            public int Current
            {
                get
                {
                    if (index == 0)
                    {
                        return 5;
                    }

                    if (index == 1)
                    {
                        return 8;
                    }

                    return -1;
                }
            }

            object? IEnumerator.Current => Current;

            public void Dispose()
            {
                throw new NotImplementedException();
            }
        }
    }
}
