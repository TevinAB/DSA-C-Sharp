using DSA_C_Sharp.Lists;
using Xunit;

namespace DSA.Tests.ListTests {

    public class LinkedListTest {

        [Fact]
        public void AppendTest() {
            LinkedList<int> list = new LinkedList<int>();

            list.Append(102);
            list.Append(21);
            list.Append(33);
            list.Append(44);
            list.Append(5);

            Assert.Equal(5, list.Count);
        }

        [Fact]
        public void PrependTest() {
            LinkedList<int> list = new LinkedList<int>();

            list.Prepend(21);
            list.Prepend(211);
            list.Prepend(212);

            Assert.Equal(3, list.Count);
            Assert.Equal(212, list.First);
        }

        [Fact]
        public void InsertAtTest() {
            LinkedList<int> list = new LinkedList<int>();

            list.Prepend(21);
            list.Prepend(211);
            list.Prepend(212);
            list.InsertAt(1, 500);

            Assert.Equal(500, list.GetAt(1));

            list.InsertAt(3, 200);
            //Assert.Equal(5, list.Count);
            Assert.Equal(21, list.Last);
        }

        [Fact]
        public void RemoveAtTest() {
            LinkedList<int> list = new LinkedList<int>();

            list.Append(102);
            list.Append(21);
            list.Append(33);

            list.RemoveAt(1);

            Assert.Equal(33, list.GetAt(1));
        }

    }
}
