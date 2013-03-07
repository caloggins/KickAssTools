namespace KickAss.Tools.Specification.UnitTests
{
    using FluentAssertions;
    using KickAss.Specification;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public static class NotSpecificationTests
    {
        [TestClass]
        public class NotSpecificationSpecs
        {
            [TestMethod]
            public void WithAPassingSpecItShouldReturnAFail()
            {
                var specification = new FunctionSpecification<int>(i => i > 0);
                var sut = new NotSpecification<int>(specification);

                var result = sut.IsSatisfiedBy(0);

                result.Should().BeTrue();
            }

            [TestMethod]
            public void WithAFailingSpecItShouldPass()
            {
                var specification = new FunctionSpecification<int>(i => i > 0);
                var sut = new NotSpecification<int>(specification);

                var result = sut.IsSatisfiedBy(1);

                result.Should().BeFalse();
            }
        }

        [TestClass]
        public class NotExtensionMethodsTests
        {
            [TestMethod]
            public void ItShouldReturnTheCorrectSpecification()
            {
                var specification = new FunctionSpecification<int>(i => i > 0);

                specification.Not().IsSatisfiedBy(1).Should().BeFalse();
            }
        }
    }
}