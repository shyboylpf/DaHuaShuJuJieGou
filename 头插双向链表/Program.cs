using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 头插双向链表
{
    class Program
    {
        static void Main(string[] args)
        {
            Node node = new Node(-1);
            //node = new Node(2,node);
            Node s = node;
            for(int k = 0; k < 20; k++)
            {
                node = new Node(k, node);
            }
            Console.WriteLine(node);
            //while (s.pri != null)
            //{
            //    Console.WriteLine(s.data);
            //    s = s.pri;
            //}
            Console.WriteLine(s.ToString1());
            int j = 1;
            Node t = s;
            while(t!=null && j < 10)
            {
                t = t.pri;
                ++j;
            }
            t.InserElement(1000);
            Console.WriteLine(node);
            Console.WriteLine(s.ToString1());
            t.DeleteElement();
            Console.WriteLine(node); 
        }
    }
    class Node
    {
        public int data;
        public Node pri;
        public Node next;
        //public Node() { }
        public Node(int data)
        {
            this.data = data;
            this.pri = null;
            this.next = null;
        }
        public Node(int data, Node node)
        {
            this.data = data;
            this.next = node;
            node.pri = this;
            this.pri = null;
        }
        public override string ToString()
        {
            return data + " " + next?.ToString();
        }
        public string ToString1()
        {
            return data + " " + pri?.ToString1();
        }
        public void InserElement(int data)
        {
            Node s = new Node(data)
            {
                next = this,
                pri = this.pri
            };
            this.pri.next = s;
            this.pri = s;
        }
        public void DeleteElement()
        {
            this.pri.next = this.next;
            this.next.pri = this.pri;
        }
        
    }
}
