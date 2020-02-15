using System;
using System.Collections;
using System.Collections.Generic;

namespace GenericsAndCollections.Task_7
{
    public class Inorder<T> :ICommand<T> where T : IComparable
    {
        BinaryTreeNode<T> _head;

        public void Execute(Action<BinaryTreeNode<T>, int> action, BinaryTreeNode<T> head, ref int i)
        {
            _head = head;

            IEnumerator enumerator = GetEnumerator();

            while(enumerator.MoveNext())
            {
                action((BinaryTreeNode<T>)enumerator.Current, i);
                i++;
            }
        }

        private IEnumerator GetEnumerator()
        {
            if (_head != null)
            {
                Task_5.Stack<BinaryTreeNode<T>> stack = new Task_5.Stack<BinaryTreeNode<T>>();

                BinaryTreeNode<T> current = _head;

                bool goLeftNext = true;

                stack.Push(current);

                while (stack.Count > 0)
                {
                    if (goLeftNext)
                    {
                        while (current.Left != null)
                        {
                            stack.Push(current);
                            current = current.Left;
                        }
                    }

                    yield return current;

                    if (current.Right != null)
                    {
                        current = current.Right;
                        goLeftNext = true;
                    }
                    else
                    {
                        current = stack.Pop();
                        goLeftNext = false;
                    }
                }
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
