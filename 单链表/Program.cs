using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 头插单链表
{
    class Program
    {
        static void Main(string[] args)
        {
            Node node = new Node(1);
            node = new Node(2, node);
            node = new Node(3, node);
            node = new Node(4, node);
            node = new Node(5, node);
            node = new Node(6, node);
            node = new Node(7, node);
            node = new Node(8, node);
            node = new Node(9, node);
            node = new Node(10, node);
            node = new Node(11, node);
            node = new Node(12, node);
            node = new Node(13, node);
            node = new Node(14, node);
            //Node j = node;
            //while (j != null)
            //{
            //    Console.WriteLine(j.data);
            //    j = j.next;
            //}
            Console.WriteLine(node.ToString());
        }
    }
    class Node
    {
        public readonly int data;
        public readonly Node next;
        public Node(int data) : this(data,null)
        {
        }
        public Node(int data, Node node)
        {
            this.data = data;
            this.next = node;
        }
        public override string ToString()
        {
            return data.ToString() + " " + next?.ToString();
        }
    }
}
