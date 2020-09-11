using System;
using System.Collections;


namespace DSA_C_Sharp.Lists {

    public class DynamicArray<T> : IEnumerable {
        public int Length { get; set; } // The size presented to the user.
        private T[] _array;

        public DynamicArray(int capacity) {
            if (capacity < 0) throw new ArgumentException("Capacity must be greater than zero.");
            _array = new T[capacity];
            Length = 0;
        }

        public DynamicArray() {
            _array = new T[6];
            Length = 0;
        }

        public int Size {
            get => Length;
        }

        public T this[int index] {
            get {
                if (index > -1 && index < _array.Length) {
                    return _array[index];
                }
                throw new IndexOutOfRangeException();
            }
            set {
                if (index > _array.Length || index < 0) {
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
            if (_array.Length > 0) {
                Array.Clear(_array, 0, Length);
                Length = 0;
            }
        }

        /// <summary>
        /// Increases the capacity to twice its current size.
        /// </summary>
        private void IncreaseCapacity() {
            try {
                int capacity = _array.Length + 10000;
                Array.Resize(ref _array, capacity);
            } catch (OutOfMemoryException) {

                throw;
            }
        }

        /// <summary>
        /// Inserts a given value to the end of the list.
        /// </summary>
        /// <param name="value"> The value to insert.</param>
        public void Insert(T value) {
            if (Length == _array.Length) {
                IncreaseCapacity();
            }

            _array[Length] = value;
            Length++;
        }

        /// <summary>
        /// Insert a value at a specific position.
        /// </summary>
        /// <param name="index"> The position to insert at.</param>
        /// <param name="value"> The value to insert.</param>
        public void InsertAt(int index, T value) {
            if (Length == _array.Length) {
                IncreaseCapacity();
            }

            if (index < Length) {
                Array.Copy(_array, index, _array, index + 1, (Length - index));
                _array[index] = value;
                Length++;
            } else {
                throw new IndexOutOfRangeException();
            }
        }

        /// <summary>
        /// Removes the value at the front of the list.
        /// </summary>
        public void RemoveLast() {
            if (Length > 0) {
                _array[Length - 1] = default;
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
            for (int i = 0; i < Length; i++) {
                yield return i;
            }
        }
    }

}
