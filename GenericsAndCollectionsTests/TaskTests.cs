using System;
using System.Collections.Generic;
using NUnit.Framework;

using GenericsAndCollections;
using GenericsAndCollections.Task_2;
using GenericsAndCollections.Task_3;
using GenericsAndCollections.Task_4;
using GenericsAndCollections.Task_5;
using GenericsAndCollections.Task_6;
using GenericsAndCollections.Task_7;
using GenericsAndCollections.Task_7.custom_for_Tests;
using GenericsAndCollections.Task_8;

namespace GenericsAndCollectionsTests
{
    public class TaskTests
    {
        #region BinarySearchTests
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 2, 1)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0, -1)]
        [TestCase(new int[] { 5, 4, 3, 2, 1 }, 5, 0)]
        public void BinarySearchTests(int [] data, int searchValue ,int expected)
        {
            Assert.AreEqual(Search.Binary(data, searchValue), expected);
        }

        [TestCase(new int[] { 531, 231, 934, 112, 558 }, 558)]
        [TestCase(new int[] { 1000, 231, 934, 112, 558 }, 558)]
        public void BinarySearchTestsException(int[] data, int searchValue)
        {
            Assert.Throws<ArgumentException>(() => Search.Binary(data, searchValue));
        }

        #endregion

        #region FrequencyOfWordsTests
        static public IEnumerable<TestCaseData> combination_FrequencyOfWordsTests()
        {
            yield return new TestCaseData("e e ad d e d d vdv fw fw ad", 
                new List<Word>() { new Word("e", 3), new Word("ad", 2), new Word("d", 3), new Word("vdv", 1), new Word("fw", 2) }).SetName("[FrequencyOfWords] test 1");

            yield return new TestCaseData("a b c",
                new List<Word>() { new Word("a", 1), new Word("b", 1), new Word("c", 1) }).SetName("[FrequencyOfWords] test 2");

            yield return new TestCaseData("abc",
                new List<Word>() { new Word("abc", 1) }).SetName("[FrequencyOfWords] test 3");

            yield return new TestCaseData("test test test",
                new List<Word>() { new Word("test", 3) }).SetName("[FrequencyOfWords] test 4");

        }

        [TestCaseSource("combination_FrequencyOfWordsTests")]
        public void FrequencyOfWordsTests(string text, List<Word> expected)
        {
            if (expected.Equals(FrequencyOfWords.Search(text)))
            {
                Assert.Pass();
            }
        }
        #endregion

        #region FibonacciTests

        [TestCase(new int[] { 1, 1, 2, 3, 5, 8, 13 })]
        [TestCase(new int[] { 1, 1 })]
        [TestCase(new int[] { 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144})]
        public void FibonacciTests(int [] expected)
        {
            Fibonacci fibonacci = new Fibonacci(expected.Length);
            int[] array = new int[expected.Length];
            int i = 0;

            foreach(int item in fibonacci)
            {
                array[i] = item;
                i++;
            }

            Assert.AreEqual(array, expected);
        }

        static public IEnumerable<TestCaseData> combination_QueueTests()
        {
            yield return new TestCaseData(6, new int[] { 1, 2, 3, 4, 5 }, new int[] { 2, 3, 4, 5, 6}).SetName("[QueueTests] test 1");
            yield return new TestCaseData(0, new int[] { 0 }, new int[] { 0 }).SetName("[QueueTests] test 2");

        }
        #endregion

        #region QueueTests
        [TestCaseSource("combination_QueueTests")]
        public void QueueTests(int item, int[] array, int[] expected)
        {
            GenericsAndCollections.Task_4.Queue<int> queue = new GenericsAndCollections.Task_4.Queue<int>(array);

            int count = queue.Count;

            int objTest1 = queue.Peek();

            if(count != queue.Count || !array[0].Equals(objTest1))
            {
                 throw new AssertionException("Peek method does not work correctly");
            }

            int objTest2 = queue.Dequeue();

            if(!array[0].Equals(objTest2))
            {
                throw new AssertionException("Dequeue method does not work correctly");
            }

            queue.Enqueue(item);
            Assert.AreEqual(queue.GetArray(), expected);
        }
        #endregion

        #region Stack
        static public IEnumerable<TestCaseData> combination_StackTests()
        {
            yield return new TestCaseData(6, new int[] { 1, 2, 3, 4, 5 }, new int[] { 6, 4, 3, 2, 1}).SetName("[StackTests] test 1");
            yield return new TestCaseData(0, new int[] { 0 }, new int[] { 0 }).SetName("[StackTests] test 2");
        }

        [TestCaseSource("combination_StackTests")]
        public void StackTests(int item, int[] array, int[] expected)
        {
            GenericsAndCollections.Task_5.Stack<int> queue = new GenericsAndCollections.Task_5.Stack<int>(array);

            int count = queue.Count;

            int objTest1 = queue.Peek();

            if (count != queue.Count || !array[array.Length-1].Equals(objTest1))
            {
                throw new AssertionException("Peek method does not work correctly");
            }

            int objTest2 = queue.Pop();

            if (!array[array.Length - 1].Equals(objTest2))
            {
                throw new AssertionException("Pop method does not work correctly");
            }

            queue.Push(item);
            Assert.AreEqual(queue.GetArray(), expected);
        }
        #endregion

        #region SetTests
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, new int[] {1, 2, 3, 4, 5, 6})]
        [TestCase(new int[] { 1, 1}, new int[] { 5, 5, 6 }, new int[] { 1, 5, 6 })]
        public void SetTests_Union(int [] firstArray, int [] secondArray, int [] expectedArray)
        {
            Set<int> setFirst = new Set<int>(firstArray);
            Set<int> setSecond = new Set<int>(secondArray);

            Assert.AreEqual(Set<int>.Union(setFirst, setSecond).GetArray(), expectedArray);

        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, new int[] { 1, 2, 3})]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 })]
        public void SetTests_Difference(int[] firstArray, int[] secondArray, int[] expectedArray)
        {
            Set<int> setFirst = new Set<int>(firstArray);
            Set<int> setSecond = new Set<int>(secondArray);

            Assert.AreEqual(Set<int>.Difference(setFirst, setSecond).GetArray(), expectedArray);

        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 3, 2, 6 }, new int[] { 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 8, 9, 10 }, null)]
        public void SetTests_Intersection(int[] firstArray, int[] secondArray, int[] expectedArray)
        {
            Set<int> setFirst = new Set<int>(firstArray);
            Set<int> setSecond = new Set<int>(secondArray);

            Set<int> result = Set<int>.Intersection(setFirst, setSecond);
            Assert.AreEqual(result?.GetArray(), expectedArray);

        }

        #endregion

        #region BinarySearchTreeTests

        static public Action<BinaryTreeNode<string>, int> act1 = (node, i) =>
                                                        {
                                                            node.Data += i.ToString();
                                                        };

        static public IEnumerable<TestCaseData> combination_BinarySearchTreeTests_string()
        {
            yield return new TestCaseData(new string[] { "my", "first", "test" },
                                          act1,
                                          new Postorder<string>(),
                                          new string[] { "my2", "first0", "test1" }).SetName("[BinarySearchTree_string] test 1");

            yield return new TestCaseData(new string[] { "my", "first", "test" },
                                          act1,
                                          new Preorder<string>(),
                                          new string[] { "my0", "first1", "test2" }).SetName("[BinarySearchTree_string] test 2");

            yield return new TestCaseData(new string[] { "my", "first", "test" },
                                          act1,
                                          new Inorder<string>(),
                                          new string[] { "my1", "first0", "test2" }).SetName("[BinarySearchTree_string] test 3");
        }

        [TestCaseSource("combination_BinarySearchTreeTests_string")]
        public void BinarySearchTreeTestsString(string [] items, Action<BinaryTreeNode<string>, int> action, ICommand<string> command, string [] expected)
        {
            BinarySearchTree<string> binarySearch = new BinarySearchTree<string>(items);

            binarySearch.command = command;
            binarySearch.Traversal(action);

            Assert.AreEqual(binarySearch.GetArray(), expected);
        }

        static public Action<BinaryTreeNode<Point>, int> act2 = (node, i) =>
                {
                    if(node.Data.X % 2 == 0)
                    {
                        node.Data = new Point(node.Data.X+1, node.Data.Y);
                    }
                };

        static public IEnumerable<TestCaseData> combination_BinarySearchTreeTests_point()
        {
            yield return new TestCaseData(new Point[] { new Point(2, 3), new Point(1, 4), new Point(2, 2) },
                                          act2,
                                          new Postorder<Point>(),
                                          new Point[] { new Point(3, 3), new Point(3, 2), new Point(1, 4) }).SetName("[BinarySearchTree_point] test 1");

            yield return new TestCaseData(new Point[] { new Point(2, 3), new Point(1, 4), new Point(2, 2) },
                                          act2,
                                          new Preorder<Point>(),
                                          new Point[] { new Point(3, 3), new Point(3, 2), new Point(1, 4) }).SetName("[BinarySearchTree_point] test 2");

            yield return new TestCaseData(new Point[] { new Point(2, 3), new Point(1, 4), new Point(2, 2) },
                                          act2,
                                          new Inorder<Point>(),
                                          new Point[] { new Point(3, 3), new Point(3, 2), new Point(1, 4) }).SetName("[BinarySearchTree_point] test 3");
        }

        [TestCaseSource("combination_BinarySearchTreeTests_point")]
        public void BinarySearchTreeTestsPoint(Point []items, Action<BinaryTreeNode<Point>, int> action, ICommand<Point> command, Point []expected)
        {
            BinarySearchTree<Point> binarySearch = new BinarySearchTree<Point>(items);

            binarySearch.command = command;
            binarySearch.Traversal(action);

            Assert.AreEqual(binarySearch.GetArray(), expected);
        }

        #endregion

        #region PolishNotation
        
        [TestCase("5 1 2 + 4 * + 3 -", 14)]
        [TestCase("5 1 /", 5)]
        [TestCase("2 3 4 - 7 * + 2 /", 4.5)]
        public void PolishNotationTests(string str, double expected)
        {
            Assert.AreEqual(PolishNotation.Calc(str), expected);
        }

        #endregion
    }
}