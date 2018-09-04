using System;
using System.Collections.Generic;

namespace 二叉树
{
    class Program
    {
        static int youbiao = 0;
        static int[] preArray = { 1, 2, 0, 3, 0, 0, 4, 0, 0 };
        static int[] inArray = { 0, 2, 0, 4, 0, 1, 0, 3, 0 };
        static int[] postArray = { 0, 0, 0, 4, 2, 0, 0, 3, 1 };
        static void Main(string[] args)
        {
            // 层序循环创建二叉树
            Console.WriteLine("层序循环创建二叉树");
            BiTNode root = new BiTNode(1);
            LinkBinayrTree linkBinayrTree = new LinkBinayrTree();
            Queue<BiTNode> sq = new Queue<BiTNode>();
            int i = 2;
            sq.Enqueue(root);
            while (i < 20)
            {
                BiTNode tmp = sq.Dequeue();
                tmp.lchild = new BiTNode(i++);
                tmp.rchild = new BiTNode(i++);
                sq.Enqueue(tmp.lchild);
                sq.Enqueue(tmp.rchild);
            }
            linkBinayrTree.LevelOrder(root); // 层序

            // 前序递归创建二叉树
            Console.WriteLine("\n前序递归创建二叉树");
            youbiao = 0;
            BiTNode root2 = new BiTNode();
            PreCreateBiTree(ref root2);
            linkBinayrTree.preorder(root2);

            // 中序递归创建二叉树
            Console.WriteLine("\n中序递归创建二叉树");
            youbiao = 0;
            BiTNode root3 = new BiTNode();
            InCreateBiTree(ref root3);
            linkBinayrTree.inorder(root3);

            // 后序递归创建二叉树
            Console.WriteLine("\n后序递归创建二叉树");
            youbiao = 0;
            BiTNode root4 = new BiTNode();
            InCreateBiTree(ref root4);
            linkBinayrTree.postorder(root4);
            Console.WriteLine();
            
        }
        /// <summary>
        /// 递归初始化二叉树 , 输入为扩展二叉树的前序遍历 , 得以确定树形.
        /// </summary>
        /// <param name="p"></param>
        public static void PreCreateBiTree(ref BiTNode p)
        {
            int val = preArray[youbiao++];
            if (val == 0)
            {
                p = null;
            }
            else
            {
                p = new BiTNode(val);
                PreCreateBiTree(ref p.lchild);
                PreCreateBiTree(ref p.rchild);
            }
        }
        /// <summary>
        /// 中序递归创建二叉树
        /// </summary>
        /// <param name="p"></param>
        public static void InCreateBiTree(ref BiTNode p)
        {
            int val = inArray[youbiao++];
            if (val == 0)
            {
                p = null;
            }
            else
            {
                InCreateBiTree(ref p.lchild);
                p = new BiTNode(val);
                InCreateBiTree(ref p.rchild);
            }
        }
        /// <summary>
        /// 后序递归创建二叉树
        /// </summary>
        /// <param name="p"></param>
        public static void PostCreateBiTree(ref BiTNode p)
        {
            int val = postArray[youbiao++];
            if (val == 0)
            {
                p = null;
            }
            else
            {
                PostCreateBiTree(ref p.lchild);
                PostCreateBiTree(ref p.rchild);
                p = new BiTNode(val);
            }
        }
    }
    /// <summary>
    /// 二叉树的二叉链表实现
    /// </summary>
    public class BiTNode
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
    public struct indexnode
    {
        public indexnode(int key, int offset)
        {
            this.Key = key;
            this.Offset = offset;
        }
        public int Key { get; set; }
        public int Offset { get; set; }
    }

