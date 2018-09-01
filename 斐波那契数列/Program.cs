using System;

namespace 斐波那契数列
{
    class Program
    {
        static void Main(string[] args)
        {
            for(int i = 0; i < 40; i++)
            {
                Console.WriteLine(Fbi(i));
            }
        }
        public static int Fbi(int i)
        {
            if (i < 2)
            {
                return i;//== 0 ? 0 : 1;
            }
            return Fbi(i - 1) + Fbi(i - 2);
        }

    }

}
