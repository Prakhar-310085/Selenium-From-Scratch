namespace Selenium_Learning
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            TestContext.Progress.WriteLine("This is Setup Method");
        }

        [Test]
        public void Test1()
        {
            TestContext.Progress.WriteLine("This is Test1 Method");
        }
        [Test]
        public void Test2()
        {
            TestContext.Progress.WriteLine("This is Test2 Method");
        }
        [TearDown]
        public void CloseBrowser()
        {
            TestContext.Progress.WriteLine("This is Close Browser method");
        }
    }
}