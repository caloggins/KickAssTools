namespace KickAss.Tools.Specification.UnitTests
{
    using FluentAssertions;
    using KickAss.Specification;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public static class OrSpecificationTests
    {
        [TestClass]
        public class OrSpecificationSpecs 
        {
            [TestMethod]
            public void PassessWithTwoPassingSpecifications()
            {
                var passingSpec = new FunctionSpecification<int>(i => i > 0);
                const int testNumber = 1;
                var sut = new OrSpecification<int>(passingSpec, passingSpec);

                var result = sut.IsSatisfiedBy(testNumber);

                result.Should().BeTrue();
            }

            [TestMethod]
            public void PassesWithOnePassingSpecifications()
            {
                const int testNumber = 1;
                var passingSpec = new FunctionSpecification<int>(i => i > 0);
                var failingSpec = new FunctionSpecification<int>(i => i < 0);
                var sut = new OrSpecification<int>(passingSpec, failingSpec);

                var result = sut.IsSatisfiedBy(testNumber);

                result.Should().BeTrue();
            }

            [TestMethod]
            public void FailsTwoFailingSpecifications()
            {
                const int testNumber = 1;
                var failingSpec = new FunctionSpecification<int>(i => i < 0);
                var sut = new OrSpecification<int>(failingSpec, failingSpec);

                var result = sut.IsSatisfiedBy(testNumber);

                result.Should().BeFalse();
            }

            [TestMethod]
            public void StaticMethodShouldReturnTheCorrectSpecification()
            {
                var passing = new FunctionSpecification<int>(i => i > 0);
                var failing = new FunctionSpecification<int>(i => i < 0);

                var sut = passing.Or(failing);

                sut.Should().BeOfType<OrSpecification<int>>();
            }
        }
    }

    [TestClass]
    public class OperatorOverloadTest
    {
        [TestMethod]
        public void PassesWithOnePassingSpec()
        {
            const int testNumber = 1;
            var passingSpec = new FunctionSpecification<int>(i => i > 0);
            var failingSpec = new FunctionSpecification<int>(i => i < 0);

            var result = (passingSpec | failingSpec).IsSatisfiedBy(testNumber);

            result.Should().BeTrue();
        }
    }
}