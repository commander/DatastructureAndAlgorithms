using System;

namespace ArrayAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Majority number is {0}", GetMajority(
                new int [] {
                    1, 1
                }));
        }

        static int GetMajority(int[] numbers)
        {
            int result = numbers[0];
            int times = 1;
            for (int i = 1; i < numbers.Length; ++i)
            {
                Console.WriteLine("Current number: {2}, Current result: {0}, times: {1}", result, times, numbers[i]);
                if (numbers[i] == result)
                {
                    times++;
                }
                else
                {
                    times--;
                }

                if (times == 0)
                {
                    result = numbers[i];
                    times = 1;
                }
            }

            Console.WriteLine("Current result: {0}, times: {1}", result, times);

            if (!CheckMajorityExistence(numbers, result))
                throw new ArgumentException("No majority exisits.", nameof(numbers));

            return result;
        }

        static bool CheckMajorityExistence(int[] numbers, int number)
        {
            int times = 0;
            for (int i = 0; i < numbers.Length; ++i)
            {
                if (numbers[i] == number)
                    times++;
            }

            return (times * 2 > numbers.Length);
        }
    }
}
