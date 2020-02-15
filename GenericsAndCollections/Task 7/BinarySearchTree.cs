using System;

namespace GenericsAndCollections.Task_7
{
    public class BinarySearchTree<T> where T : IComparable
    {
        private BinaryTreeNode<T> _head;
        public int Count { get; private set; }
        public ICommand<T> command { get; set; }

        public BinarySearchTree(T item)
        {
            if (item == null)
            {
                throw new ArgumentException("item is null");
            }

            Insert(item);
        }

        public BinarySearchTree(T firstItem, T secondItem)
        {
            if (firstItem == null)
            {
                throw new ArgumentException("firstItem is null");
            }

            if (secondItem == null)
            {
                throw new ArgumentException("secondItem is null");
            }

            Insert(firstItem);
            Insert(secondItem);
        }

        public BinarySearchTree(params T[] array)
        {
            if (array == null)
            {
                throw new ArgumentException("Array is null");
            }

            foreach (T item in array)
            {
                Insert(item);
            }
        }

        public void Insert(T data)
        {
            if(_head == null)
            {
                _head = new BinaryTreeNode<T>(data);
                return;
            }
            else
            {
                InsertTo(_head, data);
            }

            Count++;
        }

        private void InsertTo(BinaryTreeNode<T> node, T data)
        {
            if (data.CompareTo(node.Data) < 0) // меньше узла
            {
                if (node.Left == null)
                {
                    node.Left = new BinaryTreeNode<T>(data);
                    node.Left.Parent = node;
                }
                else
                {
                    InsertTo(node.Left, data);
                }
            }
            else // больше или равно
            {
                if(node.Right == null)
                {
                    node.Right = new BinaryTreeNode<T>(data);
                    node.Right.Parent = node;
                }
                else
                {
                    InsertTo(node.Right, data);
                }
            }
        }

        public void Remove(T data)
        {
            BinaryTreeNode<T> removableNode = Find(data);

            if (removableNode == null)
            {
                return;
            }

            if (removableNode.Left == null && removableNode.Right == null)
            {
                ChangeNode(ref removableNode, null);
            }
            else if (removableNode.Left == null)
            {
                ChangeNode(ref removableNode, removableNode.Right);

                removableNode.Right.Parent = removableNode.Parent;
            }
            else if(removableNode.Right == null)
            {
                ChangeNode(ref removableNode, removableNode.Left);

                removableNode.Left.Parent = removableNode.Parent;
            }
            else
            {
                switch(removableNode.CurrentSide)
                {
                    case Side.Left:
                        removableNode.Parent.Left = removableNode.Right;
                        removableNode.Right.Parent = removableNode.Parent;
                        InsertTo(removableNode.Right, removableNode.Left.Data);
                        break;

                    case Side.Right:
                        removableNode.Parent.Right = removableNode.Right;
                        removableNode.Right.Parent = removableNode.Parent;
                        InsertTo(removableNode.Right, removableNode.Left.Data);
                        break;

                    default:
                        var bufLeft = removableNode.Left;
                        var bufRightLeft = removableNode.Right.Left;
                        var bufRightRight = removableNode.Right.Right;
                        removableNode.Data = removableNode.Right.Data;
                        removableNode.Right = bufRightRight;
                        removableNode.Left = bufRightLeft;
                        InsertTo(removableNode, bufLeft.Data);
                        break;
                }
            }

        }

        private void ChangeNode(ref BinaryTreeNode<T> removableNode, BinaryTreeNode<T> newNode)
        {
            if (removableNode.CurrentSide == Side.Left)
            {
                removableNode.Parent.Left = newNode;
            }
            else
            {
                removableNode.Parent.Right = newNode;
            }
        }

        public BinaryTreeNode<T> Find(T data)
        {
            BinaryTreeNode<T> current = _head;

            while(current != null)
            {
                int result = current.CompareTo(data);

                if(result > 0)
                {
                    current = current.Left;
                }
                else if (result < 0)
                {
                    current = current.Right;
                }
                else
                {
                    return current;
                }
            }

            return current;
        }

        public void Traversal(Action<BinaryTreeNode<T>, int> action)
        {
            if(command == null)
            {
                throw new NullReferenceException("The command doesn't have a reference(null)\nYou must set tree traversal type in command!");
            }

            int i = 0;
            command.Execute(action, _head, ref i);
        }

        public T [] GetArray()
        {
            if (command == null)
            {
                throw new NullReferenceException("The command doesn't have a reference(null)\nYou must set tree traversal type in command!");
            }

            return command.TraversalArray(_head, Count);
        }

        public void Clear()
        {
            _head = null;
            Count = 0;
        }

    }
}
