using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U6
{
    public class Dinner
    {
        private static Thread[] Philosophers = new Thread[5];
        private static object[] Cuterlies = new object[5];
        private Stopwatch StopWatch = new();

        private static Dictionary<int, int> DiningTimes = new Dictionary<int, int>();
        private const int THINK_TIME = 10;
        private const int EAT_TIME = 10;

        public Dinner() 
        {}

        public void startDinner()
        {
            for (int i = 0; i < 5; i++)
            {
                Cuterlies[i] = new object();
            }

            for (int i = 0; i < 5; i++)
            {
                int philosopher = i;
                int cut = philosopher == 4 ? 0 : philosopher + 1;

                Philosophers[philosopher] = new Thread(() =>
                {
                    TryDinner(philosopher, Cuterlies[philosopher], Cuterlies[cut]);
                });
            }

            if (!StopWatch.IsRunning)
                StopWatch.Start();

            for (int i = 0; i < 5; i++)
                Philosophers[i].Start();
        }

        public void endDinner()
        {
            if (StopWatch.IsRunning)
                StopWatch.Stop();
        }

        public static void Think(object philosoph)
        {
            Thread.Sleep(THINK_TIME);
            DiningTimes.Add((int)philosoph, THINK_TIME);
            Console.WriteLine("#" + ((int)philosoph).ToString() + ": Thinking...");
        }

        public static void TryDinner(object philosoph, object cutlery1, object cutlery2)
        {
            bool lock1 = false;
            bool lock2 = false;

            try
            {
                lock1 = Monitor.TryEnter(cutlery1);
                lock2 = Monitor.TryEnter(cutlery2);

                if (!lock1 && !lock2)
                {
                    Console.WriteLine("Fork 1 or 2 is locked");
                    Think(philosoph);
                    TryDinner(philosoph, cutlery1, cutlery2);
                }
                else
                {
                    Eat(philosoph);
                }
            }
            finally
            {
                if (lock1)
                    Monitor.Exit(cutlery1);
                if (lock2)
                    Monitor.Exit(cutlery2);
            }
        }

        public static void Eat(object philosoph)
        {
            Random rand = new Random(1, EAT_TIME);
            Thread.Sleep(EAT_TIME);

            if (DiningTimes.ContainsKey((int)philosoph))
            {
                DiningTimes[(int)philosoph] += EAT_TIME;
            }
            else 
                DiningTimes.Add((int)philosoph, EAT_TIME);

            Console.WriteLine("#" + ((int)philosoph).ToString() + ": Eating...");
        }
    }
}
