using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 图邻接矩阵
{
    

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    class MGraphNode
    {
        const int MAXVEX = 100;
        public const int INFINITY = 65535;
        public char[] vexs = new char[MAXVEX];
        public int[,] arc = new int[MAXVEX,MAXVEX];
        public int numVertexes, numEdges;
        

    }
    class MGraph
    {
        public void CreateMGraph(MGraphNode G)
        {
            int i, j, k, w;
            G.numVertexes = 4;
            G.numEdges = 4;
            G.vexs[0] = 'a';
            G.vexs[1] = 'b';
            G.vexs[2] = 'c';
            G.vexs[3] = 'd';
            // 邻接矩阵初始化
            for (i = 0; i < G.numVertexes; i++)
            {
                for (j = 0; j < G.numVertexes; j++)
                {
                    if (i == j)
                    {
                        G.arc[i, j] = 0;
                    }
                    else
                    {
                        G.arc[i, j] = MGraphNode.INFINITY;
                    }
                }
            }
            G.arc[0, 1] = 1;
            G.arc[0, 3] = 4;
            G.arc[1, 2] = 2;
            G.arc[2, 3] = 3;
            G.arc[1, 0] = 1;
            G.arc[3, 0] = 4;
            G.arc[2, 1] = 2;
            G.arc[3, 2] = 3;
        }
    }
}
