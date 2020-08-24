using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_C_Sharp.Lists {

    class DynamicArray<T> : IEnumerable {
        private int _length; // The size presented to the user.
        private T[] _array;

        public DynamicArray(int capacity) {
            if (capacity < 0) throw new ArgumentException("Capacity must be greater than zero.");
            Size = capacity;
            _length = 0;
        }

        public DynamicArray() {
            Size = 6;
            Length = 0;
        }

        public int Length {
            get => _length;
            private set => _length += value;
        }

        private int Size { get; set; }

        public T this[int index] {
            get {
                if (index > -1 && index < Size) {
                    return _array[index];
                }
                throw new IndexOutOfRangeException();
            }
            set {
                if (index > Size || index < 0) {
                    throw new IndexOutOfRangeException("Index is not valid.");
                } else {
                    InsertAt(index, value);
                }
                
            }
            
        }

        /// <summary>
        /// Checks if the Array is empty.
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty() {
            return Length <= 0;
        }

        /// <summary>
        /// Clears the array.
        /// </summary>
        public void Clear() {
            if (Size > 0) {
                Array.Clear(_array, 0, Length);
                Length = 0;
            }
        }

        /// <summary>
        /// Increases the capacity to twice its current size.
        /// </summary>
        private void IncreaseCapacity() {
            Size *= 2;
            Array.Resize(ref _array, Size);
        }

        /// <summary>
        /// Inserts a given value to the end of the list.
        /// </summary>
        /// <param name="value"> The value to insert.</param>
        public void Insert(T value) {

            if (Length < Size) {
                _array[Length] = value;
                Length++;
            } else {
                IncreaseCapacity();
                _array[Length] = value;
                Length++;
            }

        }


        /// <summary>
        /// Insert a value at a specific position.
        /// </summary>
        /// <param name="index"> The position to insert at.</param>
        /// <param name="value"> The value to insert.</param>
        public void InsertAt(int index, T value) {

            if (Length == Size) {
                IncreaseCapacity();
            }

            if (index < Length) {
                Array.Copy(_array, index, _array, index + 1, (Length - index));
                _array[index] = value;
                Length++;
            }

        }

        
        /// <summary>
        /// Removes the value at the front of the list.
        /// </summary>
        public void RemoveLast() {
            if (Length > 0) {
                _array[Length-1] = default;
                Length--;
            }
        }

        /// <summary>
        /// Removes the value at a specific index.
        /// </summary>
        /// <param name="index"> The index number to remove from.</param>
        public void RemoveAt(int index) {

            if (index > -1 && index < Length) {
                Length--;

                if (index < Length) {
                    Array.Copy(_array, index + 1, _array, index, (Length - index));
                }

                _array[Length] = default;
                
            } else {
                throw new IndexOutOfRangeException();
            }

        }


        public IEnumerator GetEnumerator() {
            foreach (T item in _array) {
                if (item != null) {
                    yield return item;
                }
            }
        }
    }

}
