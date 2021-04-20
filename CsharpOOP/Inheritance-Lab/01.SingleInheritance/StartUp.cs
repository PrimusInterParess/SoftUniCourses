using System;

namespace Farm
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            Puppy doggy = new Puppy();

            doggy.Eat();
            doggy.Bark();
            doggy.Weep();

            Cat catty = new Cat();

            catty.Eat();
            catty.Meow();
        }
    }
}
