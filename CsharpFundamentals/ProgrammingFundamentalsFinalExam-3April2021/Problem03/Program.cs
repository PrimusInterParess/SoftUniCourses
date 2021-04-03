using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem03
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfMessages = int.Parse(Console.ReadLine());

            string input = string.Empty;

            Dictionary<string, Dictionary<string, int>> messageRecords =
                new Dictionary<string, Dictionary<string, int>>();

            while ((input=Console.ReadLine())!="Statistics")
            {
                string[] data = input.Split("=", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string command = data[0];

                if (command=="Add")
                {
                    string userName = data[1];

                    int sent = int.Parse(data[2]);

                    int receivedMessages = int.Parse(data[3]);

                    if (!messageRecords.ContainsKey(userName))
                    {
                        messageRecords[userName].Add("sent", sent);
                        messageRecords[userName].Add("receivedMessages", receivedMessages);

                    }
                }
                else if (command == "Message")
                {

                }
                else if (command == "Empty")
                {

                }
            }
        }
    }
}
