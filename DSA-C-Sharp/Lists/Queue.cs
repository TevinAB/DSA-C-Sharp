using System;

namespace DSA_C_Sharp.Lists {
    public class Queue<T> {
        DNode<T> head;
        DNode<T> tail;

        public int Count { get; set; }

        public Queue() {
            head = null;
            tail = null;
            Count = 0;
        }

        /// <summary>
        /// Checks if the queue is empty.
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty() {
            return Count == 0;
        }

        /// <summary>
        /// Adds an item to the queue.
        /// </summary>
        /// <param name="data"></param>
        public void Enqueue(T data) {
            DNode<T> node = new DNode<T>(data);

            if (IsEmpty()) {
                head = tail = node;
            } else {
                tail.Next = node;
                node.Prev = tail;
                tail = node;
            }
            Count++;
        }

        /// <summary>
        /// Removes the item at the front of the queue.
        /// </summary>
        /// <returns></returns>
        public T Dequeue() {
            if (IsEmpty()) {
                throw new Exception("The queue is empty.");
            } else {
                T result = head.Data;
                head.Next.Prev = null;
                head = head.Next;
                Count--;
                return result;
            }
        }
        
        /// <summary>
        /// View the item at the front of the queue without removing it.
        /// </summary>
        /// <returns></returns>
        public T Peek() {
            if (IsEmpty()) {
                throw new Exception("The queue is empty.");
            } else {
                return head.Data;
            }
        }

    }
}
