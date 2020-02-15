using System;
using System.Collections.Generic;

namespace GenericsAndCollections.Task_7
{
    public class Preorder<T> : ICommand<T> where T : IComparable
    {
        int i = 0;

        public void Execute(Action<BinaryTreeNode<T>, int> action, BinaryTreeNode<T> node, ref int i)
        {
            if(node != null)
            {
                action?.Invoke(node, i);
                i++;
                Execute(action, node.Left, ref i);
                Execute(action, node.Right, ref i);
            }
        }

        public T[] TraversalArray(BinaryTreeNode<T> node, int count)
        {
            if (count == 0)
            {
                return null;
            }

            List<T> list = new List<T>();

            ArrayRecord(node, ref list);

            return list.ToArray();
        }

        private void ArrayRecord(BinaryTreeNode<T> node, ref List<T> list)
        {
            if (node != null)
            {
                list.Add(node.Data);

                ArrayRecord(node.Left, ref list);
                ArrayRecord(node.Right, ref list);

            }
        }
    }
}
