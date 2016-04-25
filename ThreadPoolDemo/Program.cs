using System;
using System.Threading;

namespace ThreadPoolDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            WaitCallback callback = new WaitCallback(ShowMyText);

            ThreadPool.QueueUserWorkItem(callback, "123");
            ThreadPool.QueueUserWorkItem(callback, "456");
            ThreadPool.QueueUserWorkItem(callback, "789");
            
            Console.ReadKey();
        }

        static void ShowMyText(object state)
        {
            string myText = (string)state;
            Console.WriteLine("Thread: {0} - {1}",
            Thread.CurrentThread.ManagedThreadId, myText);
        }
    }
}
