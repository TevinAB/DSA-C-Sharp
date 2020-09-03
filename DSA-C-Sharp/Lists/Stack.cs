using System;

namespace DSA_C_Sharp.Lists {

    public class Stack<T> {
        Node<T> head;

        /// <summary>
        /// Returns the number of items currently in the stack.
        /// </summary>
        public int Count { get; set; }

        public Stack() {
            head = null;
        }

        public bool IsEmpty() {
            return head == null;
        }

        /// <summary>
        /// Pushes an item onto the stack.
        /// </summary>
        /// <param name="data"></param>
        public void Push(T data) {
            Node<T> node = new Node<T>(data);

            if (head == null) {
                head = node;
            } else {
                node.Next = head;
                head = node;
            }
            Count++;
        }

        /// <summary>
        /// Removes the last item that was entered.
        /// </summary>
        /// <returns></returns>
        public T Pop() {
            if (IsEmpty())
                throw new Exception("The stack is empty.");

            T result = head.Data;
            head = head.Next;
            Count--;
            return result;
        }

        /// <summary>
        /// View the item at the top of the stack.
        /// </summary>
        /// <returns></returns>
        public T Peek() {
            if(IsEmpty())
                throw new Exception("The stack is empty.");

            return head.Data;
        }
    }
}
