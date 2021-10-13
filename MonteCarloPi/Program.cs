using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MonteCarloPi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How many darts should each thread throw?");
            int numDarts = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("How many threads should be run?");
            int numThreads = Convert.ToInt32(Console.ReadLine());

            List<Thread> threads = new List<Thread>();
            List<FindPiThread> piThreads = new List<FindPiThread>();

            for (int i = 0; i < numThreads; i++)
            {
                FindPiThread piThread = new FindPiThread(numDarts);
                piThreads.Add(piThread);

                Thread thread = new Thread(new ThreadStart(piThread.throwDarts));
                threads.Add(thread);
                thread.Start();
                Thread.Sleep(16);
            }

           foreach (Thread thread in threads)
            {
                thread.Join();
            }

            int totalDartsThrown = numThreads * numDarts;
            int totalDartsInside = 0;

            foreach (FindPiThread piThread in piThreads)
            {
                totalDartsInside += piThread.getDartsInsideBoard();
            }
            
            double pi = 4 * (totalDartsInside / totalDartsThrown);
            Console.WriteLine(pi);
        }
    }
}
