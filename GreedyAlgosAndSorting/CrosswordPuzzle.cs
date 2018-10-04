using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedyAlgosAndSorting
{
    class CrosswordPuzzle
    {
        //static string[] crosswordPuzzle(string[] crossword, string words)
        //{
        //    char[] charArray = words.ToCharArray();
        //    int j = 0;
        //    foreach (var item in crossword)
        //    {
        //        char[] cwItem = item.ToCharArray();

        //        for (int i = 0; i < cwItem.Length; i++)
        //        {
        //            if (cwItem[i] == '-')
        //            {
        //                cwItem[i] = charArray[j];
        //                j++;
        //            }
        //        }
        //    }


        //}

        class QuickUnionUF
        {
            public Dictionary<int, int> array = new Dictionary<int, int>();

            /// <summary>
            /// O(N)
            /// </summary>
            /// <param name="N"></param>
            public QuickUnionUF(int[][] queries)
            {
                foreach (var item in queries)
                {
                    if (!array.ContainsKey(item[0]))
                    {
                        array.Add(item[0], item[0]);
                    }

                    if (!array.ContainsKey(item[1]))
                    {
                        array.Add(item[1], item[1]);
                    }
                }

            }
            /// <summary>
            /// O(N)
            /// </summary>
            /// <param name="num"></param>
            /// <returns></returns>
            private void manipulateroot(int fromId, int toId)
            {
                List<int> keys = new List<int>();

                foreach (var item in array.Keys)
                {
                    if (array[item] == fromId)
                        keys.Add(item);
                }

                foreach (var item in keys)
                {
                    array[item] = toId;
                }
            }

            /// <summary>
            /// O(N)
            /// </summary>
            /// <param name="num"></param>
            /// <returns></returns>
            private int root(int num)
            {
                while (num != array[num])
                {
                    num = array[num];
                }

                return num;
            }

            /// <summary>
            /// O(N)
            /// </summary>
            /// <param name="p"></param>
            /// <param name="q"></param>
            /// <returns></returns>
            public bool Connected(int p, int q, out int pid, out int qid)
            {
                pid = root(p);
                qid = root(q);
                if (pid == qid)
                {
                    //return array.Count(i => i.Value == array[q]);
                    return true;
                }
                else
                {
                    return false;
                }
            }

            /// <summary>
            /// O(N)
            /// </summary>
            /// <param name="p"></param>
            /// <param name="q"></param>
            public int Union(int p, int q, int pid, int qid)
            {
                //int qid = root(q);
                //int pid = root(p);

                var smallerId = qid < pid ? qid : pid;
                var greaterId = pid > qid ? pid : qid;
                if (smallerId != greaterId)
                    manipulateroot(greaterId, smallerId);


                return array.Count(i => i.Value == array[smallerId]);
            }
        }

        // Complete the maxCircle function below.
        public static int[] maxCircle1(int[][] queries)
        {
            List<int> abc = new List<int>();
            List<int> def = new List<int>();
            QuickUnionUF wquuf = new QuickUnionUF(queries);
            List<Dictionary<int, int>> dictList = new List<Dictionary<int, int>>();
            int maximum = 0;
            //wquuf.array = wquuf.array.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            foreach (var item in queries)
            {
                int pid = -1;
                int qid = -1;
                var con = wquuf.Connected(item[0], item[1], out pid, out qid);
                if (!con)
                {
                    //abc.Add(wquuf.Union(item[0], item[1], pid, qid));
                    wquuf.Union(item[0], item[1], pid, qid);
                }
                //else
                //{
                //    abc.Add(pid);
                //}
                //var arr = wquuf.array.ToDictionary(entry => entry.Key,
                //                               entry => entry.Value);
                //dictList.Add(arr);
            }


            //foreach (var item in abc)
            //{
            //    if (maximum < item)
            //    {
            //        maximum = item;
            //    }

            //    def.Add(maximum);
            //}

            //foreach (var item in dictList)
            //{
            //    Dictionary<int, int> vals = new Dictionary<int, int>();
            //    foreach (var j in item.Values)
            //    {
            //        if (!vals.ContainsKey(j))
            //        {
            //            vals.Add(j, 1);
            //        }
            //        else
            //        {
            //            vals[j] += 1;
            //        }
            //    }

            //    def.Add(vals.Values.Max());
            //}


            return def.ToArray<int>();
        }



        /////////////////////**************************//////////////////
        ///
        class UnionFind
        {
            Dictionary<int, int> parents = null;
            Dictionary<int, int> sizes = null;
            public int max;
            public UnionFind()
            {
                parents = new Dictionary<int, int>();
                sizes = new Dictionary<int, int>();
                max = 0;
            }

            public void union(int v1, int v2)
            {
                if (!parents.ContainsKey(v1))
                {
                    parents.Add(v1, v1);
                    sizes.Add(v1, 1);
                }

                if (!parents.ContainsKey(v2))
                {
                    parents.Add(v2, v2);
                    sizes.Add(v2, 1);
                }

                int p1 = find(v1), p2 = find(v2);
                if (p1 == p2) return;
                int s1 = sizes[p1];
                int s2 = sizes[p2];
                if (s1 < s2)
                {
                    parents[p1] = p2;
                    sizes[p2] = s1 + s2;
                    if (s1 + s2 > max) max = s1 + s2;
                }
                else
                {
                    parents[p2] = p1;
                    sizes[p1] = s1 + s2;
                    if (s1 + s2 > max) max = s1 + s2;
                }
            }

            public int find(int v)
            {
                while (parents[v] != v)
                {
                    parents[v] = parents[parents[v]];
                    v = parents[v];
                }
                return v;
            }
        }

        // Complete the maxCircle function below.
        public static int[] maxCircle(int[][] queries)
        {
            UnionFind uf = new UnionFind();
            int[] res = new int[queries.Length];
            for (int i = 0; i < queries.Length; i++)
            {
                uf.union(queries[i][0], queries[i][1]);
                res[i] = uf.max;
            }
            return res;
        }
    }
}

