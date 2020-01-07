using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AVLTree
{
    internal class Program
    {
        private static BSTNode root = null;
        private static Stack<BSTNode> stack = new Stack<BSTNode>();
        private static Queue<BSTNode> queue = new Queue<BSTNode>();

        private static void Main(string[] args)
        {
            //int[] source = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //int[] source = new int[] { 6, 5, 7, 2, 5, 8 };
            //int[] source = new int[] { 1, 2, 3 };

            int[] source = new int[20];

            var localRandom = new ThreadLocal<Random>(() => new Random(Guid.NewGuid().GetHashCode()));

            // 随即并行生成1000个数
            source = Enumerable.Range(0, source.Length).AsParallel().Select(i => localRandom.Value.Next(1000)).ToArray();
            //source = new int[] { 10, 30, 20 };

            //source = Enumerable.Range(0, source.Length).ToArray();
            //source = source.Reverse().ToArray();

            foreach (var item in source)
            {
                Console.WriteLine(item);
            }

            foreach (var item in source)
            {
                if (root == null)
                {
                    root = new BSTNode(item);
                }
                else
                {
                    Insert(item, root);
                    while (stack.Count != 0)
                    {
                        BSTNode cur = stack.Pop();
                        cur.balanceFactor = ComputeTreeDepth(cur.lc) - ComputeTreeDepth(cur.rc);
                        bool flag1 = false;
                        bool flag2 = false;

                        BSTNode nodeMiddle = null;
                        if (Math.Abs(cur.balanceFactor) == 2)
                        {
                            if (item < cur.data)
                            {
                                flag1 = false;
                                if (item < cur.lc.data)
                                {
                                    flag2 = false;
                                }
                                else
                                {
                                    flag2 = true;
                                }
                            }
                            else
                            {
                                flag1 = true;
                                if (item < cur.rc.data)
                                {
                                    flag2 = false;
                                }
                                else
                                {
                                    flag2 = true;
                                }
                            }

                            // LL
                            if (!flag1 && !flag2)
                            {
                                Console.WriteLine("LL-rotate" + cur.data);
                                var tmpA = cur;
                                var tmpB = cur.lc;
                                var tmpC = cur.lc.lc;
                                var tmpBR = cur.lc.rc;

                                tmpB.lc = tmpC;
                                tmpB.rc = tmpA;
                                tmpA.lc = tmpBR;

                                nodeMiddle = tmpB;
                            }
                            // LR
                            if (!flag1 && flag2)
                            {
                                Console.WriteLine("LR-Rotate" + cur.data);
                                BSTNode tmpA = cur;
                                BSTNode tmpB = cur.lc;
                                BSTNode tmpC = cur.lc.rc;
                                BSTNode tmpCL = tmpC.lc;
                                BSTNode tmpCR = tmpC.rc;

                                tmpC.lc = tmpB;
                                tmpC.rc = tmpA;
                                tmpB.rc = tmpCL;
                                tmpA.lc = tmpCR;

                                nodeMiddle = tmpC;
                            }
                            // RL
                            if (flag1 && !flag2)
                            {
                                Console.WriteLine("RL-Rotate" + cur.data);
                                BSTNode tmpA = cur;
                                BSTNode tmpB = cur.rc;
                                BSTNode tmpC = cur.rc.lc;
                                BSTNode tmpCL = tmpC.lc;
                                BSTNode tmpCR = tmpC.rc;

                                tmpC.lc = tmpA;
                                tmpC.rc = tmpB;
                                tmpA.rc = tmpCL;
                                tmpB.lc = tmpCR;

                                nodeMiddle = tmpC;
                            }
                            // RR
                            if (flag1 && flag2)
                            {
                                Console.WriteLine("RR-Rotate" + cur.data);
                                var tmpA = cur;
                                var tmpB = cur.rc;
                                var tmpC = cur.rc.rc;
                                var tmpBL = cur.rc.lc;

                                tmpB.lc = tmpA;
                                tmpB.rc = tmpC;
                                tmpA.rc = tmpBL;

                                nodeMiddle = tmpB;
                            }

                            // 重新计算三个节点的平衡因子
                            try
                            {
                                BSTNode parent = stack.Peek();
                                if (parent.data < nodeMiddle.data)
                                {
                                    parent.rc = nodeMiddle;
                                }
                                else
                                {
                                    parent.lc = nodeMiddle;
                                }
                            }
                            catch
                            {
                                root = nodeMiddle;
                            }

                            nodeMiddle.balanceFactor = ComputeBalanceFactor(nodeMiddle);
                            nodeMiddle.lc.balanceFactor = ComputeBalanceFactor(nodeMiddle.lc);
                            nodeMiddle.rc.balanceFactor = ComputeBalanceFactor(nodeMiddle.rc);
                        }
                    }
                }
            }
            Console.WriteLine("层序遍历");
            Show(root);

            Console.WriteLine("中序遍历 : 输出树根在左右子树中间");
            InOrderTreeWalk(root);
        }

        /// <summary>
        /// 递归的方式插入node
        /// </summary>
        /// <param name="data"></param>
        /// <param name="node"></param>
        private static void Insert(int data, BSTNode node)
        {
            stack.Push(node);

            if (data < node.data)
            {
                if (node.lc == null)
                {
                    node.lc = new BSTNode(data);
                    Console.WriteLine($"Insert data {data} left of {node.data}");
                }
                else
                {
                    Insert(data, node.lc);
                }
            }
            else
            {
                if (node.rc == null)
                {
                    node.rc = new BSTNode(data);
                    Console.WriteLine($"Insert data {data} right of {node.data}");
                }
                else
                {
                    Insert(data, node.rc);
                }
            }
        }

        /// <summary>
        /// 层序遍历
        /// </summary>
        /// <param name="node"></param>
        private static void Show(BSTNode node)
        {
            BSTNode tmp = null;
            if (node == null) return;

            queue.Enqueue(node);

            while (queue.Count != 0)
            {
                tmp = queue.Dequeue();
                if (tmp.lc != null)
                {
                    queue.Enqueue(tmp.lc);
                }
                if (tmp.rc != null)
                {
                    queue.Enqueue(tmp.rc);
                }
                Console.Write($"{tmp.data}:{tmp.balanceFactor} ");
                Console.WriteLine();
            }
        }

        /// <summary>
        /// 中序遍历
        /// </summary>
        /// <param name="node"></param>
        private static void InOrderTreeWalk(BSTNode node)
        {
            if (node != null)
            {
                InOrderTreeWalk(node.lc);
                Console.Write($"{node.data}:{node.balanceFactor} ");
                InOrderTreeWalk(node.rc);
            }
        }

        /// <summary>
        /// 递归方式计算深度
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private static int ComputeTreeDepth(BSTNode node)
        {
            if (node == null)
            {
                return 0;
            }
            return Math.Max(ComputeTreeDepth(node.lc), ComputeTreeDepth(node.rc)) + 1;
        }

        private static int ComputeBalanceFactor(BSTNode node)
        {
            if (node == null)
            {
                return 0;
            }
            return ComputeTreeDepth(node.lc) - ComputeTreeDepth(node.rc);
        }
    }

    internal class BSTNode
    {
        public int data;
        public int balanceFactor;
        public BSTNode lc, rc;

        public BSTNode() : this(default)
        {
        }

        public BSTNode(int data)
        {
            this.data = data;
            balanceFactor = 0;
            lc = null;
            rc = null;
        }
    }
}