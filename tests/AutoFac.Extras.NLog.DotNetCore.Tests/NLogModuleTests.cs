using Autofac;
using AutoFac.Extras.NLog.DotNetCore;
using Xunit;

namespace AutoFac.Extras.NLog.DotNetCore.Tests
{
    public class NLogModuleTests
    {
        private IContainer _container;

        public NLogModuleTests()
        {
            BuildSampleContainer();
        }

        private void BuildSampleContainer()
        {
            ContainerBuilder containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<NLogModule>();
            containerBuilder.RegisterType<SampleClassWithConstructorDependency>().Named<ISampleClass>("constructor");
            containerBuilder.RegisterType<SampleClassWithPropertyDependency>().Named<ISampleClass>("property");
            _container = containerBuilder.Build();
        }

        [Fact]
        public void Inject_Logger_To_Constructor_Test()
        {
            ISampleClass sampleClass = _container.ResolveNamed<ISampleClass>("constructor");

            Assert.NotNull(sampleClass.GetLogger());
        }

        [Fact]
        public void Inject_Logger_To_Property_Test()
        {
            ISampleClass sampleClass = _container.ResolveNamed<ISampleClass>("property");

            Assert.NotNull(sampleClass.GetLogger());
        }
    }
}
