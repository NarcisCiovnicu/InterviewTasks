using CustomList;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CustomListTests
{
    [TestClass]
    public class CustomListTests
    {

        [TestMethod()]
        public void Test_Constructor()
        {
            List<int> list = new();
            CustomList<int> customList = new();
            Assert.AreEqual(list.Capacity, customList.Capacity);

            list = new(15);
            customList = new(15);
            Assert.AreEqual(list.Capacity, customList.Capacity);
        }

        [TestMethod()]
        public void Test_AddInsert()
        {
            List<int> list = new();
            CustomList<int> customList = new();

            list.Add(1);
            list.Add(2);
            list.Add(3);
            customList.Add(1);
            customList.Add(2);
            customList.Add(3);
            Assert.AreEqual(list.Count, customList.Count);
            Assert.AreEqual(list[0], customList[0]);
            Assert.AreEqual(list[1], customList[1]);
            Assert.AreEqual(list[2], customList[2]);

            list.Insert(0, -1);
            list.Insert(1, -2);
            customList.Insert(0, -1);
            customList.Insert(1, -2);
            Assert.AreEqual(list.Count, customList.Count);
            Assert.AreEqual(list[0], customList[0]);
            Assert.AreEqual(list[1], customList[1]);
            Assert.AreEqual(list[2], customList[2]);
            Assert.AreEqual(list[3], customList[3]);
            Assert.AreEqual(list[4], customList[4]);

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => customList.Insert(5, 999));
        }

        [TestMethod()]
        public void Test_GetAndSet()
        {
            List<int> list = new();
            CustomList<int> customList = new();

            list.Add(1);
            customList.Add(1);
            Assert.AreEqual(list[0], customList[0]);

            list[0] = 5;
            customList[0] = 5;
            Assert.AreEqual(list[0], customList[0]);

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => customList[-1]);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => customList[3]);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => customList[-1] = 2);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => customList[3] = 2);
        }

        [TestMethod()]
        public void Test_Clear()
        {
            List<int> list = new();
            CustomList<int> customList = new();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            customList.Add(1);
            customList.Add(2);
            customList.Add(3);

            list.Clear();
            customList.Clear();
            Assert.AreEqual(list.Count, customList.Count);
        }

        [TestMethod()]
        public void Test_Contains_IndexOf()
        {
            List<int?> list = new();
            CustomList<int?> customList = new();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(null);
            customList.Add(1);
            customList.Add(2);
            customList.Add(3);
            customList.Add(null);

            Assert.AreEqual(list.Contains(2), customList.Contains(2));
            Assert.AreEqual(list.Contains(null), customList.Contains(null));
            Assert.AreEqual(list.Contains(6), customList.Contains(6));

            list.Remove(null);
            customList.Remove(null);
            Assert.AreEqual(list.Contains(null), customList.Contains(null));

            Assert.AreEqual(list.IndexOf(2), customList.IndexOf(2));
            Assert.AreEqual(list.IndexOf(null), customList.IndexOf(null));
            Assert.AreEqual(list.IndexOf(5), customList.IndexOf(5));
        }

        [TestMethod()]
        public void Test_Remove()
        {
            List<int> list = new();
            CustomList<int> customList = new();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            customList.Add(1);
            customList.Add(2);
            customList.Add(3);

            Assert.AreEqual(list.Remove(2), customList.Remove(2));
            Assert.AreEqual(list.Remove(3), customList.Remove(3));
            Assert.AreEqual(list.Remove(4), customList.Remove(4));
            Assert.AreEqual(list.Count, customList.Count); // 1

            list.Add(2);
            list.Add(3);
            customList.Add(2);
            customList.Add(3);
            // count 3

            list.RemoveAt(2);
            customList.RemoveAt(2);
            Assert.AreEqual(list.Count, customList.Count); // 2
            Assert.AreEqual(list[0], customList[0]);
            Assert.AreEqual(list[1], customList[1]);

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => customList.RemoveAt(2));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => customList.RemoveAt(3));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => customList.RemoveAt(-1));
        }

        [TestMethod()]
        public void Test_CopyTo()
        {
            List<int> list = new();
            CustomList<int> customList = new();
            list.Add(1);
            list.Add(2);
            customList.Add(1);
            customList.Add(2);

            int[] arr1 = new int[2];
            int[] arr2 = new int[2];

            list.CopyTo(arr1, 0);
            customList.CopyTo(arr2, 0);

            Assert.AreEqual(arr1[0], arr2[0]);
            Assert.AreEqual(arr1[1], arr2[1]);
        }
    }
}
