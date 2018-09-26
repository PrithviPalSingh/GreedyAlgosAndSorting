using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedyAlgosAndSorting
{
    class MinimumAbsDifference
    {
        static int minimumAbsoluteDifference(int[] arr)
        {
            Array.Sort(arr);
            int min = arr[1] - arr[0];
            for (int i = 1; i < arr.Length - 1; i++)
            {
                if (arr[i+1] - arr[i] < min)
                    min = arr[i + 1] - arr[i];
            }

            return min;
        }
    }
}
