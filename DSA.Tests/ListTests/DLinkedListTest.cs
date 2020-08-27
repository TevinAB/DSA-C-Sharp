using System;
using System.Collections.Generic;
using System.Linq;
using DSA_C_Sharp.Lists;
using Xunit;

namespace DSA.Tests.ListTests {

    public class DLinkedListTest {

        [Fact]
        public void RemoveAtTest() {
            DLinkedList<string> list = new DLinkedList<string>();

            list.Append("a");
            list.Append("b");
            list.Append("c");
            list.Append("d");
            list.Append("e");
            list.Append("f");

            // Remove 1st
            list.RemoveAt(0);
            Assert.True(list[0] == "b", "Wrong element.");

            //Remove new 3rd
            list.RemoveAt(3);
            Assert.True(list[3] == "f", "Wrong element.");
        }


        [Fact]
        public void InsertAt() {
            DLinkedList<int> list = new DLinkedList<int>();

            list.Prepend(-1);
            list.InsertAt(0, 2);
            list.InsertAt(0, 4);
            list.InsertAt(0, 99);
            list.InsertAt(0, 19);

            Assert.Equal(2 , list[3]);
        }

        [Fact]
        public void GetAtTest() {
            DLinkedList<int> list = new DLinkedList<int>();

            list.Append(1);
            list.Prepend(8);
            list.Append(4);
            list.Prepend(9);

            Assert.Equal(1,list.GetAt(2));

        }





    }
}
