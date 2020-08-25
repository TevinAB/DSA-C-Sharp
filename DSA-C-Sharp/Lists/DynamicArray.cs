using System;
using System.Collections;



namespace DSA_C_Sharp.Lists {

    public class DynamicArray<T> : IEnumerable {
        private int _length { get; set; } // The size presented to the user.
        private T[] _array;

        public DynamicArray(int capacity) {
            if (capacity < 0) throw new ArgumentException("Capacity must be greater than zero.");
            _array = new T[capacity];
            _length = 0;
        }

        public DynamicArray() {
            _array = new T[6];
            _length = 0;
        }


        public int Size {
            get => _length;
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
            return _length <= 0;
        }

        /// <summary>
        /// Clears the array.
        /// </summary>
        public void Clear() {
            if (_array.Length > 0) {
                Array.Clear(_array, 0, _length);
                _length = 0;
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

            if (_length == _array.Length) {
                IncreaseCapacity();
            }

            _array[_length] = value;
            _length++;
        }


        /// <summary>
        /// Insert a value at a specific position.
        /// </summary>
        /// <param name="index"> The position to insert at.</param>
        /// <param name="value"> The value to insert.</param>
        public void InsertAt(int index, T value) {

            if (_length == _array.Length) {
                IncreaseCapacity();
            }

            if (index < _length) {
                Array.Copy(_array, index, _array, index + 1, (_length - index));
                _array[index] = value;
                _length++;
            }

        }

        
        /// <summary>
        /// Removes the value at the front of the list.
        /// </summary>
        public void RemoveLast() {
            if (_length > 0) {
                _array[_length - 1] = default;
                _length--;
            }
        }

        /// <summary>
        /// Removes the value at a specific index.
        /// </summary>
        /// <param name="index"> The index number to remove from.</param>
        public void RemoveAt(int index) {

            if (index > -1 && index < _length) {
                _length--;

                if (index < _length) {
                    Array.Copy(_array, index + 1, _array, index, (_length - index));
                }

                _array[_length] = default;
                
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
