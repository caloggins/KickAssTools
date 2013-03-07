namespace KickAss.Tools.UnitTests.Comparison
{
    using FizzWare.NBuilder;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TestingBits;
    using Tools.Comparison;

    public static class PropertyEqualityTests
    {
        [TestClass]
        public class WhenComparingClassesWithEqualProperties : ContextSpecification
        {
            protected PublicInstancePropertiesEqualTests.MyTestClass Source;
            protected PublicInstancePropertiesEqualTests.MyTestClass Target;

            protected override void Context()
            {
                base.Context();

                Source = Builder<PublicInstancePropertiesEqualTests.MyTestClass>.CreateNew().Build();
                Target = new PublicInstancePropertiesEqualTests.MyTestClass
                {
                    Age = Source.Age,
                    Name = Source.Name,
                };
            }

            [TestMethod]
            public void PublicInstancePropertiesEqual_ShouldReturnTrue()
            {
                Source.PublicInstancePropertiesEqual(Target).Should().BeTrue();
            }

            [TestMethod]
            public void HasPublicPropertiesEqualTo_ShouldReturnTrue()
            {
                Source.HasPublicPropertiesEqualTo(Target).Should().BeTrue();
            }
        }

    }
}