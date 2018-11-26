namespace Utilities.Helpers.TestHelpers
{
    /// <summary>
    /// Test Helper that indicates that we should be using an In-memory database
    /// </summary>
    public class TestHelperInMemoryDatabase : ITestHelper
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="testDatabaseName">Test database name</param>
        public TestHelperInMemoryDatabase(string testDatabaseName)
        {
            TestDatabaseName = testDatabaseName;
        }

        /// <summary>
        /// Flag to indicate that we should  be using an In-memory database
        /// </summary>
        public bool UseInMemoryTestDatabase => true;

        /// <summary>
        /// Test database name
        /// </summary>
        public string TestDatabaseName { get; }
    }
}