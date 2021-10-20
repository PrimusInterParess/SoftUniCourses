using System;
using _03CodeFirstDemo.Models;

namespace _03CodeFirstDemo
{
  public  class StartUp
    {
        static void Main(string[] args)
        {
            ApplicationDBContext api = new ApplicationDBContext();

            api.Database.EnsureCreated();
        }
    }
}
