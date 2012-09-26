namespace KickAss.Tools.UnitTests.Serialization
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Tools.Serialization;

    public static class SerializerTests
    {
        public class SerializerContext : ContextSpecification
        {
            protected Serializer Sut;

            protected override void Context()
            {
                base.Context();

                Sut = new Serializer();
            }
        }

        [TestClass]
        public class WhenTheChildClassIsProvided : SerializerContext
        {
            private ChildClass result;
            public const string SampleXml = @"<?xml version='1.0' encoding='utf-8' ?>
<ChildClass>
	<FirstName>Joe</FirstName>
	<LastName>Baggodonuts</LastName>
</ChildClass>";

            protected override void BecauseOf()
            {
                result = Sut.Deserialize<ChildClass>(SampleXml);
            }

            [TestMethod]
            public void ItShouldDeserializeTheClass()
            {
                result.FirstName.Should().Be("Joe");
                result.LastName.Should().Be("Baggodonuts");
            }
        }

        public class BaseClass
        {
            public string FirstName { get; set; }
        }

        public class ChildClass : BaseClass
        {
            public string LastName { get; set; }
        }
    }
}