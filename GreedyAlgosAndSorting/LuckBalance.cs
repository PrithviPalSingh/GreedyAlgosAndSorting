using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedyAlgosAndSorting
{
    class LuckBalance
    {
        static int luckBalance(int k, int[][] contests)
        {
            int lucksum = 0;
            List<int> Ones = new List<int>();
            List<int> Zeros = new List<int>();
            foreach (var item in contests)
            {
                switch (item[1])
                {
                    case 0:
                        Zeros.Add(item[0]);
                        break;
                    case 1:
                        Ones.Add(item[0]);
                        break;
                }
            }

            foreach (var item in Zeros)
            {
                lucksum += item;
            }

            Ones.Sort();

            foreach (var item in Ones)
            {
                lucksum += item;
            }

            if (Ones.Count > k)
            {
                for (int i = Ones.Count - k - 1; i >= 0; i--)
                {
                    lucksum -= 2 * Ones[i];
                }
            }

            return lucksum;
        }
    }
}
