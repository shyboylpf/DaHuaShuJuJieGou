using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 二分查找
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            int target = 20;
            int[] arry1 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
            int pre = 0;
            int behind = arry1.Length;
            int current = (pre + behind) / 2;   //整数除法, 返回整数 , 5/2=2 , 取地板.
            while(arry1[current] != target)
            {
                count++;
                if (pre == current)
                {
                    Console.WriteLine("zhaobudao");
                    Console.WriteLine(count);
                    return;
                }
                if( target>arry1[current])
                {
                    pre = current;
                }
                else if(target<arry1[current])
                {
                    behind = current;
                }
                current = (pre + behind) / 2;
            }
            Console.WriteLine(current);
            Console.WriteLine(count);
        }
    }
}
