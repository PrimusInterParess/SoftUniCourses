using System;

namespace _01.DataTypeFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var input = Console.ReadLine();
                string dataType = "";
                if (input == "END")
                {
                    break;
                }
                try
                {
                    int number = int.Parse(input);
                    dataType = "integer";
                }
                catch (FormatException)
                {
                    try
                    {
                        double number = double.Parse(input);
                        dataType = "floating point";
                    }
                    catch (FormatException)
                    {
                        try
                        {
                            char number = char.Parse(input);
                            dataType = "character";
                        }
                        catch (FormatException)
                        {
                            try
                            {
                                bool number = bool.Parse(input);
                                dataType = "boolean";
                            }
                            catch (FormatException)
                            {
                                dataType = "string";
                            }
                        }
                    }
                }
                Console.WriteLine($"{input} is {dataType} type");
            }
        }
    }
}
