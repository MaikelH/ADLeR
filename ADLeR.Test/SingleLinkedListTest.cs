using System;
using System.Collections.Generic;
using ADLER.Collections;
using NUnit.Framework;

namespace ADLeR.Test
{
    [TestFixture]
    class SingleLinkedListTest
    {

        [Test]
        public void AddTest()
        {
            SingleLinkedList<int> testList = new SingleLinkedList<int>();
            testList.Add(0);
            testList.Add(1);

            Assert.AreEqual(0, testList[0]);
            Assert.AreEqual(1, testList[1]);
            Assert.AreEqual(2, testList.Count);
        }

        [Test]
        public void RemoveStartTest()
        {
            SingleLinkedList<int> testList = new SingleLinkedList<int>();
            testList.Add(0);
            testList.Add(1);

            testList.Remove(0);

            Assert.AreEqual(1, testList[0]);
            Assert.AreEqual(1, testList.Count);
        }

        [Test]
        public void RemoveMiddleTest()
        {
            SingleLinkedList<int> testList = new SingleLinkedList<int>();
            testList.Add(0);
            testList.Add(1);
            testList.Add(2);

            testList.Remove(1);

            Assert.AreEqual(0, testList[0]);
            Assert.AreEqual(2, testList[2]);
            Assert.AreEqual(2, testList.Count);
        }

        [Test]
        public void RemoveEndTest()
        {
            SingleLinkedList<int> testList = new SingleLinkedList<int>();
            testList.Add(0);
            testList.Add(1);
            testList.Add(2);

            testList.Remove(2);

            Assert.AreEqual(0, testList[0]);
            Assert.AreEqual(1, testList[2]);
            Assert.AreEqual(2, testList.Count);
        }

        [Test]
        public void ContainsTest()
        {
            SingleLinkedList<int> testList = new SingleLinkedList<int>();
            testList.Add(0);
            testList.Add(1);
            testList.Add(2);
   
            Assert.IsTrue(testList.Contains(0));
            Assert.IsTrue(testList.Contains(1));
            Assert.IsTrue(testList.Contains(2));
        }

        [Test]
        public void ClearTest()
        {
            SingleLinkedList<int> testList = new SingleLinkedList<int>();
            testList.Add(0);
            testList.Add(1);
            testList.Add(2);

            testList.Clear();

            Assert.AreEqual(0, testList.Count);
            Assert.IsFalse(testList.Contains(0));
        }

        [Test]
        public void IndexOfTest()
        {
            SingleLinkedList<int> testList = new SingleLinkedList<int>();
            testList.Add(0);
            testList.Add(1);
            testList.Add(2);

            Assert.AreEqual(0, testList.IndexOf(0));
            Assert.AreEqual(2, testList.IndexOf(2));
        }

        [Test]
        public void RemoveAtStartTest()
        {
            SingleLinkedList<int> testList = new SingleLinkedList<int>();
            testList.Add(0);
            testList.Add(1);

            testList.RemoveAt(0);

            Assert.AreEqual(1, testList[0]);
            Assert.AreEqual(1, testList.Count);
        }

        [Test]
        public void RemoveAtMiddleTest()
        {
            SingleLinkedList<int> testList = new SingleLinkedList<int>();
            testList.Add(0);
            testList.Add(1);
            testList.Add(2);

            testList.RemoveAt(1);

            Assert.AreEqual(0, testList[0]);
            Assert.AreEqual(2, testList[2]);
            Assert.AreEqual(2, testList.Count);
        }

        [Test]
        public void RemoveAtEndTest()
        {
            SingleLinkedList<int> testList = new SingleLinkedList<int>();
            testList.Add(0);
            testList.Add(1);
            testList.Add(2);

            testList.RemoveAt(2);

            Assert.AreEqual(0, testList[0]);
            Assert.AreEqual(1, testList[2]);
            Assert.AreEqual(2, testList.Count);
        }

        [Test]
        public void CopyToTest()
        {
            SingleLinkedList<int> testList = new SingleLinkedList<int>();
            testList.Add(0);
            testList.Add(1);
            testList.Add(2);

            int[] array = new int[5];

            testList.CopyTo(array, 2);

            Assert.AreEqual(0, array[2]);
            Assert.AreEqual(1, array[3]);
            Assert.AreEqual(2, array[4]);
        }

        [Test]
        public void CopyToArrayToSmallTest()
        {
            SingleLinkedList<int> testList = new SingleLinkedList<int>();
            testList.Add(0);
            testList.Add(1);
            testList.Add(2);

            int[] array = new int[4];

            Assert.Catch<ArgumentException>(() => testList.CopyTo(array, 2));
        }

        [Test]
        public void CopyToArrayArrayIndexTest()
        {
            SingleLinkedList<int> testList = new SingleLinkedList<int>();
            testList.Add(0);
            testList.Add(1);
            testList.Add(2);

            int[] array = new int[4];

            Assert.Catch<ArgumentOutOfRangeException>(() => testList.CopyTo(array, -1));
        }

        [Test]
        public void EnumeratorTest()
        {
            SingleLinkedList<int> testList = new SingleLinkedList<int>();
            testList.Add(0);
            testList.Add(1);
            testList.Add(2);

            IEnumerator<int> enumerator = testList.GetEnumerator();

            Assert.AreEqual(0, enumerator.Current );
            enumerator.MoveNext();
            Assert.AreEqual(0, enumerator.Current);
            enumerator.MoveNext();
            Assert.AreEqual(1, enumerator.Current);
            enumerator.MoveNext();
            Assert.AreEqual(2, enumerator.Current);

            Assert.IsFalse(enumerator.MoveNext());

            Assert.AreEqual(0, enumerator.Current);
        }
    }
}
