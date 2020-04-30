using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTree
{
    internal class Program
    {
        public BTreeNode root;

        private static void Main(string[] args)
        {
        }

        public void Insert(int data, int recordPointer)
        {
            if (root == null)
            {
                root = new BTreeNode();
                root.data[0] = data;
                root.recordPointer[0] = recordPointer;
            }
            else
            {
            }
        }
    }

    internal class BTreeNode
    {
        // 数据
        public int[] data = new int[4];

        // 数据在磁盘上的位置
        public int[] recordPointer = new int[4];

        // 孩子指针
        public BTreeNode[] childNodes = new BTreeNode[5];

        public BTreeNode()
        {
        }
    }
}