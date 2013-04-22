using ADLER.Collections;
using NUnit.Framework;
using System.Windows;

namespace ADLeR.Test
{
    [TestFixture]
    class KdTreeTest
    {
        [Test]
        public void TestAdd()
        {
            KdTree<Vector> tree = new KdTree<Vector>(2, CompareFunction); 
            tree.Add(new Vector(1.0, 1.0));
            Assert.AreEqual(1,tree.Count);
            tree.Add(new Vector(2.0, 2.0));
            Assert.AreEqual(2, tree.Count);
            tree.Add(new Vector(0.0, 0.0));
            Assert.AreEqual(3, tree.Count);
            tree.Add(new Vector(2.0, 0.0));
            Assert.AreEqual(4, tree.Count);
            tree.Add(new Vector(2.0, 4.0));
            Assert.AreEqual(5, tree.Count);
        }

        public int CompareFunction(Vector first, Vector second, int dimension)
        {
            return dimension == 1 ? first.X.CompareTo(second.X) : first.Y.CompareTo(second.Y);
        }
    }
}
