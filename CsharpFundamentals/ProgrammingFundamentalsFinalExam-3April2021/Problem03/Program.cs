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

            while ((input = Console.ReadLine()) != "Statistics")
            {
                string[] data = input.Split("=", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string command = data[0];

                if (command == "Add")
                {
                    string userName = data[1];

                    int sent = int.Parse(data[2]);

                    int receivedMessages = int.Parse(data[3]);

                    if (!messageRecords.ContainsKey(userName))
                    {
                        messageRecords.Add(userName, new Dictionary<string, int>());

                        messageRecords[userName].Add("sent", sent);
                        messageRecords[userName].Add("received", receivedMessages);

                    }
                }
                else if (command == "Message")
                {
                    string sender = data[1];

                    string receiver = data[2];

                    if (messageRecords.ContainsKey(sender) && messageRecords.ContainsKey(receiver))
                    {
                        messageRecords[sender]["sent"]++;
                        messageRecords[receiver]["received"]++;

                        int totalMessegeSender = messageRecords[sender]["sent"] + messageRecords[sender]["received"];
                        int totalMessegeReceiver = messageRecords[receiver]["sent"] + messageRecords[receiver]["received"];

                        if (totalMessegeSender == numberOfMessages)
                        {

                            Console.WriteLine($"{sender} reached the capacity!");

                            messageRecords.Remove(sender);
                        }

                        if (totalMessegeReceiver == numberOfMessages)
                        {
                            Console.WriteLine($"{receiver} reached the capacity!");

                            messageRecords.Remove(receiver);
                        }
                    }

                }
                else if (command == "Empty")
                {
                    string whomToDelete = data[1];

                    if (whomToDelete == "All")
                    {
                        messageRecords.Clear();
                    }
                    else
                    {
                        messageRecords.Remove(whomToDelete);
                    }
                }
            }

            Console.WriteLine($"Users count: {messageRecords.Count}");

            if (messageRecords.Count != 0)
            {
                foreach (var pair in messageRecords.OrderByDescending(p=>p.Value["received"]).ThenBy(p=>p.Key))
                {
                    int massegesSum = pair.Value["sent"] + pair.Value["received"];

                    Console.WriteLine($"{pair.Key} - {massegesSum}");
                }
            }
        }
    }
}
