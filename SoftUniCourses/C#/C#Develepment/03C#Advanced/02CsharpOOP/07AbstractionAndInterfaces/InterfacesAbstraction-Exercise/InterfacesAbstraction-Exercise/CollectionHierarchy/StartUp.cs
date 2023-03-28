using System;
using CollectionHierarchy;
using CollectionHierarchy.Models;

namespace CollectionHierarchy
{
  public  class StartUp
    {
        static void Main(string[] args)
        {

            string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            int numberOfLoops = int.Parse(Console.ReadLine());

            int[,] matrix = new int[3, data.Length];

            string[,] strMatrix = new string[2, numberOfLoops];

            AddCollection addCollection = new AddCollection();


            AddRemoveCollection addRemoveCollection = new AddRemoveCollection();

            MyList myList = new MyList();

            for (int col = 0; col < data.Length; col++)
            {
                matrix[0, col] = addCollection.Add(data[col]);
                matrix[1, col] = addRemoveCollection.Add(data[col]);
                matrix[2, col] = myList.Add(data[col]);
            }


            for (int col = 0; col < numberOfLoops; col++)
            {
                strMatrix[0, col] = addRemoveCollection.Remove();
                strMatrix[1, col] = myList.Remove();
            }


            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }

            for (int row = 0; row < 2; row++)
            {
                for (int col = 0; col < strMatrix.GetLength(1); col++)
                {
                    Console.Write(strMatrix[row, col] + " ");
                }

                Console.WriteLine();
            }



        }


    }
}