    public class LinkBinayrTree
    {
        public BiTNode Head { get; set; }
        public LinkBinayrTree()
        {
            Head = null;
        }
        public LinkBinayrTree(int val)
        {
            BiTNode p = new BiTNode(val);
            Head = p;
        }
        public LinkBinayrTree(int val, BiTNode lp, BiTNode rp)
        {
            Head = new BiTNode(val, lp, rp);
        }
        public bool IsEmpty()
        {
            if (Head == null)
                return true;
            else
                return false;
        }
        public BiTNode Root()
        {
            return Head;
        }
        public BiTNode GetLChild(BiTNode p)
        {
            return p.lchild;
        }
        public BiTNode GetRChild(BiTNode p)
        {
            return p.rchild;
        }
        /// <summary>
        /// 将结点p的左子树插入值为val的新结点，原来的左子树称为新结点的左子树
        /// </summary>
        /// <param name="val"></param>
        /// <param name="p"></param>
        public void InsertL(int val, BiTNode p)
        {
            BiTNode tmp = new BiTNode(val)
            {
                lchild = p.lchild
            };
            p.lchild = tmp;
        }
        /// <summary>
        /// 将结点p的右子树插入值为val的新结点，原来的右子树称为新节点的右子树
        /// </summary>
        /// <param name="val"></param>
        /// <param name="p"></param>
        public void InserR(int val, BiTNode p)
        {
            BiTNode tmp = new BiTNode(val)
            {
                rchild = p.rchild
            };
            p.rchild = tmp;
        }
        /// <summary>
        /// 若p不为空 , 删除p的左子树
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public BiTNode DeleteL(BiTNode p)
        {
            if(p==null || p.lchild == null)
            {
                return null;
            }
            BiTNode tmp = p.lchild;
            p.lchild = null;
            return tmp;
        }
        /// <summary>
        /// 若p不为空 , 删除p的右子树 , 并将右子树根返回
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public BiTNode DeleteR(BiTNode p)
        {
            if(p==null || p.rchild == null)
            {
                return null;
            }
            BiTNode tmp = p.rchild;
            p.rchild = null;
            return tmp;
        }
        /// <summary>
        /// 查找value
        /// </summary>
        /// <param name="root"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public BiTNode Search(BiTNode root, int value)
        {
            BiTNode p = root;
            if (p == null)
                return null;
            if (p.data.Equals(value))
                return p;
            if (p.lchild != null)
                return Search(p.lchild, value);
            if (p.rchild != null)
                return Search(p.rchild, value);
            return null;
        }
        /// <summary>
        /// 判断是否为叶子节点
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool IsLeaf(BiTNode p)
        {
            if (p != null && p.rchild == null && p.lchild == null)
                return true;
            else
                return false;
        }
        /// <summary>
        /// 中序遍历
        /// 遍历根结点的左子树->根结点->遍历根结点的右子树 
        /// </summary>
        /// <param name="p"></param>
        public void inorder(BiTNode p)
        {
            if(IsEmpty())
            {
                Console.WriteLine("Tree is empty");
                return;
            }
            if (p != null)
            {
                inorder(p.lchild);
                Console.WriteLine(p.data + " ");
                inorder(p.rchild);
            }
        }
        public void preorder(BiTNode p)
        {
            if (IsEmpty())
            {
                //Console.WriteLine("Tree is empty");
            }
            if (p != null)
            {
                Console.Write(p.data + " ");
                preorder(p.lchild);
                preorder(p.rchild);
            }
        }
        public void postorder(BiTNode p)
        {
            if (IsEmpty())
            {
                Console.WriteLine("Tree is empty");
            }
            if (p != null)
            {
                postorder(p.lchild);
                postorder(p.rchild);
                Console.WriteLine(p.data + " ");
            }
        }
        public void LevelOrder(BiTNode root)
        {
            if (root == null)
                return;
            Queue<BiTNode> sq = new Queue<BiTNode>();
            sq.Enqueue(root);
            while (sq.Count != 0)
            {
                BiTNode tmp = sq.Dequeue();
                Console.Write(tmp.data+" ");
                if (tmp.lchild != null)
                    sq.Enqueue(tmp.lchild);
                if (tmp.rchild != null)
                    sq.Enqueue(tmp.rchild);
            }
        }
    }
}
