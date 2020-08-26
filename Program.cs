using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.Timers;
using System.Threading.Tasks;

namespace shutdown
{
    class Program
    {
        static void SomeMethod()
        {
            Console.WriteLine("Thread ID = " + Thread.CurrentThread.ManagedThreadId);

            Console.WriteLine("performing an action...");
            Process.Start(@"C:\Windows\system32\shutdown.exe", "-s -t 20");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Za jak dlouho se mám vypnout? (Minuty)");
            int intTemp = Convert.ToInt32(Console.ReadLine());
            int someValueInSeconds = intTemp * 60;

            Console.WriteLine("Thread ID = " + Thread.CurrentThread.ManagedThreadId);

            Task.Delay(TimeSpan.FromSeconds(someValueInSeconds)).ContinueWith(t => SomeMethod());

            // Prevents the app from terminating before the task above completes
            Console.WriteLine("Odpocet zahajen. Pro preruseni stiskni Enter nebo zavri program");
            Console.ReadLine();
        }




    }
}
