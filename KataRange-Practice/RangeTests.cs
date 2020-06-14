using NUnit.Framework;

namespace KataRange_Practice
{
    [TestFixture]
    internal sealed class RangeTests
    {
        public const string rangeA = "(4, 9]";
        public const string rangeB = "(3,10)";
        public const string rangeC = "[0,10)";
        public const string rangeD = "[6,10]";

        [SetUp]
        public void Setup()
        {

        }
        [TestCase(rangeA)]
        [TestCase(rangeB)]
        public void ConstructorValid_Tester(string format)
        {
            Assert.That(() => new Range(format), Throws.Nothing);
        }

        [TestCase("Dsads")]
        [TestCase("[1,1)")]
        public void ConstructorInvalid_Tester(string format)
        {
            Assert.That(() => new Range(format), Throws.ArgumentException);
        }

        [TestCase(rangeA, 5, true)]
        [TestCase(rangeA, 4, false)]
        [TestCase(rangeA, 9, true)]
        [TestCase(rangeA, 2, false)]
        public void Contains_Tester(string format, int point, bool expected)
        {
            Assert.That(new Range(format).Contains(point), Is.EqualTo(expected));
        }

        [TestCase(rangeB, 5, false)]
        [TestCase(rangeB, 2, true)]
        [TestCase(rangeB, 9, false)]
        [TestCase(rangeB, 3, true)]
        public void DoesNotContain_Tester(string format, int point, bool expected)
        {
            Assert.That(new Range(format).DoesNotContain(point), Is.EqualTo(expected));
        }

        [TestCase(rangeA, new int[] { 5, 6, 7, 8, 9 })]
        [TestCase(rangeB, new int[] { 4, 5, 6, 7, 8, 9 })]
        [TestCase(rangeC, new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
        [TestCase(rangeD, new int[] { 6, 7, 8, 9, 10 })]
        public void GetAllPoints_Tester(string format, int[] response)
        {
            Assert.That(new Range(format).GetAllPoints(), Is.EqualTo(response));
        }

        [TestCase(rangeA, "(5,7)", true)]
        [TestCase(rangeA, "[5,9)", true)]
        [TestCase(rangeA, "[3,5)", false)]
        [TestCase(rangeA, "[4,9]", false)]
        public void ContainsRange_Tester(string baseFormat, string compareFormat, bool expected)
        {
            Assert.That(new Range(baseFormat).ContainsRange(new Range(compareFormat)), Is.EqualTo(expected));
        }

        [TestCase(rangeA, "(5,7)", false)]
        [TestCase(rangeA, "[5,9)", false)]
        [TestCase(rangeA, "[3,5)", true)]
        [TestCase(rangeA, "[4,9]", true)]
        public void DoesNotContainRange_Tester(string baseFormat, string compareFormat, bool expected)
        {
            Assert.That(new Range(baseFormat).DoesNotContainRange(new Range(compareFormat)), Is.EqualTo(expected));
        }

        [TestCase(rangeA, new int[] { 5, 9 })]
        [TestCase(rangeB, new int[] { 4, 9 })]
        [TestCase(rangeC, new int[] { 0, 9 })]
        [TestCase(rangeD, new int[] { 6, 10 })]
        public void Endpoints_Tester(string format, int[] response)
        {
            Assert.That(new Range(format).EndPoints(), Is.EqualTo(response));
        }

        [TestCase(rangeA, "[4,7)", true)]
        [TestCase(rangeA, "[5,12]", true)]
        [TestCase(rangeA, "[1,4)", false)]
        [TestCase(rangeA, "[12,15]", false)]
        public void OverlapsRange_Tester(string baseFormat, string compareFormat, bool expected)
        {
            Assert.That(new Range(baseFormat).OverlapsRange(new Range(compareFormat)), Is.EqualTo(expected));

        }

        [TestCase(rangeA, "[4,7)", false)]
        [TestCase(rangeA, "[5,12]", false)]
        [TestCase(rangeA, "[1,4)", true)]
        [TestCase(rangeA, "[12,15]", true)]
        public void DoesNotOverlapRange_Tester(string baseFormat, string compareFormat, bool expected)
        {
            Assert.That(new Range(baseFormat).DoesNotOverlapRange(new Range(compareFormat)), Is.EqualTo(expected));

        }

        [TestCase(rangeA, "(4,9]", true)]
        [TestCase(rangeB, "[4,9]", true)]
        [TestCase(rangeA, "(1,9]", false)]
        [TestCase(rangeB, "[12,15]", false)]
        public void Equals_Tester(string baseFormat, string compareFormat, bool expected)
        {
            Assert.That(new Range(baseFormat).Equals(new Range(compareFormat)), Is.EqualTo(expected));
        }

        [TestCase(rangeA, "(4,9]", false)]
        [TestCase(rangeB, "[4,9]", false)]
        [TestCase(rangeA, "(1,9]", true)]
        [TestCase(rangeB, "[12,15]", true)]
        public void NotEquals_Tester(string baseFormat, string compareFormat, bool expected)
        {
            Assert.That(new Range(baseFormat).NotEquals(new Range(compareFormat)), Is.EqualTo(expected));
        }


    }
}
