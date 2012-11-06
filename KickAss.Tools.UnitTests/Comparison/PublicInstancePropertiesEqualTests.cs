namespace KickAss.Tools.UnitTests.Comparison
{
    using FizzWare.NBuilder;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Tools.Comparison;

    public static class PublicInstancePropertiesEqualTests
    {
        [TestClass]
        public class WhenComparingClassesWithEqualProperties : ContextSpecification
        {
            protected MyTestClass Source;
            protected MyTestClass Target;
            private bool result;

            protected override void Context()
            {
                base.Context();

                Source = Builder<MyTestClass>.CreateNew().Build();
                Target = new MyTestClass
                {
                    Age = Source.Age,
                    Name = Source.Name,
                };
            }

            protected override void BecauseOf()
            {
                result = Source.PublicInstancePropertiesEqual(Target);
            }

            [TestMethod]
            public void ItShouldReturnTrue()
            {
                result.Should().BeTrue();
            }
        }

        [TestClass]
        public class WhenCompairingClassesWithInequalProperties : ContextSpecification
        {
            protected MyTestClass Source;
            protected MyTestClass Target;
            private bool result;

            protected override void Context()
            {
                base.Context();

                Source = Builder<MyTestClass>.CreateNew().Build();
                Target = new MyTestClass();
            }

            protected override void BecauseOf()
            {
                result = Source.PublicInstancePropertiesEqual(Target);
            }

            [TestMethod]
            public void ItShouldReturnFalse()
            {
                result.Should().BeFalse();
            }
        }

        [TestClass]
        public class WhenTheSourceIsNull : ContextSpecification
        {
            protected MyTestClass Source;
            protected MyTestClass Target;
            private bool result;

            protected override void Context()
            {
                base.Context();

                Target = new MyTestClass();
            }

            protected override void BecauseOf()
            {
                result = Source.PublicInstancePropertiesEqual(Target);
            }

            [TestMethod]
            public void ItShouldReturnFalse()
            {
                result.Should().BeFalse();
            }
        }

        [TestClass]
        public class WhenTheTargetIsNull : ContextSpecification
        {
            protected MyTestClass Source;
            protected MyTestClass Target;
            private bool result;

            protected override void Context()
            {
                base.Context();

                Source = new MyTestClass();
            }

            protected override void BecauseOf()
            {
                result = Source.PublicInstancePropertiesEqual(Target);
            }

            [TestMethod]
            public void ItShouldReturnFalse()
            {
                result.Should().BeFalse();
            }
        }

        public class MyTestClass
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
    }
}