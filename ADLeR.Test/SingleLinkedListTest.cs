using ADLER.Collections;
using NUnit.Framework;

namespace ADLeR.Test
{
    [TestFixture]
    class SingleLinkedListTest
    {

        [Test]
        public void TestAdd()
        {
            SingleLinkedList<int> testList = new SingleLinkedList<int>();
            testList.Add(0);
            testList.Add(1);

            Assert.AreEqual(0, testList[0]);
            Assert.AreEqual(1, testList[1]);
            Assert.AreEqual(2, testList.Count);
        }

        [Test]
        public void TestRemoveStart()
        {
            SingleLinkedList<int> testList = new SingleLinkedList<int>();
            testList.Add(0);
            testList.Add(1);

            testList.Remove(0);

            Assert.AreEqual(1, testList[0]);
            Assert.AreEqual(1, testList.Count);
        }

        [Test]
        public void TestRemoveMiddle()
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
        public void TestRemoveEnd()
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
    }
}
