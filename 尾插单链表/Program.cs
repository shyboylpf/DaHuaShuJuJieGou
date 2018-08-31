using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 尾插单链表
{
    class Program
    {
        static void Main(string[] args)
        {
            Node node = new Node(null);
            Node r = node;
            for (int k = 0; k < 100000000; k++)
            {
                Node s = new Node(k,r);
                r = r.next;
            }
            Console.WriteLine(111);
        }
    }
    class Node
    {
        public int? data;
        public Node next;
        public Node(int data, Node node)
        {
            this.data = data;
            node.next = this;
        }
        public Node(int? data)
        {
            this.data = data;
            this.next = null;
        }
        public override string ToString()
        {
            return data.ToString() + " " + next?.ToString();
        }
    }
}
