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

        /// <summary>
        /// Checks if a given index has a left child node.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private bool HasLeft(int index) {
            return GetLeft(index) < collection.Length-1;
        }

        /// <summary>
        /// Checks if a given index has a right child node.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private bool HasRight(int index) {
            return GetRight(index) < collection.Length-1;
        }

        /// <summary>
        /// Checks if a given node has a parent node.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private bool HasParent(int index) {
            return GetParent(index) > 0;
        }

        /// <summary>
        /// Returns the index to the left node of a given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private int GetLeft(int index) {
            return 2 * index + 1;
        }

        /// <summary>
        /// Returns the index to the right node of a given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private int GetRight(int index) {
            return 2 * index + 2;
        }

        /// <summary>
        /// Returns the index to the parent node of a given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private int GetParent(int index) {
            return index - 1 / 2;
        }

        private void SiftUp() {
            int index = collection.Length - 1;

            while (HasParent(index)) {
                int parent = GetParent(index);
                if (collection[parent].CompareTo(collection[index]) == 1) {
                    T temp = collection[parent];
                    collection[parent] = collection[index];
                    collection[index] = temp;

                    index = parent;
                    continue;
                }
                break;
            }
        }

        /// <summary>
        /// Adds some data to the heap.
        /// </summary>
        /// <param name="data"></param>
        public void Insert(T data) {
            collection.Insert(data);
            SiftUp();
        }

        /// <summary>
        /// View the value at the top of the heap
        /// </summary>
        /// <returns></returns>
        public T Peek() {
            if (collection.Length > 0) {
                return collection[0];
            }
            throw new Exception("The heap is currently empty.");
        }



    }
}
