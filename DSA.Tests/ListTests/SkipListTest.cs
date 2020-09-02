using DSA_C_Sharp.Lists;
using Xunit;

namespace DSA.Tests.ListTests {

    public class SkipListTest {

        [Fact]
        public void TestInsert() {
            SkipList<int> list = new SkipList<int>();

            list.Insert(5);
            list.Insert(15);
            list.Insert(27);
            list.Insert(81);
            list.Insert(-1);

            Assert.True(list.Contains(27), "Insert test failed.");

            list.Delete(81);

            Assert.True(!list.Contains(81), "Delete test failed.");

        }

    }
}
