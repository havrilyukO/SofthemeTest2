using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircularPrime
{
    class Program
    {
        private static List<string> SieveOfEratosthenes(int Number)
        {
            List<string> primeList = new List<string>();
            bool[] primeNumber = new bool[Number + 1];

            for (int i = 0; i < primeNumber.Length; i++)
                primeNumber[i] = true;

            for (int i = 2; i < primeNumber.Length; i++)
                if (primeNumber[i] == true)
                {
                    for (int j = i; j < primeNumber.Length; j++)
                        if (primeNumber[j] == true && j % i == 0)
                            primeNumber[j] = false;
                    primeList.Add(i.ToString());
                }
            return primeList;
        }

        private static List<int> CircularPrime(List<string> primeList)
        {
            Console.WriteLine("Circular prime numbers:");
            List<int> CircularPrimeList = new List<int>();
            foreach (string number in primeList)
            {
                string curentNumber = number;
                bool isCircularPrime = true;
                for (int i = 0; i < number.Length; i++)
                {
                    curentNumber = CircularTransposition(curentNumber);
                    if(!primeList.Contains(curentNumber))
                    {
                        isCircularPrime = false;
                        break;
                    }
                }
                if (isCircularPrime)
                {
                    CircularPrimeList.Add(Convert.ToInt32(number));
                    Console.Write(number + " ");
                }
            }
            return CircularPrimeList;
        }

        private static string CircularTransposition(string number)
        {
            char ch = number[0];
            string newNumber = number.Substring(1);
            newNumber += ch;
            return newNumber;
        }

        public static void Main()
        {
            List<string> PrimeList = SieveOfEratosthenes(1000000);
            Console.WriteLine("Count  of the prime numbers: {0}", PrimeList.Count);

            List<int> CircularPrimeList = CircularPrime(PrimeList);
            Console.WriteLine("\nCount  of the circular prime numbers: {0}", CircularPrimeList.Count);
            
            Console.ReadLine();
        }
    }
}