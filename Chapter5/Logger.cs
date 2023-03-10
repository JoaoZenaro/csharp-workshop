using System;
using System.Threading;

namespace Chapter5
{
    public static class Logger
    {
        public static void Log(string message)
        {
            Console.WriteLine($"{DateTime.Now:T} [{Thread.CurrentThread.ManagedThreadId:00}] {message}");
        }
    }
}