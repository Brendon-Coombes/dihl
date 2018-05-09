using Xunit;

namespace DIHL.Client.Core.Tests
{
    public class ExampleTest
    {
        [Fact]
        public void ExamplePassingTest()
        {
            Assert.Equal(4, Add(2, 2));
        }

        private int Add(int x, int y)
        {
            return x + y;
        }
    }
}
