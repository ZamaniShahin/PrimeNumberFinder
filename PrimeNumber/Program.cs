using System;
using System.Linq;
using static System.Console;
using System.IO;

namespace PrimeNumber
{
    class Program
    {
        static void Main(string[] args)
        {

            GreatNumbers greatNumbers = new GreatNumbers();



            string PathIn = @"D:\Term 3\ساختمان داده\تمرین\PrimeNumber\PrimeNumber\InPut.txt";
            string PathOut = @"D:\Term 3\ساختمان داده\تمرین\PrimeNumber\PrimeNumber\OutPut.txt";
            int count = 0;
            string[] input;
            WriteLine("Please Choose An Option To Continue:");
            WriteLine("1.Reading numbers from Console");
            WriteLine("2.Reading numbers from File");
            int flag = Convert.ToInt32(ReadLine());

            ////////////////
            if (flag == 1)
            {
                WriteLine("How Much Numbers Do You Have?");
                count = Convert.ToInt32(ReadLine());
                input = new string[count];
                for (int i = 0; i < count; i++)
                {
                    WriteLine($"Please Enter Your {i + 1}st Number : ");
                    input[i] = ReadLine();
                }
            }
            else 
            {
                count = File.ReadLines(PathIn).Count();
                WriteLine("***************************************");
                input = new string[count];

                input = new string[count];
                var streamReader = new StreamReader(PathIn);
                input[0] = streamReader.ReadLine();
                for (int i = 1; i < count; i++)
                {
                    input[i] = streamReader.ReadLine();
                }

            }
            ////////////////////////

            //****************************
            WriteLine("________________________________________________________");


            bool[] output = new bool[count];
            //tasks
            for (int i = 0; i < count; i++)
            {
                output[i] = IsPrime(input[i]);
                WriteLine($"Your {i+1}st Number is :{SayPrime(output[i])}");
                WriteLine("________________________________________________");

            }

            //saving in file
            string[] result = new string[2 * count];
            int j = 0;
            for (int i = 0; i < 2 * count; i += 2)
            {

                result[i] = $"Your  Number is :{SayPrime(output[j])}";
                result[i + 1] = "________________________________________________";
                j++;
            }

            File.WriteAllLines(PathOut,
                result.Select(n => n));
            //****************************
            Console.ReadKey();

        }
        public static bool IsPrime(string input)
        {
            GreatNumbers greatNumbers = new GreatNumbers();
            int[] b = greatNumbers.ToArr(input);
            int count = 0;
            for(int i = 0; i < input.Length; i++)
            {
                count += int.Parse(input[i].ToString());
            }
            if (int.Parse(b[b.Length - 1].ToString()) == 5 || int.Parse(b[b.Length - 1].ToString()) == 0 ||
                int.Parse(b[b.Length - 1].ToString()) == 2 || int.Parse(b[b.Length - 1].ToString()) == 4 ||
                int.Parse(b[b.Length - 1].ToString()) == 6 || int.Parse(b[b.Length - 1].ToString()) == 8)
                return false;
            else if (count % 3 == 0 || count % 9 == 0)
                return false;
            bool isPrime = true;
            string a = "1";
            string divisor = "2";
            string two = "2";
            string result;
            while (greatNumbers.IsBigger(greatNumbers.Dividend(input, two), a))
            {
                result = greatNumbers.DivideRemainder(input, divisor);
                if (greatNumbers.IsZero(result))
                {
                    isPrime = false;
                    break;
                }

                divisor = greatNumbers.PlusOne(divisor);
                a = greatNumbers.PlusOne(a);
            }
            return isPrime;
        }
        public static string SayPrime(bool input)
        {
            if (input)
                return "Prime";
            else
                return "Not Prime";
        }
    }
}
