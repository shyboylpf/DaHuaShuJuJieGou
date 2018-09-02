using System;
using System.Collections;

namespace 共享栈
{
    class Program
    {
        static void Main(string[] args)
        {
            //Stack a = new Stack();
            //a.Push(3);
            //a.Pop();
            SqDoubleStack sqDoubleStack = new SqDoubleStack();
            for(int i = 0; i < 100; i++)
            {
                sqDoubleStack.Push(i,i%2+1);
            }
            
            while (true)
            {
                Console.WriteLine(sqDoubleStack.Pop(2));
            }
            Console.WriteLine("Hello World!");
        }
    }

    class SqDoubleStack
    {
        const int MAXSIZE = 100;
        int[] data = new int[MAXSIZE];
        int top1=-1;  // 栈1顶指针
        int top2=MAXSIZE;  // 栈2顶指针
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s">栈</param>
        /// <param name="e">待插入元素</param>
        /// <param name="stackNumber">栈号 1/2 </param>
        public void Push(int e, int stackNumber)
        {
            if (this.top1 + 1 == this.top2)
            {
                throw new IndexOutOfRangeException("栈满了,不可以再push新元素了");
            }
            if (stackNumber == 1)
            {
                this.data[++this.top1] = e;
            }
            else if (stackNumber == 2)
            {
                this.data[--this.top2] = e;
            }
        }
        public int? Pop(int stackNumber)
        {
            if (stackNumber == 1)
            {
                if (this.top1 == -1)
                {
                    throw new IndexOutOfRangeException("栈为空, 没有数据");
                }
                return this.data[this.top1--];
            }
            else if (stackNumber == 2)
            {
                if(this.top2== MAXSIZE)
                    throw new IndexOutOfRangeException("栈为空, 没有数据");
                return this.data[this.top2++];
            }
            return null;
        }
    }
}
