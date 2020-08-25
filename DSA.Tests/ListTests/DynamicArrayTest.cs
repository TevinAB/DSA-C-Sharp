using System;
using DSA_C_Sharp.Lists;
using Xunit;

namespace DSA.Tests {

    public class DynamicArrayTest {

        [Fact]
        public void InsertTest() {

            DynamicArray<int> array = new DynamicArray<int>();

            for (int i = 0; i < 10000; i++) {
                array.Insert(i);
            }

            for (int i = 500; i < 1500; i++) {
                array.RemoveAt(i);
            }


            int count = 10000 - 1000;

            Assert.True(array.Size == count, "Count check failed..");


            array.InsertAt(499, 99999);

            Assert.True(array[499] == 99999, "Insert At test failed.");

            //----------------------------------------------------\\

            DynamicArray<int> dArray = new DynamicArray<int>(10);

            for (int i = 0; i < 2000; i++) {
                dArray.Insert(i);
            }

            for (int i = 0; i < 500; i++) {
                dArray.RemoveLast();
            }

            int si = 0;
            foreach (int i in dArray) {
                si++;
            }
            

            Assert.Equal(si,dArray.Size);


        }

    }

}
