using System;

namespace AuthorProblem
{
    [Author("azz")]
  public  class StartUp
    {
        [Author("ti")]

      public  static void Main(string[] args)
        {
            Tracker tracker = new Tracker();

            tracker.PrintMethodByAuthor();
        }

      [Author("Dimitrichko")]
      private static void NextGen()
      {

      }
    }
}
