using System;
using System.Text;

namespace Task2
{
    class Program
    {
        private static double StringToDouble(StringBuilder sNum)
        {
            double number, wholePart = 0, fractionalPart = 0;
            StringBuilder sWholePart = new StringBuilder(2);
            StringBuilder sFractionalPart = new StringBuilder();
            ulong fact;
            int pointLocation = 0;
            while (sNum[pointLocation] != '.')
                ++pointLocation;
            sWholePart.Append(sNum, 0, pointLocation);
            sFractionalPart.Append(sNum, pointLocation + 1, sNum.Length - pointLocation - 1);
            fact = (ulong)Math.Pow(10, sWholePart.Length - 1);
            for(int i = 0; i < sWholePart.Length; ++i)
            {
                wholePart += (ulong)(sWholePart[i] - 48) * fact;
                fact /= 10;
            }
            fact = (ulong)Math.Pow(10, sFractionalPart.Length - 1);
            for (int i = 0; i < sFractionalPart.Length; ++i) 
            {
                fractionalPart += (ulong)(sFractionalPart[i] - 48) * fact;
                fact /= 10;
            }
            number = wholePart + fractionalPart / (ulong)Math.Pow(10, sFractionalPart.Length);
            return number;
        }
        static void Main(string[] args)
        {
            string stringNumber;
            Console.Write("Enter your string : ");
            stringNumber = Console.ReadLine();
            StringBuilder stringBuilderNumber = new StringBuilder(stringNumber);
            Console.WriteLine($"Your number is {StringToDouble(stringBuilderNumber)}");
        }
    }
}
