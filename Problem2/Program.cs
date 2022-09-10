using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Problem2
{
    
    
    public class TreeNode
    {
        private int index;          //节点序列号
        private int data;           //节点数据
        private int parentIndex;            //父节点
        private int leftChildIndex;         //左子节点
        private int rightChildIndex;        //右子节点

        //重载构造函数
        public TreeNode(int index,int data,int parentIndex,int leftChildIndex,int rightChildIndex)
        {
            this.index = index;
            this.data = data;
            this.parentIndex = parentIndex;
            this.leftChildIndex = leftChildIndex;
            this.rightChildIndex = rightChildIndex;
        }

        //快捷属性
        public int Index { get => index; set => index = value; }
        public int Data { get => data; set => data = value; }
        public int ParentIndex { get => parentIndex; set => parentIndex = value; }
        public int LeftChildIndex { get => leftChildIndex; set => leftChildIndex = value; }
        public int RightChildIndex { get => rightChildIndex; set => rightChildIndex = value; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            TreeNode[] tree = new TreeNode[10];
            ArrayList arrayList = new ArrayList();

            int begin = 0;      //开始节点的序列号为0
            int line = 1;       //开始节点的行数为1

            CreatTree(tree);        //构建二叉树

            arrayList.Add(tree[0].Data);        //将根节点加入
            
            FindLeftNode(tree, begin, line,ref arrayList);          //寻找二叉树的最左节点并装进ArrayList

            PrintResult(arrayList);         //打印

            Console.ReadKey();
        }

        //打印装载最左节点的ArrayList
        private static void PrintResult(ArrayList arr)
        {
            Console.Write("[");
            for (int i = 0; i < arr.Count; i++)
            {
                Console.Write(arr[i]);
                if ((i + 1) < arr.Count)
                {
                    Console.Write(",");
                }
            }
            Console.Write("]");
        }

        //寻找最左节点函数
        private static void FindLeftNode(TreeNode[] tree, int beginIndex,int line,ref ArrayList arr)
        {
            
            if (tree[beginIndex].LeftChildIndex > 0)            //当一个节点有左子节点时，那么他的右子节点一定不是最左节点
            {
                if ((line + 1) > arr.Count)             //当子节点的行数大于已经找到最左节点的个数时，该子节点即为最左节点
                {
                    arr.Add(tree[tree[beginIndex].LeftChildIndex].Data);        //将子节点加入ArrayList
                    
                }

                FindLeftNode(tree, tree[beginIndex].LeftChildIndex, line + 1, ref arr);         //在子节点的子树中寻找最左节点

                if (tree[beginIndex].RightChildIndex > 0)           //当该节点有左右子节点时，应在其右子节点的子树上继续寻找最左节点
                {
                    FindLeftNode(tree, tree[beginIndex].RightChildIndex, line + 1, ref arr);
                }
            }
            else
            {
                if (tree[beginIndex].RightChildIndex > 0)           //当该节点只有右子节点时
                {
                    if ((line + 2) > arr.Count)                 //此时如果右子节点的行数大于已经找到的最左节点的个数，该右子节点为最左节点
                    {
                        arr.Add(tree[tree[beginIndex].RightChildIndex].Data);

                    }
                    FindLeftNode(tree, tree[beginIndex].RightChildIndex, line+1, ref arr);          //继续在右子节点的子树中寻找最左节点
                }
                else
                {
                    return;             //如果该节点没有子树，那么不需要在其子树继续寻找最左节点
                }
            }

        }

        //构造二叉树
        private static void CreatTree(TreeNode[] tree)
        {
            tree[0] = new TreeNode(0, 2, -1, 1, 2);
            tree[1] = new TreeNode(1, 11, 0, 3, 4);
            tree[2] = new TreeNode(2, 23, 0, 5, 6);
            tree[3] = new TreeNode(3, 10, 1, -1, -1);
            tree[4] = new TreeNode(4, 15, 1, -1, -1);
            tree[5] = new TreeNode(5, 7, 2, -1,7);
            tree[6] = new TreeNode(6, 14, 2, -1, -1);
            tree[7] = new TreeNode(7, 12, 5, 8, -1);
            tree[8] = new TreeNode(8, 13, 7, -1, -1);
        }
    }
}
