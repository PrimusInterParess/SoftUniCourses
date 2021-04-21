using System;


namespace CustomRandomList
{
  public  class StartUp
    {
        static void Main(string[] args)
        {
            RandomList list = new RandomList();

            list.Add("Pehso");
            list.Add("gogi");
            list.Add("dodi");
            list.Add("bobi");
            list.Add("toti");
            list.Add("shoti");

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(list.RandomString());
            }
        }
    }
}
