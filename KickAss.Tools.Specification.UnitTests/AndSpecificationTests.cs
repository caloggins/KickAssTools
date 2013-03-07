namespace KickAss.Tools.Specification.UnitTests
{
    using FluentAssertions;
    using KickAss.Specification;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public static class AndSpecificationTests
    {
        [TestClass]
        public class AndSpecificationSpecs
        {
            [TestMethod]
            public void TwoPassingSpecsShouldPass()
            {
                var sut = new AndSpecification<int>(new FunctionSpecification<int>(i => i > 0), new FunctionSpecification<int>(i => i > 0));

                var result = sut.IsSatisfiedBy(1);

                result.Should().BeTrue();
            }

            [TestMethod]
            public void TwoFailingSpecsShouldFail()
            {
                var sut = new AndSpecification<int>(new FunctionSpecification<int>(i => i > 0), new FunctionSpecification<int>(i => i > 0));

                var result = sut.IsSatisfiedBy(0);

                result.Should().BeFalse();
            }


            [TestMethod]
            public void OnePassingSpecShouldFail()
            {
                var sut = new AndSpecification<int>(new FunctionSpecification<int>(i => i < 0), new FunctionSpecification<int>(i => i > 0));

                var result = sut.IsSatisfiedBy(0);

                result.Should().BeFalse();
            }
        }

        [TestClass]
        public class AndExtensionMethodTests
        {
            [TestMethod]
            public void ItShouldReturnAnAndSpecification()
            {
                var first = new FunctionSpecification<int>(i => i > 0);
                var second = new FunctionSpecification<int>(i => i > 0);

                var result = first.And(second).IsSatisfiedBy(1);

                result.Should().BeTrue();
            }
        }

        [TestClass]
        public class OperatorOverloadSpecs
        {
            [TestMethod]
            public void WithTwoPassingSpecsItShouldPass()
            {
                const int testNumber = 1;
                var passingSpec = new FunctionSpecification<int>(i => i > 0);
                var failingSpec = new FunctionSpecification<int>(i => i > 0);

                var result = (passingSpec & failingSpec).IsSatisfiedBy(testNumber);

                result.Should().BeTrue();
            }

            [TestMethod]
            public void WithTwoFailingSpecsItShouldFail()
            {
                const int testNumber = 0;
                var passingSpec = new FunctionSpecification<int>(i => i > 0);
                var failingSpec = new FunctionSpecification<int>(i => i > 0);

                var result = (passingSpec & failingSpec).IsSatisfiedBy(testNumber);

                result.Should().BeFalse();                
            }
        }
    }
}