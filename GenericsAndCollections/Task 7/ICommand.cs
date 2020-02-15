using System;

namespace GenericsAndCollections.Task_7
{
    public interface ICommand<T> where T : IComparable
    {
        void Execute(Action<BinaryTreeNode<T>, int> action, BinaryTreeNode<T> node, ref int i);
        T[] TraversalArray(BinaryTreeNode<T> node, int count);
    }
}
