using DSA_C_Sharp.Lists;
using System;

namespace DSA_C_Sharp.Heap {
    public class HeapMin<T> where T: IComparable<T> {

        DynamicArray<T> collection;
        public int Count { get=> collection.Length;}

        public bool IsEmpty {
            get => collection.IsEmpty();
        }

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

        private void SiftDown() {
            int index = 0;

            while (HasLeft(index) || HasRight(index)) {
                int originalIndex = index;
                int left = GetLeft(index);
                int right = GetRight(index);

                //If the new root node is greater than the left child node
                if (HasLeft(originalIndex) && collection[index].CompareTo(collection[left]) == 1)
                    index = left;

                //If the right node is smaller than the current index
                if (HasRight(originalIndex) && collection[index].CompareTo(collection[right]) == 1)
                    index = right;

                if (index != originalIndex) {
                    T temp = collection[originalIndex];
                    collection[originalIndex] = collection[index];
                    collection[index] = temp;
                }
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

        /// <summary>
        /// Returns the root node.
        /// </summary>
        /// <returns></returns>
        public T Pop() {
            if (collection.Length < 0)
                throw new Exception("No root node found. The heap is empty.");

            T result = collection[0];
            collection[0] = collection[collection.Length - 1];
            collection.RemoveLast();
            SiftDown();

            return result;
        }

        /// <summary>
        /// Remove all elements from the heap.
        /// </summary>
        public void Clear() {
            if (collection.IsEmpty())
                throw new Exception("Heap is empty.");

            collection.Clear();
        }

    }
}
