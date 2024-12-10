using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WDTimeComplexity
{
    public class TimeComplexityExamples
    {
        //constant time O(1)
        public int GetFirstElement(int[] arr) // Accessing the first element of the array.
        {
            return arr[0]; // No matter how large the array is, it takes the same amount of time.
        }

        //Linear time O(n)
        public void PrintElements(int[] arr) // Loops through each element in the array.
        {
            foreach (int element in arr)
            {
                Console.WriteLine(element);
            }
            // As the array size increases, the loop will run more and more, so the run time is proportional to the array size

        }
        //Quadratic Time O(n2)

        public void PrintPairs(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++) // Outer loop goes through each element of the array.
            {
                for (int j = 0; j < arr.Length; j++)  // Inner loop does the same but for every iteration of the outer loop.
                {
                    Console.WriteLine(arr[i]+ ","+arr[j]); // For every element 'i', print all pairs (i, j).
                }
                // Since there are two loops, the time taken increases quadratically
            }
        }
    }
}
