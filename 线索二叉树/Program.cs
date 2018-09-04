using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 线索二叉树
{
    enum PointerTag
    {
        Link, Thread
    }
    class Program
    {
        
        static void Main(string[] args)
        {
            BiThrNode root = new BiThrNode(1);
            root.lchild = new BiThrNode(2);
            root.rchild = new BiThrNode(3);
            root.lchild.rchild = new BiThrNode(4);
            LinkBiThrTree linkBiThrTree = new LinkBiThrTree();
            linkBiThrTree.InThreading(root);
            linkBiThrTree.InorderTraverseThr(root);

        }
    }
    class BiThrNode
    {
        public int data;
        public BiThrNode lchild, rchild;
        public PointerTag LTag, RTag;
        public BiThrNode()
        {
            data = 0;
            lchild = rchild = null;
            LTag = RTag = PointerTag.Link;
        }
        public BiThrNode(int val)
        {
            data = val;
            lchild = rchild = null;
            LTag = RTag = PointerTag.Link;
        }
    }
    class LinkBiThrTree
    {
        private BiThrNode root;
        BiThrNode pre; //全局变量 , 始终指向刚刚访问过的节点 .
        /// <summary>
        /// 中序遍历进行中序线索化
        /// </summary>
        /// <param name="p"></param>
        public void InThreading(BiThrNode p)
        {
            if (p != null)
            {
                InThreading(p.lchild);
                if (p.lchild == null)  //当前节点没有左孩子
                {
                    p.LTag = PointerTag.Thread; // 前驱线索
                    p.lchild = pre;  // 左孩子指向前驱
                }
                if (pre.rchild == null) // 前驱没有右孩子
                {
                    pre.RTag = PointerTag.Thread; //后继线索
                    pre.rchild = p;  // 前驱右孩子指针指向后继 , 当前p
                }
                pre = p; // 保持pre指向p的前驱
                InThreading(p.rchild);
            }
        }
        public void InorderTraverseThr(BiThrNode T)
        {
            BiThrNode p;
            p = T.lchild;
            while (p != T)
            {
                while (p.LTag == PointerTag.Link)
                {
                    p = p.lchild;
                    Console.Write(p.data+" ");
                    while(p.RTag==PointerTag.Thread && p.rchild != T)
                    {
                        p = p.rchild;
                        Console.Write(p.data+" ");
                    }
                    p = p.rchild;
                }
            }
        }
    }
    

}
