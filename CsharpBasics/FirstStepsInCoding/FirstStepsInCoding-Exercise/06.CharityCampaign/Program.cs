using System;

namespace _06.CharityCampaign
{
    class Program
    {
        static void Main(string[] args)
        {
            double numDays = double.Parse(Console.ReadLine());

            double numConfectioner = double.Parse(Console.ReadLine());

            double numCakes = double.Parse(Console.ReadLine());

            double numWaffles = double.Parse(Console.ReadLine());

            double numPanckes = double.Parse(Console.ReadLine());

            double cakesPerDay = numCakes * 45;

            double wafflesPerDay = numWaffles * 5.80;

            double panckakesPerDay = numPanckes * 3.20;

            double sumForADay = (cakesPerDay + wafflesPerDay + panckakesPerDay) * numConfectioner;

            double wholeCampaignTotal = sumForADay * numDays;

            double sumAfterExpencesTotal = wholeCampaignTotal - (wholeCampaignTotal / 8);

            Console.WriteLine(sumAfterExpencesTotal);
        }
    }
}
