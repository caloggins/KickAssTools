namespace KickAss.Tools.UnitTests.Injection
{
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TestingBits;

    public static class WindsorServiceLocatorTests
    {
        public class ServiceLocatorContext : ContextSpecification
        {
            protected WindsorServiceLocator Sut;
            protected IWindsorContainer Container;

            protected override void Context()
            {
                base.Context();

                Container = new WindsorContainer();
                Sut = new WindsorServiceLocator(Container);
            }
        }

        [TestClass]
        public class WhenThereAreRegistrationsInTheContainer : ServiceLocatorContext
        {
            protected override void Context()
            {
                base.Context();

                Container.Register(
                    Component.For<IContract>().ImplementedBy<Provider>()
                    );
            }

            [TestMethod]
            public void ItShouldReturnAnInstanceOfARegisteredObject()
            {
                Sut.GetInstance(typeof (IContract)).Should().BeOfType<Provider>();
            }

            [TestMethod]
            public void ItShouldReturnAllInstances()
            {
                Sut.GetAllInstances(typeof (IContract)).Should()
                    .OnlyContain(o => o.GetType() == typeof (Provider))
                    .And.HaveCount(1);
            }
        }

        internal interface IContract
        {
             
        }

        internal class Provider : IContract
        {
            
        }
    }
}