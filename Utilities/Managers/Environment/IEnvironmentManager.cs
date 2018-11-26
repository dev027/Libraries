namespace Utilities.Managers.Environment
{
    public interface IEnvironmentManager
    {
        /// <summary>
        /// Name of this server
        /// </summary>
        string MachineName { get; }

        /// <summary>
        /// True if compiled in DEBUG mode
        /// </summary>
        bool IsDebugBuild { get; }

        /// <summary>
        /// Alternative constructor to be used by dependency injection
        /// </summary>
        /// <returns></returns>
        IEnvironmentManager Init();
    }
}