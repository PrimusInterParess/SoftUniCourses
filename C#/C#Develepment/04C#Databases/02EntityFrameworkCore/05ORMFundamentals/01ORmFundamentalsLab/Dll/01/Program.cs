using System;
using _03CodeFirstDemo.Models;

namespace _01
{
    class Program
    {
        static void Main(string[] args)
        {

            ApplicationDBContext api = new ApplicationDBContext();

            api.Database.EnsureCreated();

        }
    }
}
