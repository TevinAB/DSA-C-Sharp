using System;
using System.Runtime.InteropServices;

namespace DSA_C_Sharp.Lists {

    public class Node<T> {
        T data;
        Node<T> next;

        public Node(T data) {
            this.data = data;
            this.next = null;
        }

        public Node(): this (default, null) { }

        public T Data {
            get => data;
            set => data;
        }

        public Node Next {
            get => next;
            set => next = value;
        }


        public class LinkedList<T> {

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


            public Node First {
                get => head;
            }

            public Node Last {
                get => tail;
            }


            /// <summary>
            /// Creates node using the data and add it to the end of the list.
            /// </summary>
            /// <param name="data"></param>
            public void Append(T data) {

                Node<T> node = new Node<T>(data, null);

                if (IsEmpty()) {
                    head = node;
                    tail = head;
                } else {
                    tail.next = node;
                    tail = node;
                }

                Count++;

            }

            /// <summary>
            /// Prepends some data at the front of the list.
            /// </summary>
            /// <param name="data"></param>
            public void Prepend(T data) {
                Node<T> node = new Node<T>(data, null);

                if (!IsEmpty()) {
                    node.next = head;
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

                if (!IsEmpty() && (index > 0 && index < Count) ) {
                    Node<T> node = new Node<T>(data, null);
                    Node<T> current = head;

                    int i = 0;
                    while (current.next != null && i < index) {
                        current = current.next;
                        i++;
                    }

                    if (current.next != null && i == (index-1)) {
                        node.next = current.next;
                        current.next = node;
                    }

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
                    head = head.next;
                    Count--;
                } else 
                //Remove from the tail
                if (index >= Count -1) {
                    Node<T> current = head;

                    int i = 0;
                    while (i < Count - 1) {
                        current = current.next;
                        i++;
                    }

                    current.next = null;
                    tail = current;
                    Count--;


                } else {
                    //Remove from the head.
                    Node<T> current = head;
                    int i = 0;
                    while (i < index) {
                        current = current.next;
                        i++;
                    }
                    current.next = current.next.next;

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
                    return default(T);
                }

                //Between the head(inclusive) and tail nodes.
                if (index > -1 && index < Count-2) {
                    int i = 0;
                    Node<T> current = head;
                    while(i != index) {
                        current = current.next;
                        i++;
                    }

                    return current.data;


                }else if (index == Count-1) {
                    return tail.data;
                }
                else {
                    throw new IndexOutOfRangeException();
                }

            }


        }




    }




}
