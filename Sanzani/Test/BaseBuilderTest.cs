using System;
using NUnit.Framework;

namespace Sanzani.Test
{
    [TestFixture]
    public class BaseBuilderTest
    {
        private const string NullValue = "Null value error.";
        private const string PredicateFail = "Predicate failed.";

        [Test]
        public void TestCheckNonNullValue()
        {
            const int value = 42;
            var builder = new BaseBuilder();
            Assert.AreEqual(value, builder.CheckNonNullValue(value, NullValue));
            Assert.That(
                () => builder.CheckNonNullValue<int?>(null, NullValue),
                Throws.Exception
                    .TypeOf<ArgumentException>()
                    .With
                    .Property("Message")
                    .EqualTo(NullValue)
            );
        }

        [Test]
        public void TestCheckValue()
        {
            const int positiveValue = 42;
            const int negativeValue = -1;
            var builder = new BaseBuilder();

            bool CheckNonNegative(int x)
            {
                return x >= 0;
            }

            Assert.AreEqual(positiveValue, builder.CheckValue(positiveValue, CheckNonNegative, PredicateFail));
            Assert.That(
                () => builder.CheckValue(negativeValue, CheckNonNegative, PredicateFail),
                Throws.Exception
                    .TypeOf<ArgumentException>()
                    .With
                    .Property("Message")
                    .EqualTo(PredicateFail)
            );
        }

        [Test]
        public void TestRegisterCall()
        {
            var testInstance = new TestRegisterCallClass();
            Assert.DoesNotThrow(() => testInstance.TestFunc());
            Assert.That(() => testInstance.TestFunc(),
                Throws.Exception
                    .TypeOf<InvalidOperationException>()
                    .With
                    .Property("Message")
                    .EqualTo("TestFunc has been called twice."));
        }

        private class TestRegisterCallClass
        {
            private readonly BaseBuilder _base = new BaseBuilder();

            public void TestFunc()
            {
                _base.RegisterCall();
            }
        }
    }
}
