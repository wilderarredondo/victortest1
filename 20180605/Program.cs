using System;

namespace _20180605
{
    class Program
    {

        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");
            // Console.WriteLine("Ninguno");
            
        }
    }

    class NumberStore
    {
        int[] numbers = { 1, 3, 7, 15, 31, 63, 127, 255, 511, 1023 };

        public ref int FindNumber(int target)
        {
            for (int ctr = 0; ctr < numbers.Length; ctr++)
            {
                if (numbers[ctr] >= target)
                    return ref numbers[ctr];
            }
            return ref numbers[0];
        }

        public override string ToString() => string.Join(" ", numbers);
    }
}
