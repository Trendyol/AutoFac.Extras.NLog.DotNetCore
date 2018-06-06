using NLog;

namespace AutoFac.Extras.NLog.DotNetCore.Tests
{
    public class SampleClassWithConstructorDependency : ISampleClass
    {
        private readonly ILogger _logger;

        public SampleClassWithConstructorDependency(ILogger logger)
        {
            _logger = logger;
        }

        public void SampleMessage(string message)
        {
            _logger.Debug(message);
        }

        public ILogger GetLogger()
        {
            return _logger;
        }
    }
}