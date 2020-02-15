using System;
using System.Collections.Generic;

namespace GenericsAndCollections.Task_7
{
    public class Postorder<T> : ICommand<T> where T : IComparable
    {
        public void Execute(Action<BinaryTreeNode<T>, int> action, BinaryTreeNode<T> node, ref int i)
        {
            if (node != null)
            {
                Execute(action, node.Left, ref i);
                Execute(action, node.Right, ref i);
                action?.Invoke(node, i);
                i++;
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
