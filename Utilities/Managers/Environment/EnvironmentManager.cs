namespace Utilities.Managers.Environment
{
    public class EnvironmentManager : IEnvironmentManager
    {
        /// <inheritdoc />
        public virtual string MachineName => System.Environment.MachineName;

        /// <inheritdoc />
        public bool IsDebugBuild =>
#if DEBUG
            true;

#else
            false;
#endif

        /// <inheritdoc />
        public IEnvironmentManager Init()
        {
            return this;
        }
    }
}