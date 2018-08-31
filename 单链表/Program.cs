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
            for(int k = 20; k < 30; k++)
            {
                node = new Node(k, node);
            }
            Console.WriteLine(node.ToString());
            // 获取一个节点
            Node.GetElement(node, 10);
            // start 在第11的位置,插入一个节点
            Node.InsertElement(node, 10, 99);
            Console.WriteLine(node);
            Node.DelElement(node,2);
            Console.WriteLine(node);
            // end 在第11的位置,
        }
        
    }
    class Node
    {
        public readonly int data;
        public  Node next;
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
        /// <summary>
        /// 获取一个节点
        /// </summary>
        /// <param name="node">头指针</param>
        /// <param name="i">节点位置</param>
        /// <returns></returns>
        public static int GetElement(Node node,int i)
        {
            // start 返回第十个元素的值
            Node p = node;
            int j = 1;
            while (p != null && j < i)
            {
                p = p.next;
                ++j;
            }
            if (p == null)
            {
                Console.WriteLine("error");
                return 0;
            }
            Console.WriteLine(p.data);
            return p.data;
            // end 返回第十个元素的值
        }
        /// <summary>
        /// 插入一个节点
        /// </summary>
        /// <param name="node">头指针</param>
        /// <param name="loc">插入位置</param>
        /// <param name="data">插入数据</param>
        public static void InsertElement(Node node, int loc, int data)
        {
            Node s = new Node(data);
            int j = 1;
            while (node != null && j < loc - 1)
            {
                node = node.next;
                ++j;
            }
            if (node == null)
            {
                throw new IndexOutOfRangeException("链表没这么长");
            }
            s.next = node.next;
            node.next = s;
        }
        /// <summary>
        /// 删除一个节点
        /// </summary>
        /// <param name="node"></param>
        /// <param name="loc"></param>
        public static void DelElement(Node node, int loc)
        {
            int j = 1;
            while(node!=null && j < loc - 2)
            {
                node = node.next;
                ++j;
            }
            if (node.next == null)
            {
                throw new IndexOutOfRangeException("链表没这么长");
            }
            node.next = node.next.next;
        }
    }
}
