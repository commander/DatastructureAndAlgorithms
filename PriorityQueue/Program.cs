using System;

namespace PriorityQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of elements in queue:");
            var input = Console.ReadLine();
            MaxPQ<string> pq;
            int number;
            while(!int.TryParse(input, out number))
            {
                Console.WriteLine("Enter a valid number:");
                input = Console.ReadLine();    
            }
            
            pq = new MaxPQ<string>(number);

            while (number > 0)
            {
                Console.WriteLine("Enter keys");
                string entry = Console.ReadLine();
                pq.Insert(entry);
                number--;
            }

            while (!pq.IsEmpty)
            {
                Console.WriteLine(pq.DeleteMax());
            }
        }
    }
}
