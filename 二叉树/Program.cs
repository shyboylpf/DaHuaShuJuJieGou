using System;

namespace 二叉树
{
    class Program
    {
        static void Main(string[] args)
        {
            BiTNode root = new BiTNode();
            Console.WriteLine("Hello World!");
        }
    }
    /// <summary>
    /// 二叉树的二叉链表实现
    /// </summary>
    class BiTNode
    {
        public int data; // 结点数据
        public BiTNode lchild, rchild; // 左右孩子指针
        public BiTNode()
        {
            data = default(int);
            lchild = null;
            rchild = null;
        }
        public BiTNode(int data)
        {
            this.data = data;
            lchild = null;
            rchild = null;
        }
        public BiTNode(int val, BiTNode lp, BiTNode rp)
        {
            data = val;
            lchild = lp;
            rchild = rp;
        }
        public BiTNode(BiTNode lp, BiTNode rp)
        {
            data = default(int);
            lchild = lp;
            rchild = rp;
        }

    }
}
