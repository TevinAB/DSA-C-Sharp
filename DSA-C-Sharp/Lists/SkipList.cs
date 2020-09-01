using System;
using System.Collections.Generic;

namespace DSA_C_Sharp.Lists {

    public class SkipNode<T> : IComparable<SkipNode<T>> where T : IComparable<T> {
        T data;
        public SkipNode(T data) {
            this.data = data;
            Next = null;
            Down = null;
            Up = null;
        }

        public T Data {
            get => data;
        }

        public SkipNode<T> Next { get; set; }

        public SkipNode<T> Up { get; set; }

        public SkipNode<T> Down { get; set; }

        public int CompareTo(SkipNode<T> other) {
            if (other == null)
                return -2;

            return data.CompareTo(other.data);
        }
    }

    public class SkipList<T> where T : IComparable<T> {
        public SkipList() {
            Levels = null;
            Tail = null;
            Randomizer = new Random();
            MaxLevels = 32;
        }

        public SkipNode<T> Levels { get; set; }

        public SkipNode<T> Tail { get; set; }

        public Random Randomizer { get; set; }

        public int MaxLevels { get; }

        public int CurrentMaxLevel { get; set; }

        /// <summary>
        /// Inserts a new node in an ordered position in the list.
        /// </summary>
        /// <param name="data"></param>
        public void Insert(T data) {
            SkipNode<T> node = new SkipNode<T>(data);

            //The first entry in the Skip list.
            if (Levels == null) {
                Levels = new SkipNode<T>(default);
                Levels.Next = node;
                Tail = Levels;

                int count = 0;
                while(Randomizer.Next(1, 3) != 2 && count < MaxLevels) {
                    count++;
                }

                InitLevels(count);

                var current = Levels.Up;
                while (current != null) {
                    OrderedInsert(current, node);
                    current = current.Up;
                }
            } 
            else {
                var current = GetNode(node);

                if (current != null) {
                    node.Next = current.Next;
                    current.Next = node;

                    // Determine how many layers to promote this newly added node.
                    int count = 0;
                    while (Randomizer.Next(1, 3) != 2 && count < MaxLevels) {
                        count++;
                    }

                    // If more levels are needed.
                    if (count > CurrentMaxLevel) {
                        int diff = count - CurrentMaxLevel;
                        InitLevels(diff);
                    }

                    // Add copies of the node to upper levels.
                    var currentLevel = Levels.Up;
                    while (count > 0 && currentLevel != null) {
                        OrderedInsert(currentLevel, node);

                        currentLevel = currentLevel.Up;
                        count--;
                    }
                }
            }
        }

        /// <summary>
        /// Inserts a node in the given level, in a sorted order.
        /// </summary>
        /// <param name="level"></param>
        /// <param name="original"></param>
        /// <param name="data"></param>
        private void OrderedInsert(SkipNode<T> level, SkipNode<T> original) {
            SkipNode<T> cpyNode = new SkipNode<T>(original.Data);
            var current = level;
            int result;

            while (current.Next != null) {
                result = current.Next.CompareTo(cpyNode);
                if (result == -1 || result != 0) {
                    current = current.Next;
                } else {
                    break;
                }
            }

            cpyNode.Next = current.Next;

            //Connect the new 'copy node' at the top of its original up traversal list.
            var cOrigin = original; //Start at the orginial for this node, which is at the lowest layer.
            while (cOrigin.Up != null) {
                cOrigin = cOrigin.Up;
            }
            cpyNode.Down = cOrigin;
            cOrigin.Up = cpyNode;

            current.Next = cpyNode;
        }

        /// <summary>
        /// Called only when the list has no entry and initialize levels based on the count value.
        /// </summary>
        /// <param name="count"></param>
        private void InitLevels(int count) {
            while (count > 0) {
                SkipNode<T> newLevel = new SkipNode<T>(default);

                Tail.Up = newLevel;
                newLevel.Down = Tail;
                Tail = newLevel;

                CurrentMaxLevel++;

                count--;
            }
        }

        /// <summary>
        /// Returns the node that precedes a give value.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private SkipNode<T> GetNode(SkipNode<T> node) {
            var current = Tail;

            while (current.Down != null) {
                int result;
                if (current.Next != null) {
                    result = current.Next.CompareTo(node);

                    //The current.next object precedes node or if its at the same place in sort order.
                    if (result == -1 || result == 0) {
                        current = current.Next; // Move to the next node.
                    } else
                    //The current.next object follows node.
                    if (result == 1) {
                        current = current.Down; // Changes level by moving down.
                    }
                } else {
                    current = current.Down;
                }
            }

            //Currently at the lowest layer.
            if (current.Down == null) {
                while (current.Next != null) {
                    int result = current.Next.CompareTo(node);

                    if(result != 1) {
                        current = current.Next;
                    } else {
                        break;
                    }
                }
            }
            return current;
        }

        /// <summary>
        /// If the list contains a given value.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Contains(T key) {
            SkipNode<T> node = new SkipNode<T>(key);
            var current = Tail;

            while (current.Down != null) {
                int result;
                if (current.Next != null) {
                    result = current.Next.CompareTo(node);

                    if (result == -1) {
                        current = current.Next;
                    } else
                    if (result == 1) {
                        current = current.Down;
                    } else 
                    if (result == 0) {
                        return true;
                    }

                } else {
                    current = current.Down;
                }
            }

            //Currently at the lowest layer.
            if (current.Down == null) {
                while (current.Next != null) {
                    int result = current.Next.CompareTo(node);

                    if (result == 0) {
                        return true;
                    } else 
                    if(result == 1){
                        return false;
                    } else {
                        current = current.Next;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Delete the node that has the given key value.
        /// </summary>
        /// <param name="key"></param>
        public void Delete(T key) {

        }

        public void ToList(ref List<T> list) {

        }

    }
}
