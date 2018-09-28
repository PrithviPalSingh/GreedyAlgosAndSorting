using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedyAlgosAndSorting
{
    class MakingAnagrams
    {
        public static int makeAnagram(string a, string b)
        {
            Dictionary<char, int> first = new Dictionary<char, int>();
            Dictionary<char, int> second = new Dictionary<char, int>();
            int count = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (!first.ContainsKey(a[i]))
                {
                    first.Add(a[i], 1);
                }
                else
                {
                    first[a[i]] += 1;
                }
            }

            for (int i = 0; i < b.Length; i++)
            {
                if (!second.ContainsKey(b[i]))
                {
                    second.Add(b[i], 1);
                }
                else
                {
                    second[b[i]] += 1;
                }
            }

            foreach (var item in first)
            {
                if (second.ContainsKey(item.Key))
                {
                    if (second[item.Key] > first[item.Key])
                    {
                        count += second[item.Key] - first[item.Key];
                    }
                    else if (second[item.Key] < first[item.Key])
                    {
                        count += first[item.Key] - second[item.Key];
                    }
                }
                else
                {
                    count += item.Value;
                }
            }

            foreach (var item in second)
            {
                if (!first.ContainsKey(item.Key))
                {
                    count += item.Value;
                }
            }

            return count;
        }
    }
}
