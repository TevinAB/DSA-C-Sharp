using DSA_C_Sharp.Lists;
using Xunit;

namespace DSA.Tests.ListTests {
    public class StackTest {

        [Fact]
        public void PushTest() {
            Stack<int> stack = new Stack<int>();

            stack.Push(4);
            stack.Push(1);
            stack.Push(99);
            stack.Push(0);

            Assert.True(stack.Peek() == 0, "Push test failed.");
        }

        [Fact]
        public void PopTest() {
            Stack<int> stack = new Stack<int>();

            stack.Push(4);
            stack.Push(1);
            stack.Push(99);
            stack.Push(0);

            stack.Pop();
            stack.Pop();

            Assert.True(stack.Peek() == 1, "Pop test failed.");
            Assert.Equal(2, stack.Count);
        }

    }
}
