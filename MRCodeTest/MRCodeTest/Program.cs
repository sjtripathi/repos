using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MRCodeTest
{
    class Program
    {
        private static SortedSet<int> ArrayInt;
        private static long j = 0;
        static void Main(string[] args)
        {
            var watch = Stopwatch.StartNew();
            var lclNumbers = new Numbers();
            Console.WriteLine("Processed : " + j.ToString());
            ArrayInt = new SortedSet<int>();
            while (!lclNumbers.Done())
            {
                var number = lclNumbers.GetNextNumber();
                //Console.WriteLine(number);
                ArrayInt.Add(number);
                AdjustPairs(ArrayInt);
            }
            watch.Stop();
            Console.WriteLine("Total time in millseconds: " + watch.ElapsedMilliseconds.ToString());
            PrintElements(ArrayInt);
            Console.ReadKey();
        }

        private static void PrintElements(SortedSet<int> ArrayInt) {
                Console.WriteLine("========List=========");
                foreach (var item in ArrayInt) Console.WriteLine(item);
                Console.WriteLine("=========List=========");
        }
        private static void AdjustPairs(SortedSet<int> ArrayInt)
        {
            for (int i = 0; i < ArrayInt.Count - 1; i++)
            {
                if (i == ArrayInt.Count-1) break;

                var current = ArrayInt.ElementAt(i);
                var next = ArrayInt.ElementAt(i + 1);
                //PrintElements(ArrayInt);

                if (current == next - 1)
                {
                    ArrayInt.Remove(current);
                    ArrayInt.Remove(next);
                    Console.WriteLine("No of Elements: " + ArrayInt.Count());
                }

                j++;
                if (j % 100 == 0)
                {
                    Console.WriteLine("Processed : " + j.ToString());
                }
            }
            //PrintElements(ArrayInt);
        }
   }

    class Numbers
    {
        static int icount=0;
        public bool Done() {
            if (icount > 10000) { return true; } else { return false; }
        }
        public int GetNextNumber()
        {
            Random rndnumber = new Random();
            icount++;
            return rndnumber.Next(1, 10000);
        }
    }
}
