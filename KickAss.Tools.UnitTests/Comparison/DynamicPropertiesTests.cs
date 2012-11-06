namespace KickAss.Tools.UnitTests.Comparison
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Tools.Comparison;

    // ReSharper disable InconsistentNaming
    public static class DynamicPropertiesTests
    {
        [TestClass]
        public class WhenComparingObjectsWithEqualProperties
        {
            [TestMethod]
            public void AreEqual_ShouldReturnTrue()
            {
                var source = new {Name = "Chris"};
                var target = new {Name = "Chris"};

                var result = DynamicProperties.AreEqual(source, target);

                result.Should().BeTrue();
            }
        }

        [TestClass]
        public class WhenComparingObjectsWithInequalProperties
        {
            [TestMethod]
            public void AreEqual_ShouldReturnFalse()
            {
                var source = new { Name = "Chris" };
                var target = new { Name = "John" };

                var result = DynamicProperties.AreEqual(source, target);

                result.Should().BeFalse();
            }
        }
    }
}