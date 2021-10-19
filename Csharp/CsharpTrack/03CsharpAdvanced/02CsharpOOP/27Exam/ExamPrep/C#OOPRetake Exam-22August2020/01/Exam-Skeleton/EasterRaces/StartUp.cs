using System;
using EasterRaces.Core;
using EasterRaces.Core.Contracts;
using EasterRaces.IO;
using EasterRaces.IO.Contracts;
using EasterRaces.Core.Entities;

namespace EasterRaces
{
    public class StartUp
    {
        public static void Main()
        {
            IChampionshipController controller =  new ChampionshipController();
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter(); //new StringBuilderWriter();

            Engine enigne = new Engine(controller, reader, writer);
            enigne.Run();

          //  Console.Clear();

            //Console.WriteLine(writer);
        }
    }
}
