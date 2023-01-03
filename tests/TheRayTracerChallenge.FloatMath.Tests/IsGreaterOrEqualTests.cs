namespace TheRayTracerChallenge.FloatMath.Tests
{
    public class IsGreaterOrEqualTests
    {
        // IsGreaterTests, but if a and b are equal then also true

        private const float TestingThreshold = 0.00001f; // Used for most tests, except like 2 or sth

        [Theory]
        // Large Floats
        [InlineData(1000000f, 1000001f, true)] // equal
        [InlineData(1000001f, 1000000f, true)] // equal
        [InlineData(10000f, 10001f, false)] // inequal, b is greater
        [InlineData(10001f, 10000f, true)] // inequal, a is greater
        [InlineData(-1000000f, -1000001f, true)] // equal
        [InlineData(-1000001f, -1000000f, true)] // equal
        [InlineData(-10000f, -10001f, true)] // inequal, a is greater
        [InlineData(-10001f, -10000f, false)] // inequal, b is greater
        // Floats around 1 and -1
        [InlineData(1.0000001f, 1.0000002f, true)] // equal
        [InlineData(1.0000002f, 1.0000001f, true)] // equal
        [InlineData(1.0002f, 1.0001f, true)] // inequal, a is greater
        [InlineData(1.0001f, 1.0002f, false)] // inequal, b is greater
        [InlineData(-1.000001f, -1.000002f, true)] // equal
        [InlineData(-1.000002f, -1.000001f, true)] // equal
        [InlineData(-1.0002f, -1.0001f, false)] // inequal, b is greater
        [InlineData(-1.0001f, -1.0002f, true)] // inequal, a is greater
        // Floats close to 0
        [InlineData(0.000000001000001f, 0.000000001000002f, true)] // equal
        [InlineData(0.000000001000002f, 0.000000001000001f, true)] // equal
        [InlineData(0.000000000001002f, 0.000000000001001f, true)] // inequal, a is greater
        [InlineData(0.000000000001001f, 0.000000000001002f, false)] // inequal, b is greater
        [InlineData(-0.000000001000001f, -0.000000001000002, true)] // equal
        [InlineData(-0.000000001000002f, -0.000000001000001, true)] // equal
        [InlineData(-0.000000000001002f, -0.000000000001001f, false)] // inequal, b is greater
        [InlineData(-0.000000000001001f, -0.000000000001002f, true)] // inequal, a is greater
        // Floats close to eachother, but a bit from 0
        [InlineData(0.3f, 0.30000003f, true)] // equal
        [InlineData(0.30000003f, 0.3f, true)] // equal
        [InlineData(-0.3f, -0.30000003f, true)] // equal
        [InlineData(-0.30000003f, -0.3f, true)] // equal
        // Comparisons with 0
        [InlineData(0.0f, 0.0f, true)] // equal
        [InlineData(0.00000001f, 0.0f, true)] // inequal, a is greater
        [InlineData(0.0f, 0.00000001f, false)] // inequal, b is greater
        [InlineData(-0.00000001f, 0.0f, false)] // inequal, b is greater
        [InlineData(0.0f, -0.00000001f, true)] // inequal, a is greater
        [InlineData(0.0f, 1e-40f, true, 0.01f)] // equal
        [InlineData(1e-40f, 0.0f, true, 0.01f)] // equal
        [InlineData(1e-40f, 0.0f, true, 0.000001f)] // inequal, a is greater
        [InlineData(0.0f, 1e-40f, false, 0.000001f)] // inequal, b is greater
        [InlineData(0.0f, -1e-40f, true, 0.01f)] // equal
        [InlineData(-1e-40f, 0.0f, true, 0.01f)] // equal
        [InlineData(-1e-40f, 0.0f, false, 0.000001f)] // inequal, b is greater
        [InlineData(0.0f, -1e-40f, true, 0.000001f)] // inequal, a is greater
        // Comparisons with extreme values
        [InlineData(float.MaxValue, float.MaxValue, true)] // equal
        [InlineData(float.MinValue, float.MinValue, true)] // equal
        [InlineData(float.MinValue, float.MaxValue, false)] // inequal, b is greater
        [InlineData(float.MaxValue, float.MinValue, true)] // inequal, a is greater
        [InlineData(float.MaxValue, float.MaxValue / 2, true)] // inequal, a is greater
        [InlineData(float.MaxValue / 2, float.MaxValue, false)] // inequal, b is greater
        [InlineData(float.MaxValue, float.MinValue / 2, true)] // inequal, a is greater
        [InlineData(float.MinValue / 2, float.MaxValue, false)] // inequal, b is greater
        [InlineData(float.MinValue, float.MaxValue / 2, false)] // inequal, b is greater
        [InlineData(float.MaxValue / 2, float.MinValue, true)] // inequal, a is greater
        [InlineData(float.MinValue, float.MinValue / 2, false)] // inequal, b is greater
        [InlineData(float.MinValue / 2, float.MinValue, true)] // inequal, a is greater
        // Comparisons with infinities
        [InlineData(float.PositiveInfinity, float.PositiveInfinity, true)] // equal
        [InlineData(float.NegativeInfinity, float.NegativeInfinity, true)] // equal
        [InlineData(float.PositiveInfinity, float.NegativeInfinity, true)] // inequal, a is greater
        [InlineData(float.NegativeInfinity, float.PositiveInfinity, false)] // inequal, b is greater
        [InlineData(float.PositiveInfinity, float.MaxValue, true)] // inequal, a is greater
        [InlineData(float.MaxValue, float.PositiveInfinity, false)] // inequal, b is greater
        [InlineData(float.PositiveInfinity, float.MinValue, true)] // inequal, a is greater
        [InlineData(float.MinValue, float.PositiveInfinity, false)] // inequal, b is greater
        [InlineData(float.NegativeInfinity, float.MaxValue, false)] // inequal, b is greater
        [InlineData(float.MaxValue, float.NegativeInfinity, true)] // inequal, a is greater
        [InlineData(float.NegativeInfinity, float.MinValue, false)] // inequal, b is greater
        [InlineData(float.MinValue, float.NegativeInfinity, true)] // inequal, a is greater
        // Comparisons with NaNs
        [InlineData(float.NaN, float.NaN, false)] // inequal, NaNs
        [InlineData(float.NaN, 0.0f, false)] // inequal, NaNs
        [InlineData(0.0f, float.NaN, false)] // inequal, NaNs
        [InlineData(float.NaN, float.PositiveInfinity, false)] // inequal, NaNs
        [InlineData(float.PositiveInfinity, float.NaN, false)] // inequal, NaNs
        [InlineData(float.NaN, float.NegativeInfinity, false)] // inequal, NaNs
        [InlineData(float.NegativeInfinity, float.NaN, false)] // inequal, NaNs
        [InlineData(float.NaN, float.MaxValue, false)] // inequal, NaNs
        [InlineData(float.MaxValue, float.NaN, false)] // inequal, NaNs
        [InlineData(float.NaN, float.MinValue, false)] // inequal, NaNs
        [InlineData(float.MinValue, float.NaN, false)] // inequal, NaNs
        [InlineData(float.NaN, float.Epsilon, false)] // inequal, NaNs
        [InlineData(float.Epsilon, float.NaN, false)] // inequal, NaNs
        [InlineData(float.NaN, -float.Epsilon, false)] // inequal, NaNs
        [InlineData(-float.Epsilon, float.NaN, false)] // inequal, NaNs
        // Floats on opposite sides of 0
        [InlineData(1.000000001f, -1.0f, true)] // inequal, a is greater
        [InlineData(-1.0f, 1.000000001f, false)] // inequal, b is greater
        [InlineData(10 * float.Epsilon, 10 * -float.Epsilon, true)] // equal
        [InlineData(10 * -float.Epsilon, 10 * float.Epsilon, true)] // equal
        [InlineData(10000 * float.Epsilon, 10000 * -float.Epsilon, true)] // inequal, a is greater
        [InlineData(10000 * -float.Epsilon, 10000 * float.Epsilon, false)] // inequal, b is greater
        // Floats really close to eachother
        [InlineData(float.Epsilon, float.Epsilon, true)] // equal
        [InlineData(float.Epsilon, -float.Epsilon, true)] // equal
        [InlineData(-float.Epsilon, float.Epsilon, true)] // equal
        [InlineData(float.Epsilon, 0, true)] // equal
        [InlineData(0, float.Epsilon, true)] // equal
        [InlineData(-float.Epsilon, 0, true)] // equal
        [InlineData(0, -float.Epsilon, true)] // equal
        [InlineData(0.000000001f, float.Epsilon, true)] // inequal, a is greater
        [InlineData(float.Epsilon, 0.000000001f, false)] // inequal, b is greater
        [InlineData(0.000000001f, -float.Epsilon, true)] // inequal, a is greater
        [InlineData(-float.Epsilon, 0.000000001f, false)] // inequal, b is greater
        [InlineData(-0.000000001f, float.Epsilon, false)] // inequal, b is greater
        [InlineData(float.Epsilon, -0.000000001f, true)] // inequal, a is greater
        [InlineData(-0.000000001f, -float.Epsilon, false)] // inequal, b is greater
        [InlineData(-float.Epsilon, -0.000000001f, true)] // inequal, a is greater

        public void Given_TwoFloats_Then_CorrectIsGreaterOrEqual(float a, float b, bool expected, float threshold = TestingThreshold)
        {
            bool result = Comparisons.IsGreaterOrEqual(a, b, threshold);
            Assert.True(result == expected);
        }
    }
}
