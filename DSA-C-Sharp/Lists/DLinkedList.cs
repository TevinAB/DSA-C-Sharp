using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_C_Sharp.Lists {

    internal class DNode<T> {

        public DNode(T data) {
            Data = data;
            Next = null;
            Prev = null;
        }

        public T Data { get; }

        public DNode<T> Next { get; set; }

        public DNode<T> Prev { get; set; }


    }


    class DLinkedList<T> {
        DNode<T> head;
        DNode<T> tail;

        public DLinkedList() {
            head = null;
            tail = null;
        }

        public int Count { get; set; }

        public bool IsEmpty() {
            return head == null;
        }

        public T First {
            get => head.Data;
        }

        public T Last {
            get => tail.Data;
        }

        public void BoundsCheck(int index) {
            if (index < 0 || index > Count || IsEmpty()) {
                throw new IndexOutOfRangeException();
            }
        }

        public void Append(T data) {
            DNode<T> node = new DNode<T>(data);

            if (IsEmpty()) {
                head = tail = node;
            } else {

                node.Prev = tail;
                tail.Next = node;
            }
            Count++;
        }

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


        public void RemoveAt(int index) {

            BoundsCheck(index);

            if (index == 0) {
                head = head.Next;

            } else if (index == Count -1) {
                tail.Prev.Next = null;
                tail = tail.Prev;

            } else {
                var current = head;
                int i = 1;

                while (i < index - 1 && current.Next != null) {
                    current = current.Next;
                    i++;
                }

                current.Next.Next.Prev = current;
                current.Next = current.Next.Next;

            }

            Count--;
        }


        public void Clear() {
            head = null;
            tail = null;
            Count = 0;
        }


        public T GetAt(int index) {

            BoundsCheck(index);

            if (index == 0) {
                return head.Data;
            } else if (index == Count - 1) {
                return tail.Data;
            } else {
                int i = 0;
                var current = head;

                while (i != index) {
                    current = current.Next;
                    i++;
                }

                return current.Data;

            }


        }




    }
}
