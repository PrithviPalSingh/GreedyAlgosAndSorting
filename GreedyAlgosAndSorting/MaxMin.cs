using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedyAlgosAndSorting
{
    class MaxMin
    {
        public static int maxMin(int k, int[] arr)
        {
            Array.Sort(arr);
            int min = arr[k - 1] - arr[0];
            for (int i = 1; i < arr.Length - k + 1; i++)
            {
                if (arr[i + k - 1] - arr[i] < min)
                    min = arr[i + k - 1] - arr[i];
            }

            Console.WriteLine(min);
            return min;
        }
    }
}
