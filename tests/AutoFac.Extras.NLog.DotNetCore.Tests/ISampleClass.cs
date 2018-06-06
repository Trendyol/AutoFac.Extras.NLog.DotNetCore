using NLog;

namespace AutoFac.Extras.NLog.DotNetCore.Tests
{
    public interface ISampleClass
    {
        void SampleMessage(string message);
        ILogger GetLogger();
    }
}
