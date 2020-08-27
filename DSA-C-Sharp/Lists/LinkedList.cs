using System;
using System.Collections;
using System.Collections.Generic;

namespace DSA_C_Sharp.Lists {

    internal class Node<T> {
        T data;
        Node<T> next;

        public Node(T data) {
            this.data = data;
            next = null;
        }

        public Node() : this(default) { }

        public T Data {
            get => data;
            set => data = value;
        }

        public Node<T> Next {
            get => next;
            set => next = value;
        }

    }

    public class LinkedList<T> : IEnumerable {
        Node<T> head;
        Node<T> tail;

        public int Count { get; set; }

        public LinkedList() {
            head = null;
            tail = null;
        }

        public bool IsEmpty() {
            return head == null;
        }

        /// <summary>
        /// Returns the data stored in the first element.
        /// </summary>
        public T First {
            get => head.Data == null ? default : head.Data;
        }

        /// <summary>
        /// Returns the data stored in the last element.
        /// </summary>
        public T Last {
            get => tail.Data == null ? default : tail.Data;
        }

        /// <summary>
        /// Creates node using the data and add it to the end of the list.
        /// </summary>
        /// <param name="data"></param>
        public void Append(T data) {
            Node<T> node = new Node<T>(data);

            if (IsEmpty()) {
                head = node;
                tail = head;
            } else {
                tail.Next = node;
                tail = node;
            }
            Count++;
        }

        /// <summary>
        /// Prepends some data at the front of the list.
        /// </summary>
        /// <param name="data"></param>
        public void Prepend(T data) {
            Node<T> node = new Node<T>(data);

            if (!IsEmpty()) {
                node.Next = head;
            } else {
                tail = node;
            }

            head = node;
            Count++;
        }

        /// <summary>
        /// Inserts a node at a specific index.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="data"></param>
        public void InsertAt(int index, T data) {
            if (index > 0 && index < Count) {
                Node<T> node = new Node<T>(data);
                Node<T> current = head;

                int i = 1;
                while (i < index-1) {
                    current = current.Next;
                    i++;
                }

                node.Next = current.Next;
                current.Next = node;

                Count++;

            } else if (index <= 0) {
                Prepend(data);
            } else {
                Append(data);
            }
        }

        /// <summary>
        /// Removes a node from a specific position.
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index) {
            //Remove from head.
            if (index == 0) {
                head = head.Next;
                Count--;
            } 
            else if (index >= Count - 1) {
                //Remove from the tail
                Node<T> current = head;

                int i = 0;
                while (i < Count - 1) {
                    current = current.Next;
                    i++;
                }

                current.Next = null;
                tail = current;
                Count--;
            } 
            else {
                //Remove elsewhere(in between head and tail).
                Node<T> current = head;
                int i = 0;

                while (i < index-1) {
                    current = current.Next;
                    i++;
                }
                current.Next = current.Next.Next;
            }
        }

        /// <summary>
        /// Clears the List.
        /// </summary>
        public void Clear() {
            head = null;
            tail = null;
            Count = 0;
        }

        /// <summary>
        /// Get the data at the given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T GetAt(int index) {
            if (IsEmpty()) {
                return default;
            }

            //Between the head(inclusive) and tail nodes.
            if (index > -1 && index <= Count - 2) {
                int i = 0;
                Node<T> current = head;
                while (i != index) {
                    current = current.Next;
                    i++;
                }

                return current.Data;

            } else if (index == (Count - 1)) {
                return tail.Data;
            } else {
                throw new IndexOutOfRangeException();
            }
        }

        public IEnumerator GetEnumerator() {
            return new ListEnumertator(this);
        }

        internal class ListEnumertator : IEnumerator<T> {
            Node<T> head_;
            LinkedList<T> list;

            public ListEnumertator(LinkedList<T> collection) {
                list = collection;
                head_ = list.head;
            }

            public T Current {
                get { return head_.Data; }
            }

            object IEnumerator.Current { 
                get { return Current; }
            }

            public void Dispose() {
                list = null;
                head_ = null;
            }

            public bool MoveNext() {
                head_ = head_.Next;
                return head_ == null;
            }

            public void Reset() {
                head_ = list.head;
            }
        }
    }
}
