using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SingleInstance
{
    class Program
    {
        static void Main(string[] args) {
            Mutex nMutex = null;
            const string mutexName = "RUNMEONLYONCE";

            try
            {
                nMutex = Mutex.OpenExisting(mutexName);
            }
            catch (WaitHandleCannotBeOpenedException)
            {
                Console.WriteLine("The mutex doesn't exist.");
            }

            if (nMutex == null)
            {
                nMutex = new Mutex(true, mutexName);
            }
            else
            {
                nMutex.Close();
                return;
            }

            Console.WriteLine("Our Application");
            Console.ReadKey();
        }
    }
}
