using System;

namespace Task3
{
    class Program
    {
        static ulong GetIndicator(ulong last)
        {
            ulong counter = 0, divider = 2;
            for(int i = 0; i < 64; ++i)
            {
                if (last / divider == 0)
                    break;
                counter += last / divider;
                divider *= 2;
            }
            return counter;
        }
        static void Main(string[] args)
        {
            ulong a, b; // 0;2e64 - 1
            Console.Write("Enter number a: ");
            a = Convert.ToUInt64(Console.ReadLine());
            Console.Write("Enter number b: ");
            b = Convert.ToUInt64(Console.ReadLine());
            ulong firstPart = GetIndicator(a - 1);
            ulong secondPart = GetIndicator(b);
            ulong indicator = secondPart - firstPart;
            Console.WriteLine($"Max indicator is: {indicator}");
        }
    }
}
