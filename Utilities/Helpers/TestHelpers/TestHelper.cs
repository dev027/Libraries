namespace Utilities.Helpers.TestHelpers
{
    /// <summary>
    /// Test Helper that  indicates that we should be using a disk-based database 
    /// </summary>
    public class TestHelper : ITestHelper
    {
        public bool UseInMemoryTestDatabase => TestDatabaseName != null;
        public string TestDatabaseName => null;
    }
}