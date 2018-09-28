using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedyAlgosAndSorting
{
    class IceCreamParlor
    {
        static void whatFlavors(int[] cost, int money)
        {
            int n = cost.Length;
            for (int i = 0; i < n - 1; i++)
            {
                var remaining = money - cost[i];

                for (int j = i + 1; j < n; j++)
                {
                    if (cost[j] == remaining)
                    {
                        var inner = i + 1;
                        var outer = j + 1;
                        Console.WriteLine(inner + " " + outer);
                        return;
                    }
                }
            }
        }

        public static int Fibonacci(int n)
        {

            if (n == 0)
                return 0;

            if (n == 1)
                return 1;

            return Fibonacci(n - 1) + Fibonacci(n - 2);

        }

        public static int stepPerms(int n)
        {
            int[] arr = new int[n];
            return Func(arr, n);
        }

        public static int Func(int[] arr, int n)
        {
            if (n <= 0)
                return 0;

            if (n == 1)
            {
                arr[n - 1] = 1;
                return 1;
            }

            if (n == 2)
            {
                arr[n - 1] = 2;
                return 2;
            }

            if (n == 3)
            {
                arr[n - 1] = 4;
                return 4;
            }

            if (arr[n - 1] != 0)
                return arr[n - 1];
            else arr[n - 1] = Func(arr, n - 3) + Func(arr, n - 2) + Func(arr, n - 1);


            return arr[n - 1];
        }

        public static long flippingBits(long n)
        {
            var item = ConvertIntToBinary(n);
            item = FlipBits(item);
            return ConvertBinaryToInt(item);
        }

        public static int[] ConvertIntToBinary(long n)
        {
            int[] b = new int[32];
            int pos = 31;
            int i = 0;

            while (i < 32)
            {
                //if ((n & (1 << i)) != 0)
                //{
                //    b[pos] = 1;
                //}
                //else
                //{
                //    b[pos] = 0;
                //}

                if (n % 2 == 0)
                {
                    b[pos] = 0;
                }
                else
                {
                    b[pos] = 1;
                }
                n = n / 2;
                pos--;
                i++;
            }

            return b;
        }

        public static int[] FlipBits(int[] b)
        {
            for (int i = 0; i < b.Length; i++)
            {
                if (b[i] == 0)
                    b[i] = 1;
                else
                    b[i] = 0;
            }

            return b;
        }

        public static long ConvertBinaryToInt(int[] b)
        {
            long num = 0;
            for (int i = 0; i < b.Length; i++)
            {
                num += b[b.Length - 1 - i] * (long)Math.Pow(2, i);
            }

            return num;
        }
    }
}
