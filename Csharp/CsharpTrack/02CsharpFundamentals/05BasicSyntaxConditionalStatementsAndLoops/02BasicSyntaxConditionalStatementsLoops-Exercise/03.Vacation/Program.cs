using System;

namespace _03.Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            string groupType = Console.ReadLine();
            string day = Console.ReadLine();

            double price = 0;


            switch (groupType)
            {
                case "Students":
                    switch (day)
                    {
                        case "Friday":
                            price = 8.45;
                            break;
                        case "Saturday":
                            price = 9.80;
                            break;
                        case "Sunday":
                            price = 10.46;
                            break;
                    }
                    break;
                case "Business":
                    switch (day)
                    {
                        case "Friday":
                            price = 10.90;
                            break;
                        case "Saturday":
                            price = 15.60;
                            break;
                        case "Sunday":
                            price = 16;
                            break;
                    }
                    break;
                case "Regular":
                    switch (day)
                    {
                        case "Friday":
                            price = 15;
                            break;
                        case "Saturday":
                            price = 20;
                            break;
                        case "Sunday":
                            price = 22.50;
                            break;
                    }
                    break;

            }

            double sum = numberOfPeople * price;

            if (groupType == "Students" && numberOfPeople >= 30)
            {
                sum *= 0.85;
            }
            if (groupType == "Business" && numberOfPeople >= 100)
            {
                sum = -(10 * price);
            }
            if (groupType == "Regular" && numberOfPeople >= 10 && numberOfPeople <= 20)
            {
                sum *= 0.95;
            }

            Console.WriteLine($"Total price: {sum:f2}");
        }
    }
}
