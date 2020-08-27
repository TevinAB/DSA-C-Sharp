using System;

namespace DSA_C_Sharp.Lists {

    internal class DNode<T> {

        public DNode(T data) {
            Data = data;
            Next = null;
            Prev = null;
        }

        public T Data { get; set; }

        public DNode<T> Next { get; set; }

        public DNode<T> Prev { get; set; }

    }

    public class DLinkedList<T> {
        DNode<T> head;
        DNode<T> tail;

        public DLinkedList() {
            head = null;
            tail = null;
        }

        public int Count { get; set; }

        public T this[int index] {
            get => GetAt(index);
            set => SetAt(index, value);
        }

        /// <summary>
        /// Checks if the list is empty.
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty() {
            return head == null;
        }

        /// <summary>
        /// Gets data from the head of the list.
        /// </summary>
        public T First {
            get => !IsEmpty() ? head.Data : throw new Exception("The list is empty.");
        }

        /// <summary>
        /// Gets data from the tail of the list.
        /// </summary>
        public T Last {
            get => !IsEmpty() ? tail.Data : throw new Exception("The list is empty.");
        }

        /// <summary>
        /// Checks if index is in bounds.
        /// </summary>
        /// <param name="index"></param>
        private void BoundsCheck(int index) {
            if (index < 0 || index >= Count || IsEmpty()) {
                throw new IndexOutOfRangeException();
            }
        }

        /// <summary>
        /// Appends a Node in the list.
        /// </summary>
        /// <param name="data"></param>
        public void Append(T data) {
            DNode<T> node = new DNode<T>(data);

            if (IsEmpty()) {
                head = tail = node;
            } else {
                node.Prev = tail;
                tail.Next = node;
                tail = node;
            }
            Count++;
        }

        /// <summary>
        /// Prepends a Node in the list.
        /// </summary>
        /// <param name="data"></param>
        public void Prepend(T data) {
            DNode<T> node = new DNode<T>(data);

            if (IsEmpty()) {
                head = tail = node;
            } else {
                node.Next = head;
                head.Prev = node;
                head = node;
            }
            Count++;
        }

        /// <summary>
        /// Insert a node at a given index.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="data"></param>
        public void InsertAt(int index,T data) {

            BoundsCheck(index);

            if (index == 0) {
                Prepend(data);
            } else if (index == Count-1) {
                Append(data);
            } else {
                DNode<T> node = new DNode<T>(data);
                var current = head;
                int i = 1;

                while (i < index - 1 && current.Next != null) {
                    current = current.Next;
                    i++;
                }

                node.Prev = current;
                node.Next = current.Next;
                current.Next.Prev = node;
                current.Next = node;

                Count++;
            }
        }

        /// <summary>
        /// Removes the node at a given index.
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index) {

            BoundsCheck(index);

            if (index == 0) {
                head = head.Next;
                if (head.Next != null)
                    head.Next.Prev = null;

            } else if (index == Count -1) {
                tail = tail.Prev;
                if (tail != null)
                    tail.Next = null;

            } else {
                DNode<T> current;

                if (index > (Count/2)) {
                    current = tail;

                    for (int i = Count-1; i > index+1; i--) {
                        current = current.Prev;
                    }

                    current.Prev.Prev.Next = current;
                    current.Prev = current.Prev.Prev;
                } else {

                    current = head;
                    for (int i = 0; i < index-1; i++) {
                        current = current.Next;
                    }

                    current.Next.Next.Prev = current;
                    current.Next = current.Next.Next;
                }
            }
            Count--;
        }

        /// <summary>
        /// Clears the list.
        /// </summary>
        public void Clear() {
            head = null;
            tail = null;
            Count = 0;
        }

        /// <summary>
        /// Gets the data at a given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T GetAt(int index) {

            BoundsCheck(index);

            if (index == 0) {
                return head.Data;
            }
            if (index == Count - 1) {
                return tail.Data;
            } else {
                DNode<T> current;

                if (index > (Count/2)) {
                    current = tail;

                    for (int i = Count-1; i > index; i--) {
                        current = current.Prev;
                    }
                } else {
                    current = head;

                    for (int i = 0; i < index; i++) {
                        current = current.Next;
                    }
                }
                return current.Data;
            }
        }

        /// <summary>
        /// Set the the value of a node at a give index.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="data">Value to set to.</param>
        public void SetAt(int index,T data) {

            BoundsCheck(index);

            if (index == 0) {
                head.Data = data;
                return;
            }
            if (index == Count-1) {
                tail.Data = data;
                return;
            } else {
                DNode<T> current;

                if (index > (Count/2)) {
                    current = tail;

                    for (int i = Count-1; i > index; i--) {
                        current = current.Prev;
                    }

                } else {
                    current = head;

                    for (int i = 0; i < index; i++) {
                        current = current.Next;
                    }
                }
                current.Data = data;
            }
        }

    }
}
