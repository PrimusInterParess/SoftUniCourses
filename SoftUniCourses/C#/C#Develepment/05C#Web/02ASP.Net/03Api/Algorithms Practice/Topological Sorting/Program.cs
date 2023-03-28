namespace Topological_Sorting
{
    public class Program
    {
        private static Dictionary<string, List<string>> graph;

        static void Main(string[] args)
        {
            var leves = int.Parse(Console.ReadLine());

            graph = ReadGraph(leves);
            ;
        }

        static Dictionary<string, List<string>> ReadGraph(int levels)
        {
            Dictionary<string, List<string>> toReturn = new Dictionary<string, List<string>>();

            for (int i = 0; i < levels; i++)
            {
                var inputData = Console
                    .ReadLine()
                    .Split("->",StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (inputData.Length==1)
                {
                    toReturn[inputData[0]]=new List<string>();
                }
                else
                {
                    toReturn[inputData[0]] = inputData[1]
                        .Split(" ,", StringSplitOptions.RemoveEmptyEntries)
                        .ToList();
                }

            }

            return toReturn;
        }
    }
}