using System;
using System.Collections.Generic;
using NewsRetriever;
using NUnit.Framework;

namespace ADLeR.Test
{

    [TestFixture]
    public class UniqueDictionaryTest
    {
        [Test]
        public void InitTest()
        {
            NonUniqueDictionary<string, string> collection = new NonUniqueDictionary<string, string>();

            Assert.IsNotNull(collection);
        }

        [Test]
        public void IndexTest()
        {
            NonUniqueDictionary<string, string> collection = new NonUniqueDictionary<string, string>();
            HashSet<string> set = new HashSet<string>{"1"};

            collection.Add(new KeyValuePair<string, HashSet<string>>("0", set));

            Assert.AreEqual(set, collection["0"]);
        }

        [Test]
        public void AddTest()
        {
            NonUniqueDictionary<string, string> collection = new NonUniqueDictionary<string, string>();
            collection.Add("1", "2");

            Assert.IsTrue(collection["1"].Contains("2"));
        }

        [Test]
        public void CountTest()
        {
            NonUniqueDictionary<string, string> collection = new NonUniqueDictionary<string, string>();
            collection.Add("1", "2");
    
            Assert.AreEqual(1, collection.Count);
        }
    }
}