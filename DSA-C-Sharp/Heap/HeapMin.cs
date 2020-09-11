using DSA_C_Sharp.Lists;
using System;

namespace DSA_C_Sharp.Heap {
    public class HeapMin<T> where T: IComparable<T> {

        DynamicArray<T> collection;
        public int Count { get; set; }

        public HeapMin(int capacity) {
            if (capacity < 0)
                throw new ArgumentException("Capacity must be greater than zero");

            collection = new DynamicArray<T>(20);
        }


        private bool HasLeft(int index) {
            return 2 * index + 1 < collection.Length-1;
        }

        private bool HasRight(int index) {
            return 2 * index + 2 < collection.Length-1;
        }

        private bool HasParent(int index) {

        }

        private int GetLeft(int index) {

        }

        private int GetRight(int index) {

        }

        private int GetParent(int index) {

        }



    }
}
