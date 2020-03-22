using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Coctail_Sort
{
    class Sort
    {
        public static void Swap(ref int first, ref int second)
        {
            int temp;
            temp = second;
            second = first;
            first = temp;
        }

        public static void Coctail(ref int[] digits)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            int left;
            int right;

            left = 0;
            right = digits.Length - 1;
            while (left < right)
            {
                for (int i = 0; i < digits.Length; i += 1)
                {
                    if (i < digits.Length - 1)
                    {
                        if (digits[i].CompareTo(digits[i + 1]) == 1)
                        {
                            Swap(ref digits[i], ref digits[i + 1]);
                        }
                    }
                }
                right--;
                for (int i = digits.Length - 2; i > 0; i -= 1)
                {
                    if (digits[i].CompareTo(digits[i - 1]) == -1)
                    {
                        Swap(ref digits[i], ref digits[i - 1]);
                    }
                }
                left++;
            }
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("Hours : {0:00};\nMinutes : {1:00};\nSeconds : {2:00};\nMilleseconds : {3:00};",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int[] digits = new int[10000];
            Random rnd = new Random();

            for (int i = 0; i < digits.Length; i += 1)
            {
                digits[i] = rnd.Next(0, 100000);
            }

            Sort.Coctail(ref digits);
            Console.ReadLine();
        }
    }
}
