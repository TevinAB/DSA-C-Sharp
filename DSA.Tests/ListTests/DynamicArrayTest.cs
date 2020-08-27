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

            int count = 10000;

            Assert.Equal(count,array.Size);

            array.InsertAt(499, 99999);

            Assert.True(array[499] == 99999, "Insert At test failed.");
        }

        [Fact]
        public void RemoveTest() {
            DynamicArray<int> array = new DynamicArray<int>(10);
            for (int i = 0; i < 2000; i++) {
                array.Insert(i);
            }

            for (int i = 0; i < 500; i++) {
                array.RemoveLast();
            }

            Assert.Equal(2000 - 500, array.Size);


            array.RemoveAt(210);

            Assert.Equal(211,array[210]);
        }
    }
}
