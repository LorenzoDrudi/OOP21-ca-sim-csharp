using System;
using NUnit.Framework;
using Sanzani;

namespace SanzaniTest;

public class BaseBuilderTest
{
    private const String NullValue = "Null value error.";
    private const String PredicateFail = "Predicate failed.";

    [Test]
    public void TestCheckNonNullValue()
    {
        var value = 42;
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
        var positiveValue = 42;
        var negativeValue = -1;
        var builder = new BaseBuilder();

        bool CheckNonNegative(int x) => x >= 0;

        Assert.AreEqual(positiveValue, builder.CheckValue(positiveValue, CheckNonNegative, PredicateFail));
        Assert.That(
            () => builder.CheckValue(negativeValue, (Predicate<int>)CheckNonNegative, PredicateFail),
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
        Assert.DoesNotThrow(() => testInstance.testFunc());
        Assert.That(() => testInstance.testFunc(),
            Throws.Exception
                .TypeOf<InvalidOperationException>()
                .With
                .Property("Message")
                .EqualTo("testFunc has been called twice."));
    }

    class TestRegisterCallClass
    {
        private readonly BaseBuilder _base = new BaseBuilder();

        public void testFunc() => this._base.RegisterCall();
    }
}