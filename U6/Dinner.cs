using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace U6
{
    class Program
    {
        static Thread[]? Philosophers;
        static object[]? Forks;
        static Dictionary<int, int>? EatingTimes;
        static Stopwatch? Swatch;

        static void Main(string[] args)
        {
            Forks = new object[5];
            EatingTimes = new Dictionary<int, int>();
            Philosophers = new Thread[5];
            Swatch = new Stopwatch();

            for (int i = 0; i < 5; i++)
                Forks[i] = new object();

            for (int i = 0; i < 5; i++)
            {
                int philosopherId = i;
                Philosophers[i] = new Thread(() =>
                {
                    int leftFork = philosopherId;
                    int rightFork = philosopherId == 4 ? 0 : philosopherId + 1;

                    Swatch ??= new Stopwatch();
                    while (Swatch.Elapsed.TotalSeconds <= 10)
                        TryDinner(philosopherId, Forks[leftFork], Forks[rightFork]);
                });
            }

            Swatch.Start();
            foreach (var philosopher in Philosophers)
                philosopher.Start();
            
            foreach (var philosopher in Philosophers)
                philosopher.Join();

            Swatch.Stop();

            Console.Write("-------------------------------------------------------------\n");
            Console.Write("Beendet mit folgenden Zeiten:\n");

            EatingTimes ??= new Dictionary<int, int>();

            foreach (var eatingTime in EatingTimes!)
            {
                // KEY - philosopherId, VALUE - time in ms
                Console.WriteLine($"Philosoph {eatingTime.Key}: {eatingTime.Value} ms gegessen.");
            }

            Console.ReadKey();
            return;
        }

        static void TryDinner(int philosopherId, object leftFork, object rightFork)
        {
            bool leftForkLock = false;
            bool rightForkLock = false;

            try
            {
                Monitor.TryEnter(leftFork, 10, ref leftForkLock);
                Monitor.TryEnter(rightFork, 10, ref rightForkLock);

                if (leftForkLock && rightForkLock)
                    Eat(philosopherId);
                else
                    Think(philosopherId);
            }
            finally
            {
                if (leftForkLock)
                    Monitor.Exit(leftFork);

                if (rightForkLock)
                    Monitor.Exit(rightFork);
            }
        }

        static void Eat(int philosopherId)
        {
            var rand = new Random();
            int eatTime = rand.Next(1, 11);
            Thread.Sleep(eatTime);

            EatingTimes ??= new Dictionary<int, int>();
            lock (EatingTimes)
            {
                if (EatingTimes.ContainsKey(philosopherId))                             // if key exists: add time
                    EatingTimes[philosopherId] += eatTime;
                else
                    EatingTimes[philosopherId] = eatTime;                               // if key is new: set time
            }

            Console.WriteLine($"Philosoph {philosopherId} isst für {eatTime} ms.");
        }

        static void Think(int philosopherId)
        {
            var rand = new Random();
            int thinkTime = rand.Next(1, 11); 
            Thread.Sleep(thinkTime);

            Console.WriteLine($"Philosoph {philosopherId} denkt für {thinkTime} ms.");
        }
    }
}
