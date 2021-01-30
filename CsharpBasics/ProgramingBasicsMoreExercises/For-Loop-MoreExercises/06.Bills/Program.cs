using System;

namespace _06.Bills
{
    class Program
    {
        static void Main(string[] args)
        {
            int mounths = int.Parse(Console.ReadLine());
            double electricityBill = 0;
            double elSum = 0;
            double waterbill = 20;
            double internetBill = 15;
            double othersBills = 0;

            for (int i = 1; i <= mounths; i++)
            {
                electricityBill = double.Parse(Console.ReadLine());
                elSum += electricityBill;
                othersBills += (electricityBill + waterbill + internetBill) * 1.20;
            }
            waterbill *= mounths;
            internetBill *= mounths;


            double averageBillsPerMonth = (elSum + waterbill + internetBill + othersBills) / mounths;
            Console.WriteLine($"Electricity: {elSum:f2} lv");
            Console.WriteLine($"Water: {waterbill:f2} lv");
            Console.WriteLine($"Internet: {internetBill:f2} lv");
            Console.WriteLine($"Other: {othersBills:f2} lv");
            Console.WriteLine($"Average: {averageBillsPerMonth:f2} lv");
        }
    }
}
