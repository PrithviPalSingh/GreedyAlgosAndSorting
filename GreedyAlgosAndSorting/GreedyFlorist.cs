using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedyAlgosAndSorting
{
    class GreedyFlorist
    {
        public static long getMinimumCost(int k, long[] c)
        {
            long m = (long)Math.Ceiling((decimal)(c.Length) / k);
            long sum = 0;
            Array.Sort(c);
            List<long> c1 = c.Reverse().ToList<long>();

            long multipier = 1;
            long loop = 0;
            for (int j = 0; loop < m; j = j + k)
            {
                for (int i = j; i < j + k && i < c1.Count; i++)
                {
                    sum += c1[i] * multipier;
                }
                loop++;
                multipier++;
            }


            return sum;
        }
    }
}
