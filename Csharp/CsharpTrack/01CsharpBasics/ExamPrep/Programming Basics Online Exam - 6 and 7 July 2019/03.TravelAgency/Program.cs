using System;

namespace _03.TravelAgency
{
    class Program
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();
            string packetType = Console.ReadLine();
            string vipDiscount = Console.ReadLine();
            int numberOfDays = int.Parse(Console.ReadLine());
            double pricePerNight = 0;


            if (numberOfDays > 7)
            {
                numberOfDays--;
            }

            if (numberOfDays < 1)
            {
                Console.WriteLine("Days must be positive number!");
                return;
            }

            if (destination == "Bansko" || destination == "Borovets")
            {

                if (packetType == "withEquipment")
                {
                    pricePerNight = 100;

                    if (vipDiscount == "yes")
                    {
                        pricePerNight *= 0.90;
                    }
                }
                else if (packetType == "noEquipment")
                {
                    pricePerNight = 80;

                    if (vipDiscount == "yes")
                    {
                        pricePerNight *= 0.95;
                    }
                }
            }
            else if (destination == "Varna" || destination == "Burgas")
            {
                if (packetType == "withBreakfast")
                {
                    pricePerNight = 130;

                    if (vipDiscount == "yes")
                    {
                        pricePerNight *= 0.88;
                    }
                }
                else if (packetType == "noBreakfast")
                {
                    pricePerNight = 100;

                    if (vipDiscount == "yes")
                    {
                        pricePerNight *= 93;
                    }
                }
            }
            else if (destination != "Bansko" || destination != "Borovets" || destination != "Varna" || destination != "Burgas" || packetType != "withEquipment" || packetType != "noEquipment" || packetType != "withBreakfast" || packetType != "noBreakfast")
            {
                Console.WriteLine("Invalid input!");
                return;
            }

            double total = pricePerNight * numberOfDays;
            Console.WriteLine($"The price is {total:f2}lv! Have a nice time!");

        }

    }
}
}
