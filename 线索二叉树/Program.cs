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
            LinkBiThrTree linkBiThrTree = new LinkBiThrTree(root);
            //linkBiThrTree.InThreading(root);
            //root.lchild.LTag = PointerTag.Thread;
            //root.lchild.lchild = null;
            //root.rchild.RTag = PointerTag.Thread;
            //root.rchild.rchild = null;
            //Console.Write(root.rchild.rchild);
            //linkBiThrTree.inorder(root);
            BiThrNode head = new BiThrNode();
            //head.lchild = root;
            //head.rchild = root.rchild;
            //head.lchild.lchild = head;
            //root.rchild.rchild = head;
            //linkBiThrTree.InorderTraverseThr(head);
            linkBiThrTree.InOrderThreadHead(ref head, root);
            Console.WriteLine("使用后继的中序遍历");
            linkBiThrTree.InorderTraverseThr(head);
            Console.WriteLine("\n使用递归的中序遍历");
            linkBiThrTree.inorder(root);
            Console.WriteLine("\n使用递归的前序序遍历");
            linkBiThrTree.PreOrder(root);
            Console.WriteLine("");
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
        public override string ToString()
        {
            return data.ToString();
        }
    }
    class LinkBiThrTree
    {
        //private BiThrNode root;
        BiThrNode pre ; //全局变量 , 始终指向刚刚访问过的节点 .
        public LinkBiThrTree(BiThrNode p)
        {
            this.pre = p;
        }
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
        /// <summary>
        /// 建立头结点 , 中序线索二叉树
        /// </summary>
        /// <param name="h">新加的头结点</param>
        /// <param name="t">树的根节点</param>
        public void InOrderThreadHead(ref BiThrNode h, BiThrNode t)
        {
            h = new BiThrNode();
            if (h == null)
            {
                throw new OutOfMemoryException("对象创建失败 , 内存不足");
            }
            h.rchild = h;  // 貌似在t为空的时候才有用.
            h.RTag = PointerTag.Link;  
            if (t == null)
            {
                h.lchild = h;
                h.LTag = PointerTag.Link;
            }
            else
            {
                pre = h;                           // 让pre等于head , 这样可以让中序遍历的第一个元素的左指针指向head
                h.lchild = t;                      // 让head的左指针指向root
                h.LTag = PointerTag.Link;          // 设置指针类型为link
                InThreading(t);                    // 让前序遍历的第一个元素的左指针指向head
                pre.rchild = h;                    // 此时pre指向中序遍历的最后一个元素 , 让最后一个元素的右指针指向head
                pre.RTag = PointerTag.Thread;      // 设置指针类型为Thread
                h.rchild = pre;                    // 让head的右指针指向中序遍历的最后一个元素.  
                //h.RTag = PointerTag.Thread;
            }
        }
        /// <summary>
        /// t指向头结点，头结点左链lchild指向根结点，头结点右链rchild指向中序遍历的最后一个结点。
        /// 中序遍历二叉线索树表示的二叉树t
        /// </summary>
        /// <param name="t"></param>
        public void InorderTraverseThr(BiThrNode t)
        {
            BiThrNode p;
            p = t.lchild;
            while (p != t)
            {
                while (p.LTag == PointerTag.Link)
                {
                    p = p.lchild;
                }
                Console.Write(p.data +" ");
                while(p.RTag==PointerTag.Thread && p.rchild != t)
                {
                    p = p.rchild;
                    Console.Write(p.data+" ");
                }
                p = p.rchild;
            }
        }
        /// <summary>
        /// 中序遍历 , 对于线索二叉树不好使了, 因为左右指针都会循环起来 , 造成stackOverFlow  , 递归没有终止.
        /// </summary>
        /// <param name="p"></param>
        public void inorder(BiThrNode p)
        {
            if (p != null)
            {
                if(p.LTag==PointerTag.Link)
                    inorder(p.lchild);
                Console.Write(p.data + " ");
                if(p.RTag==PointerTag.Link)
                    inorder(p.rchild);
            }
            else
            {
                return;
            }
        }
        public void PreOrder(BiThrNode p)
        {
            if (p != null)
            {
                Console.Write(p.data+" ");
                if (p.LTag == PointerTag.Link)
                {
                    PreOrder(p.lchild);
                }
                if (p.RTag == PointerTag.Link)
                {
                    PreOrder(p.rchild);
                }
            }
        }
    }
    

}
