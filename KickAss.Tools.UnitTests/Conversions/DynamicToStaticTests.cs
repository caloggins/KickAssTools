namespace KickAss.Tools.UnitTests.Conversions
{
    using System;
    using Microsoft.CSharp.RuntimeBinder;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using FluentAssertions;
    using Tools.Conversions;

    public static class DynamicToStaticTests
    {
        [TestClass]
        public class WhenMappingToAClass
        {
            [TestMethod]
            public void ThePropertiesShouldBeCopied()
            {
                dynamic person = new
                                 {
                                     Name = "Chris",
                                     Age = 42,
                                 };

                TestStaticClass result = DynamicToStatic.ToStatic<TestStaticClass>(person);

                result.ShouldHave().AllPropertiesBut(@class => @class.Birthday).EqualTo(person);
            }
        }

        [TestClass]
        public class WhenTheSourceHasAnExtraProperty
        {
            [TestMethod]
            public void ItShouldThrowAnException()
            {
                dynamic person = new
                {
                    Name = "Chris",
                    Age = 42,
                    Phone = "5551212",
                };

                var result = Capture.Exception(() => DynamicToStatic.ToStatic<TestStaticClass>(person));

                result.Should().BeOfType<RuntimeBinderException>();
            }
        }

        public class TestStaticClass
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public DateTime? Birthday { get; set; }
        }
    }
}