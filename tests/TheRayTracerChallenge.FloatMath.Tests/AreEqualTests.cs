namespace TheRayTracerChallenge.FloatMath.Tests
{
    public class AreEqualTests
    {
        // Tests shamelessly stolen from https://floating-point-gui.de/errors/NearlyEqualsTest.java
        // Big thanks to the original author, because doing this by hand would be a living nightmare.

        // Waiting for a stablre release of XUnit 3 so that I can name those individual tests
        // without writing them as separate methods.

        private const float TestingThreshold = 0.0001f; // Used for most tests, except like 2 or sth

        [Theory]
        // Large Floats
        [InlineData(1000000f, 1000001f, true)]
        [InlineData(10000f, 10001f, false)]
        [InlineData(-1000000f, -1000001f, true)]
        [InlineData(-10000f, -10001f, false)]
        // Floats around 1 and -1
        [InlineData(1.0000001f, 1.0000002f, true)]
        [InlineData(1.0002f, 1.0001f, false)]
        [InlineData(-1.000001f, -1.000002f, true)]
        [InlineData(-1.0002f, -1.0001f, false)]
        // Floats close to 0
        [InlineData(0.000000001000001f, 0.000000001000002f, true)]
        [InlineData(0.000000000001002f, 0.000000000001001f, false)]
        [InlineData(-0.000000001000001f, -0.000000001000002, true)]
        [InlineData(-0.000000000001002f, -0.000000000001001f, false)]
        // Floats close to eachother, but a bit from 0
        [InlineData(0.3f, 0.30000003f, true)]
        [InlineData(-0.3f, -0.30000003f, false)]
        // Comparisons with 0
        [InlineData(0.0f, 0.0f, true)]
        [InlineData(0.00000001f, 0.0f, false)]
        [InlineData(-0.00000001f, 0.0f, false)]
        [InlineData(0.0f, 1e-40f, true, 0.01f)]
        [InlineData(1e-40f, 0.0f, false, 0.000001f)]
        [InlineData(0.0f, -1e-40f, true, 0.01f)]
        [InlineData(-1e-40f, 0.0f, false, 0.000001f)]

        public void Given_TwoFloats_Then_CorrectEquality(float a, float b, bool expected, float threshold = TestingThreshold)
        {
            bool result_a = Comparisons.AreEqual(a, b, threshold);
            bool result_b = Comparisons.AreEqual(b, a, threshold);
            bool result = (result_a == result_b) && (result_a == expected);
            Assert.True(result);
        }

        /* --- Comparisons with extreme values ---
         * Given_TwoExtremeValues_When_Same_Then_Equal
         * (float.MaxValue, float.MaxValue)
         * (float.MinValue, float.MinValue)
         * Given_TwoExtremeValues_When_Different_Then_NotEqual
         * (float.MinValue, float.MaxValue)
         * (float.MaxValue, float.MinValue)
         * Given_ExtremeValueAndHalvedExtremeValue_Then_NotEqual
         * (float.MaxValue, float.MaxValue / 2)
         * (float.MaxValue, float.MinValue / 2)
         * (float.MinValue, float.MaxValue / 2)
         * (float.MinValue, float.MinValue / 2)
         */

        /* --- Comparisons with infinities ---
         * Given_TwoInfinities_When_Same_Then_Equal
         * (float.PositiveInfinity, float.PositiveInifnity)
         * (float.NegativeInfinity, float.NegativeInifnity)
         * Given_TwoInfinities_When_Different_Then_NotEqual
         * (float.PositiveInifnity, float.NegativeInfinity)
         * (float.NegativeInfinity, float.PositiveInfinity)
         * Given_InfinityAndExtremeValue_Then_NotEqual
         * (float.PositiveInifnity, float.MaxValue)
         * (float.PositiveInfinity, float.MinValue)
         * (float.NegativeInfinity, float.MaxValue)
         * (float.NegativeInfinity, float.MinValue)
         */

        /* --- Comparisons with NaNs
         * Given_NanAndWhatever_Then_NotEqual
         * (float.NaN, float.NaN)
         * (float.NaN, 0.0f)
         * (0.0f, float.NaN)
         * (float.NaN, float.PositiveInfinity)
         * (float.PositiveInfinity, float.NaN)
         * (float.NaN, float.NegatvieInfinity)
         * (float.NegativeInfinity, float.NaN)
         * (float.NaN, float.MaxValue)
         * (float.MaxValue, float.NaN)
         * (float.NaN, float.MinValue)
         * (float.MinValue, float.NaN)
         * (float.NaN, float.Epsilon)
         * (float.Epsilon, float.NaN)
         * (float.NaN, -float.Epsilon)
         * (-float.Epsilon, float.NaN)
         */

        /* --- Opposite sides of 0 ---
         * Given_TwoNormalFloats_When_OppositeSigns_Then_NotEqual
         * (1.000000001f, -1.0f)
         * (-1.0f, 1.000000001f)
         * (-1.000000001f, 1.0f)
         * (1.0f, -1.000000001f)
         * Given_TwoSmallSubnormals_When_OppositeSigns_Then_Equal
         * (10 * float.Epsilon, 10 * -float.Epsilon)
         * Given_TwoLargeSubnormals_When_OppositeSigns_Then_NotEqual
         * (10000 * float.Epsilon, 10000 * -float.Epsilon)
         */

        /* -- Floats really close to eachother ---
         * Given_SmallestFloats_When_SameSign_Then_Equal
         * (float.Epsilon, float.Epsilon)
         * Given_SmallestFloats_When_OppositeSigns_Then_Equal
         * (float.Epsilon, -float.Epsilon)
         * (-float.Epsilon, float.Epsilon)
         * Given_SmallestFloatAndZero_Then_Equal
         * (float.Epsilon, 0)
         * (0, float.Epsilon)
         * (-float.Epsilon, 0)
         * (0, -float.Epsilon)
         * Given_NormalFloatAndSmallestFloat_Then_NotEqual
         * (0.000000001f, Float.MIN_VALUE)
         * (0.000000001f, -Float.MIN_VALUE)
         * (-0.000000001f, Float.MIN_VALUE)
         * (-0.000000001f, -Float.MIN_VALUE)
         */
    }
}
