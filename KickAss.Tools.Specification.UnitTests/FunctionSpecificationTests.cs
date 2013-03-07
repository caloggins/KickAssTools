namespace KickAss.Tools.Specification.UnitTests
{
    using FluentAssertions;
    using KickAss.Specification;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TestingBits;

    public static class FunctionSpecificationTests
    {
        public class FunctionSpecificationContext : ContextSpecification
        {
            protected FunctionSpecification<int> Sut;

            protected override void Context()
            {
                base.Context();


                Sut = new FunctionSpecification<int>(i => i < 0);
            }
        }

        [TestClass]
        public class WhenAPassingCaseIsGiven : FunctionSpecificationContext
        {
            private bool result;

            protected override void BecauseOf()
            {
                result = Sut.IsSatisfiedBy(-1);
            }

            [TestMethod]
            public void ItShouldReturnTrue()
            {
                result.Should().BeTrue();
            }
        }

        [TestClass]
        public class WhenAFailingCaseIsGiven : FunctionSpecificationContext
        {
            private bool result;

            protected override void BecauseOf()
            {
                result = Sut.IsSatisfiedBy(1);
            }

            [TestMethod]
            public void ItShouldReturnTrue()
            {
                result.Should().BeFalse();
            }
        }
    }
}