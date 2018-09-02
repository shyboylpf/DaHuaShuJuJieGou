using System;

namespace 循环队列
{
    class Program
    {
        static void Main(string[] args)
        {
            SqQueue sqQueue = new SqQueue();
            for(int i = 0; i < 99; i++)
            {
                sqQueue.EnQueue(i);
            }
            //while (sqQueue.DeQueue() != null)
            //{
            //    Console.WriteLine(sqQueue.DeQueue());
            //}
            for(int i = 0; i < 50; i++)
            {
                sqQueue.DeQueue();
            }
            for(int i = 0; i < 50; i++)
            {
                sqQueue.EnQueue(i);
            }
            Console.WriteLine(sqQueue.DeQueue());
            Console.WriteLine("Hello World!");
        }
    }
    class SqQueue
    {
        const int MAXSIZE = 100;
        int[] data = new int[MAXSIZE];
        int font=0; // 头指针
        int rear=0; // 尾指针 , 若队列不为空, 执行队列尾元素的下一个位置.
        public int QueueLength()
        {
            return (this.rear - this.font + MAXSIZE) % MAXSIZE;
        }
        public void EnQueue(int e)
        {
            if ((this.rear + 1) % MAXSIZE == this.font)
            {
                throw new IndexOutOfRangeException("队列是满的 , 不能再入队了");
            }
            this.data[this.rear] = e;
            this.rear = (this.rear + 1) % MAXSIZE;
        }
        public int? DeQueue()
        {
            if (font == rear)
            {
                //throw new IndexOutOfRangeException("队列为空");
                return null;
            }
            int temp = data[font];
            font = (font + 1) % MAXSIZE;
            return temp;
        }
    }
}
