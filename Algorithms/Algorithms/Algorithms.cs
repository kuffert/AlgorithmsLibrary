using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    /// <summary>
    /// A Library to perform algorithmic operations on Arrays, Lists, Trees, etc.
    /// @author Chris Kuffert
    /// @date 11.5.14
    /// </summary>
    public static class Algorithms
    {
        /// <summary>
        /// A simple O(n^2) sorting algorithm. Sorts a list from smallest to largest.
        /// </summary>
        /// <param name="list">The list to be sorted.</param>
        /// <returns>The modified list</returns>
        public static List<int> simpleSort(List<int> list)
        {
            // Check for an empty list
            if (list.Count < 1) { return list; }
            // Checks for bad input
            if (list == null)   { throw new NullReferenceException(); }

            // Begin sorting here 
            int i, k;
            for (i = 0; i < list.Count; i++)
            {
                for (k = i+1; k < list.Count; k++)
                {
                    if (list[i] > list[k])
                    {
                        int temp = list[i];
                        list[i] = list[k];
                        list[k] = temp;
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// Merge sort is a sorting algorithm which is based on Divide-and-conquer paradigm. 
        /// The algorithm divides the array in two halves in each step and recursively calls 
        /// itself on the two halves. And then merges two sorted halves. The mergeArray() 
        /// function is used to merge two sorted arrays.
        /// </summary>
        /// <param name="list">The list of integers to be sorted.</param>
        /// <param name="low">The lowing location on the list of integers.</param>
        /// <param name="high">The high location on the list of integers.</param>
        public static void mergeSort(List<int> list, int low, int high)
        {
            if (low < high)
            {
                int mid = low + (high - low) / 2;     // Find midpoint
                mergeSort(list, low, mid);            // Recur through Left side
                mergeSort(list, mid + 1, high);       // Recur through right side
                mergeHelper(list, low, mid, high);    // Sort this section
            }
        }


        /// <summary>
        /// Helper method for mergeSort that combines two sorted lists.
        /// </summary>
        /// <param name="list">The list of integers to be sorted.</param>
        /// <param name="low">The lowbound on the list of integers.</param>
        /// <param name="middle">The middlebound on the list of integers.</param>
        /// <param name="high">The highbound on the list of integers.</param>
        public static void mergeHelper(List<int> list, int low, int middle, int high)
        {
            // Temporary Array to hold the values in the correct order.
            int[] temp = new int[high - low + 1];

            int i = low, j = middle + 1, k = 0;

            // In this loop, iterate from the low bound to the mid bound and from the
            // midbound to the highbound at the same time. Add the lower of the two
            // values to the array, increment and continue.
            while (i <= middle && j <= high)
            {
                if (list[i] < list[j])
                {
                    temp[k] = list[i];
                    k++;
                    i++;
                }
                else
                {
                    temp[k] = list[j];
                    k++;
                    j++;
                }
            }

            // Loop through the remaining values in the first half and add them to the array.
            while (i <= middle)
            {
                temp[k] = list[i];
                k++;
                i++;
            }

            // Loop through the remaining values in the second half and add them to the array.
            while (j <= high)
            {
                temp[k] = list[j];
                k++;
                j++;
            }

            k = 0;
            i = low;
            // Copy the values from the array (which are now sorted) back into the list.
            while (k < temp.Length && i <= high)
            {
                list[i] = temp[k];
                i++;
                k++;
            }
        }

        /// <summary>
        /// For binary search, the array should be arranged in ascending or descending order. 
        /// In each step, the algorithm compares the search key value with the key value of 
        /// the middle element of the array. If the keys match, then a matching element has 
        /// been found and its index, or position, is returned.
        /// </summary>
        /// <param name="list">The list being searched.</param>
        /// <param name="low">The lower bound of the list.</param>
        /// <param name="high">The upper bound of the list.</param>
        /// <param name="val">The value being searched for.</param>
        public static int binarySearch(List<int> list, int low, int high, int val)
        {
            int middle;

            while (low <= high)
            {
                middle = low + (high - low) / 2;
                // If the value being searched for is higher than the current point,
                // then we shift the value of the low bound to be one step after the mid.
                if (list[middle] < val)
                {
                    low = middle + 1;
                    continue;
                }
                // If the value being searched for is lower than the current point,
                // then we shift the value of the high bound to be one step before the mid.
                if (list[middle] > val)
                {
                    high = middle - 1;
                    continue;
                }
                // If neither of the other conditions hold true, then the mid element
                // must be the target value.
                else
                {
                    return middle;
                }
            }
            return -1;
        }

        /// <summary>
        /// Quicksort is a divide and conquer algorithm. Quicksort first divides a large 
        /// array into two smaller sub-arrays: the low elements and the high elements. 
        /// Quicksort can then recursively sort the sub-arrays.
        /// </summary>
        /// <param name="list">The list being sorted.</param>
        /// <param name="low">The left bound.</param>
        /// <param name="high">The right bound.</param>
        public static void quickSort(List<int> list, int low, int high)
        {
            int i = low;
            int j = high;
            IComparable pivot = list[(low + high) / 2];
            
            while (i <= j)
            {
                // Compare the value at i with the pivot.
                // If it is still less than the pivot value,
                // Then increment the index location and
                // look at the next element.
                while (list[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                // Same as above, but starting from the
                // end of the list and moving backwards.
                while (list[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                // Swap the values at the two indices.
                if (i <= j)
                {
                    int tmp = list[i];
                    list[i] = list[j];
                    list[j] = tmp;

                    // Decrement the gap
                    i++;
                    j--;
                }
            }

            // Check and run quickSort again recursively on the left and
            // right sublists.
            if (low < j)
            {
                quickSort(list, low, j);
            }

            if (i < high)
            {
                quickSort(list, i, high);
            }
        }

        /// <summary>
        /// Based on the given input, selects and performs the algorithm
        /// requested.
        /// </summary>
        /// <param name="s">The reuqested operation.</param>
        /// <param name="list">The list if integers to be manipulated.</param>
        /// <returns>The modified (or unmodified) list of integers.</returns>
        public static List<int> selectAlg(String s, List<int> list)
        {
            if (s == "print")
            {
                printList(list);
            }
            if (s == "sort")
            {
                simpleSort(list);
                printList(list);
            }
            if (s == "merge")
            {
                mergeSort(list, 0, list.Count - 1);
                printList(list);
            }
            if (s == "quick sort")
            {
                quickSort(list, 0, list.Count - 1);
                printList(list);
            }
            if (s == "binary search")
            {
                Console.WriteLine("Enter a number to search for.");
                while (true)
                {
                    try
                    {
                        string value = Console.ReadLine();
                        int intVal = Convert.ToInt32(value);
                        int index = binarySearch(list, 0, list.Count, intVal);
                        Console.WriteLine("The index of element " + intVal + " is " + index);
                        break;
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("Please enter a valid number.");
                    }
                }

            }
            return list;
        }

        /// <summary>
        /// Prints out the given list.
        /// </summary>
        /// <param name="list">The list to be printed out.</param>
        public static void printList(List<int> list)
        {
            string outputString = "";
            for (int i = 0; i < list.Count; i++)
            {
                outputString = outputString + list[i] + " ";
            }
            Console.WriteLine(outputString);
        }
    }
}
