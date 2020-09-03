using DSA_C_Sharp.Lists;
using Xunit;

namespace DSA.Tests.ListTests {
    public class QueueTest {
        [Fact]
        public void EnqueueTest() {
            Queue<int> queue = new Queue<int>();

            queue.Enqueue(2);
            queue.Enqueue(12);
            queue.Enqueue(211);
            queue.Enqueue(55);

            Assert.True(queue.Peek() == 2, "Enqueue test failed.");
        }

        [Fact]
        public void DequeueTest() {
            Queue<int> queue = new Queue<int>();

            queue.Enqueue(2);
            queue.Enqueue(12);
            queue.Enqueue(211);
            queue.Enqueue(55);

            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();

            Assert.True(queue.Peek() == 55, "Dequeue test failed.");
        }

    }
}
