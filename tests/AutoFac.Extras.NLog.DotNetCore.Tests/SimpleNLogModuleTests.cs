using Autofac;
using AutoFac.Extras.NLog.DotNetCore;
using Xunit;

namespace AutoFac.Extras.NLog.DotNetCore.Tests
{
    public class SimpleNLogModuleTests
    {
        private IContainer _container;

        public SimpleNLogModuleTests()
        {
            BuildSampleContainer();
        }

        private void BuildSampleContainer()
        {
            ContainerBuilder containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterModule<SimpleNLogModule>();

            containerBuilder
                .RegisterType<SampleClassWithConstructorDependency>()
                .Named<ISampleClass>("constructor");

            containerBuilder
                .RegisterType<SampleClassWithPropertyDependency>()
                .Named<ISampleClass>("property")
                .PropertiesAutowired();

            containerBuilder
                .RegisterType<SampleClassToResolveLoggerFromServiceLocator>()
                .Named<ISampleClass>("serviceLocator");

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

        [Fact]
        public void Resolve_Logger_From_LifetimeScope_Test()
        {
            ISampleClass sampleClass = _container.ResolveNamed<ISampleClass>("serviceLocator");

            Assert.NotNull(sampleClass.GetLogger());
        }
    }
}
