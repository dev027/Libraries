namespace Utilities.Helpers.TestHelpers
{
    public interface ITestHelper
    {
        /// <summary>
        /// True if In-memory database is to be used
        /// </summary>
        bool UseInMemoryTestDatabase { get; }

        /// <summary>
        /// Name of the In-memory database
        /// </summary>
        string TestDatabaseName { get; }
    }
}