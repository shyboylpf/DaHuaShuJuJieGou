using System;

namespace 整数变量互换
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int x = 20;
            int y = 20;
            x ^= y;
            y ^= x;
            x ^= y;
            Console.WriteLine(x + " " + y);
        }
    }
}