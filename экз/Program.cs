using System;
using System.Threading;

namespace экз
{
    class Cinema
    {
        static void Main(string[] args)
        {
            for (int i = 0; i <100; i++)
            {
                Visitors visitors = new Visitors(i);
            }
            Console.ReadKey();
        }
        class Visitors
        {
            private static Semaphore sem = new Semaphore(3, 3);
            Thread visitorsThread;
            int count = 5;


            public Visitors(int i)
            {
                visitorsThread = new Thread(visit);
                visitorsThread.Name = $"Visitors{i.ToString()}";
                visitorsThread.Start();
            }
            public void visit()
            {
                while (count > 0)
                {
                    sem.WaitOne();

                    Console.WriteLine($"{Thread.CurrentThread.Name} First Room");
                    Console.WriteLine($"{Thread.CurrentThread.Name} Second Room");
                    Thread.Sleep(1000);
                    Console.WriteLine($"{Thread.CurrentThread.Name} Third Room");
                    sem.Release();
                    count--;
                    Thread.Sleep(1000);
                }
            }
        }
    }
}
