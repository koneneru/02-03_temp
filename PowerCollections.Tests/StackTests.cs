using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Wintellect.PowerCollections.Tests
{
    [TestClass]
    public class StackTests
    {
        //Constuctor Test
        [TestMethod]
        public void Constructor_ShouldCreateStackWithCorrectCapacity()
        {
            Stack<int> stack = new Stack<int>(3);
            Assert.AreEqual(3, stack.Capacity);
        }

        //Count Test
        [TestMethod]
        public void Count_ShouldCorrectlyDisplayTheNumberOfElementsOnStack()
        {
            Stack<int> stack = new Stack<int>(3);
            Assert.AreEqual(0, stack.Count);
        }

        //IsEmpty Tests
        [TestMethod]
        public void IsEmty_ShouldBeTrueWhenStackIsNew()
        {
            Stack<int> stack = new Stack<int>(3);
            Assert.IsTrue(stack.IsEmpty);
        }

        [TestMethod]
        public void IsEmpty_ShouldBeFalseAfterPush()
        {
            Stack<int> stack = new Stack<int>(3);
            stack.Push(3);
            Assert.IsFalse(stack.IsEmpty);
        }

        [TestMethod]
        public void IsEmpty_ShouldBeTrueAfterPop()
        {
            Stack<int> stack = new Stack<int>(3);
            stack.Push(1);
            stack.Pop();
            Assert.IsTrue(stack.IsEmpty);
        }

        //IsFull Tests
        [TestMethod]
        public void IsFull_ShouldBeFalseWhenStackIsNew()
        {
            Stack<int> stack = new Stack<int>(3);
            Assert.IsFalse(stack.IsFull);
        }

        [TestMethod]
        public void IsFull_ShouldBeTrueAfterFilling()
        {
            Stack<int> stack = new Stack<int>(1);
            stack.Push(1);
            Assert.IsTrue(stack.IsFull);
        }

        [TestMethod]
        public void IsFull_ShouldBeFalseAfterPop()
        {
            Stack<int> stack = new Stack<int>(2);
            stack.Push(2);
            stack.Push(1);
            stack.Pop();
            Assert.IsFalse(stack.IsFull);
        }

        //Push Tests
        [TestMethod]
        public void Push_ShouldBeOKWhenStackIsNotFull()
        {
            Stack<int> stack = new Stack<int>(3);
            stack.Push(3);
            Assert.AreEqual(1, stack.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Push_ShouldThrowExceptionWhenStackIsFull()
        {
            Stack<int> stack = new Stack<int>(1);
            stack.Push(3);
            stack.Push(2);
        }

        //Pop Tests
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Pop_ShouldThrowExceptionWhenStackIsEmpty()
        {
            Stack<int> stack = new Stack<int>(3);
            stack.Pop();
        }

        [TestMethod]
        public void Pop_ShouldBeOKWhenSatckIsNotEmpty()
        {
            Stack<int> stack = new Stack<int>(3);
            stack.Push(3);
            stack.Pop();
            Assert.AreEqual(0, stack.Count);
        }

        //Top Tests
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Top_ShouldThrowExceptionWhenStackIsEmpty()
        {
            Stack<int> stack = new Stack<int>(3);
            stack.Top();
        }

        [TestMethod]
        public void Top_ShouldBeOKWhenStackIsNotEmpty()
        {
            Stack<int> stack = new Stack<int>(3);
            stack.Push(3);
            stack.Top();
            Assert.AreEqual(1, stack.Count);
        }

        //Enumerator Test
        [TestMethod]
        public void Enumerator_ShouldReturnStackFromTopToBottom()
        {
            Stack<int> stack = new Stack<int>(3);
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            int[] refArr = new int[] { 3, 2, 1 };
            int[] testArr = new int[3];
            int i = 0;
            foreach (int item in stack)
                testArr[i++] = item;
            CollectionAssert.AreEqual(refArr, testArr);
        }
    }
}

