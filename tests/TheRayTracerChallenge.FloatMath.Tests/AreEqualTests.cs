using Xunit;

namespace TheRayTracerChallenge.FloatMath.Tests
{
    public class AreEqualTests
    {
        // Tests shamelessly stolen from https://floating-point-gui.de/errors/NearlyEqualsTest.java
        // Big thanks to the original author, because doing this by hand would be a living nightmare.

        private const float TestingEpsilon = 0.0001f;

        /* --- Large Floats ---
         * Given_TwoPositiveLargeFloats_When_SmallDifference_Then_Equal
         * (1000000f, 1000001f)
         * (1000001f, 1000000f)
         * Given_TwoPositiveLargeFloats_When_LargeDifference_Then_NotEqual
         * (10000f, 10001f)
         * (10001f, 10000f)
         * Given_TwoNegativeLargeFloats_When_SmallDifference_Then_Equal
         * (-1000000f, -1000001f)
         * (-1000001f, -1000000f)
         * Given_TwoNegativeLargeFloats_When_LargeDifference_Then_NotEqual
         * (-10000f, -10001f)
         * (-10001f, -10000f)
         */

        /* --- Around 1 ---
         * Given_TwoFloatsAroundPositiveOne_When_SmallDifference_Then_Equal
         * (1.0000001f, 1.0000002f)
         * (1.0000002f, 1.0000001f)
         * Given_TwoFloatsAroundPositiveOne_When_LargeDifference_Then_NotEqual
         * (1.0002f, 1.0001f)
         * (1.0001f, 1.0002f)
         * Given_TwoFloatsAroundNegativeOne_When_SmallDifference_Then_Equal
         * (-1.000001f, -1.000002f)
         * (-1.000002f, -1.000001f)
         * Given_TwoFloatsAroundNegativeOne_When_LargeDifference_Then_NotEqual
         * (-1.0001f, -1.0002f)
         * (-1.0002f, -1.0001f)
         */

        /* --- Between 0 and 1 ---
         * Given_TwoFloatsBetweenZeroAndPositiveOne_When_SmallDifference_Then_Equal
         * (0.000000001000001f, 0.000000001000002f)
         * (0.000000001000002f, 0.000000001000001f)
         * Given_TwoFloatsBetweenZeroAndPositiveOne_When_LargeDifference_Then_NotEqual
         * (0.000000000001002f, 0.000000000001001f)
         * (0.000000000001001f, 0.000000000001002f)
         * Given_TwoFloatsBetweenNegativeOneAndZero_When_SmallDifference_Then_Equal
         * (-0.000000001000001f, -0.000000001000002f)
         * (-0.000000001000002f, -0.000000001000001f)
         * Given_TwoFloatsBetweenNegativeOneAndZero_When_LargeDifference_Then_NotEqual
         * (-0.000000000001002f, -0.000000000001001f)
         * (-0.000000000001001f, -0.000000000001002f)
         */

        /* --- Small differences away form 0 ---
         * Given_TwoPositiveFloatsAwayFromZero_When_SmallDifference_Then_Equal
         * (0.3f, 0.30000003f)
         * Given_TwoNegativeFloatsAwayFromZero_When_LargeDifference_Then_NotEqual
         * (-0.3f, -0.30000003f)
         */

        /* --- Comparisons with 0 ---
         * Given_TwoZeros_Then_Equal
         * (0.0f, 0.0f)
         * Given_ZeroAndFloatBetweenZeroAndPositiveOne_Then_NotEqual
         * (0.00000001f, 0.0f)
         * (0.0f, 0.00000001f)
         * Given_ZeroAndFloatBetweenNegativeOneAndZero_Then_NotEqual
         * (-0.00000001f, 0.0f)
         * (0.0f, -0.00000001f)
         * Given_ZeroAndPositiveSubnormalFloat_When_LargeEpsilon_Then_Equal
         * (0.0f, 1e-40f, 0.01f)
         * (1e-40f, 0.0f, 0.01f)
         * Given_ZeroAndPositiveSubnormalFloat_When_SmallEpsilon_Then_NotEqual
         * (1e-40f, 0.0f, 0.000001f)
         * (0.0f, 1e-40f, 0.000001f)
         * Given_ZeroAndNegativeSubnormalFloat_When_LargeEpsilon_Then_Equal
         * (0.0f, -1e-40f, 0.01f)
         * (-1e-40f, 0.0f, 0.01f)
         * Given_ZeroAndNegativeSubnormalFloat_When_SmallEpsilon_Then_NotEqual
         * (-1e-40f, 0.0f, 0.000001f)
         * (0.0f, -1e-40f, 0.000001f)
         */

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
