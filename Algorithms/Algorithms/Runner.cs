using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    /// <summary>
    /// Runs the Main for the Algorithms library.
    /// </summary>
    static class Runner
    {

        private static void Main(String[] Args)
        {
            List<int> numList = new List<int>();
            string holder;
            int inputVal;

            // First Loop adds numbers to a list based on user input
            Console.WriteLine("Input numbers, type 'done' when complete.");
            while (true)
            {
                holder = Console.ReadLine();
                if (holder == "done") { break; }
                // Attempt to convert the user input into an integer.
                try
                {
                    inputVal = Convert.ToInt32(holder);
                    numList.Add(inputVal);
                }
                // If the user inputs something that is not an int
                // catch and handle it accordingly.
                catch (FormatException e)
                {
                    Console.WriteLine("Make sure you input a number");
                }
                // If the user inputs a number that is too large to
                // to fit in the 32bit allocation, handle it accordingly.
                catch (OverflowException e)
                {
                    Console.WriteLine("Sorry, that number was too large.");
                }
            }

            // Second loop performs Algorithmic operations based on
            // users commands.
            Console.WriteLine("You can now perform algorithmic operations on your list.");
            Console.WriteLine("Type 'print' to print your list.");
            Console.WriteLine("Type 'sort' to sort your list.");
            Console.WriteLine("Type 'merge' to merge sort your list.");
            Console.WriteLine("Type 'binary search' to search for an element. Sort the list first!");
            Console.WriteLine("Type 'quick sort' to quick sort your list.");

            while (true)
            {
                holder = Console.ReadLine();
                if (holder == "exit") { break; }
                Algorithms.selectAlg(holder, numList);
            }
        }
    }
}
