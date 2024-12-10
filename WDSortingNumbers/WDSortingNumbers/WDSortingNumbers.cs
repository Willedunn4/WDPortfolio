using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WDSortingNumbers
{
    internal class WDSortingNumbers
    {
        static void Main()
        {
            // Generate a random list of numbers
            List<int> randomNumbers = GenerateRandomNumbers(10, 1, 100);

            Console.WriteLine("Original List: ");
            PrintList(randomNumbers);

            // Perform and display Selection Sort
            List<int> selectionSorted = new List<int>(randomNumbers);
            SelectionSort(selectionSorted);
            Console.WriteLine("\nSelection Sort:");
            PrintList(selectionSorted);

            // Perform and display Insertion Sort
            List<int> insertionSorted = new List<int>(randomNumbers);
            InsertionSort(insertionSorted);
            Console.WriteLine("\nInsertion Sort:");
            PrintList(insertionSorted);

            // Perform and display Bubble Sort
            List<int> bubbleSorted = new List<int>(randomNumbers);
            BubbleSort(bubbleSorted);
            Console.WriteLine("\nBubble Sort:");
            PrintList(bubbleSorted);
        }

        static List<int> GenerateRandomNumbers(int count, int min, int max)
        {
            Random rand = new Random();
            List<int> numbers = new List<int>();
            for (int i = 0; i < count; i++)
            {
                numbers.Add(rand.Next(min, max + 1));
            }
            return numbers;
        }

        static void SelectionSort(List<int> list)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[j] < list[minIndex])
                    {
                        minIndex = j;
                    }
                }
                // Swap elements
                int temp = list[i];
                list[i] = list[minIndex];
                list[minIndex] = temp;
            }
        }

        static void InsertionSort(List<int> list)
        {
            for (int i = 1; i < list.Count; i++)
            {
                int key = list[i];
                int j = i - 1;

                // Shift elements of list that are greater than key
                while (j >= 0 && list[j] > key)
                {
                    list[j + 1] = list[j];
                    j--;
                }
                list[j + 1] = key;
            }
        }

        static void BubbleSort(List<int> list)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                for (int j = 0; j < list.Count - i - 1; j++)
                {
                    if (list[j] > list[j + 1])
                    {
                        // Swap elements
                        int temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;
                    }
                }
            }
        }

        static void PrintList(List<int> list)
        {
            Console.WriteLine(string.Join(", ", list));
        }
    }
}
