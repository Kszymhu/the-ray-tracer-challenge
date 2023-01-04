namespace TheRayTracerChallenge.FloatMath.Tests
{
    public class AreInequalTests
    {
        // Tests are the same as in AreEqualTests, just reversed.

        private const float TestingThreshold = 0.00001f;

        [Theory]
        // Large Floats
        [InlineData(1000000f, 1000001f, false)]
        [InlineData(10000f, 10001f, true)]
        [InlineData(-1000000f, -1000001f, false)]
        [InlineData(-10000f, -10001f, true)]
        // Floats around 1 and -1
        [InlineData(1.0000001f, 1.0000002f, false)]
        [InlineData(1.0002f, 1.0001f, true)]
        [InlineData(-1.000001f, -1.000002f, false)]
        [InlineData(-1.0002f, -1.0001f, true)]
        // Floats close to 0
        [InlineData(0.000000001000001f, 0.000000001000002f, false)]
        [InlineData(0.000000000001002f, 0.000000000001001f, true)]
        [InlineData(-0.000000001000001f, -0.000000001000002, false)]
        [InlineData(-0.000000000001002f, -0.000000000001001f, true)]
        // Floats close to eachother, but a bit from 0
        [InlineData(0.3f, 0.30000003f, false)]
        [InlineData(-0.3f, -0.30000003f, false)]
        // Comparisons with 0
        [InlineData(0.0f, 0.0f, false)]
        [InlineData(0.00000001f, 0.0f, true)]
        [InlineData(-0.00000001f, 0.0f, true)]
        [InlineData(0.0f, 1e-40f, false, 0.01f)]
        [InlineData(1e-40f, 0.0f, true, 0.000001f)]
        [InlineData(0.0f, -1e-40f, false, 0.01f)]
        [InlineData(-1e-40f, 0.0f, true, 0.000001f)]
        // Comparisons with extreme values
        [InlineData(float.MaxValue, float.MaxValue, false)]
        [InlineData(float.MinValue, float.MinValue, false)]
        [InlineData(float.MinValue, float.MaxValue, true)]
        [InlineData(float.MaxValue, float.MaxValue / 2, true)]
        [InlineData(float.MaxValue, float.MinValue / 2, true)]
        [InlineData(float.MinValue, float.MaxValue / 2, true)]
        [InlineData(float.MinValue, float.MinValue / 2, true)]
        // Comparisons with infinities
        [InlineData(float.PositiveInfinity, float.PositiveInfinity, false)]
        [InlineData(float.NegativeInfinity, float.NegativeInfinity, false)]
        [InlineData(float.PositiveInfinity, float.NegativeInfinity, true)]
        [InlineData(float.PositiveInfinity, float.MaxValue, true)]
        [InlineData(float.PositiveInfinity, float.MinValue, true)]
        [InlineData(float.NegativeInfinity, float.MaxValue, true)]
        [InlineData(float.NegativeInfinity, float.MinValue, true)]
        // Comparisons with NaNs
        [InlineData(float.NaN, float.NaN, true)]
        [InlineData(float.NaN, 0.0f, true)]
        [InlineData(float.NaN, float.PositiveInfinity, true)]
        [InlineData(float.NaN, float.NegativeInfinity, true)]
        [InlineData(float.NaN, float.MaxValue, true)]
        [InlineData(float.NaN, float.MinValue, true)]
        [InlineData(float.NaN, float.Epsilon, true)]
        [InlineData(float.NaN, -float.Epsilon, true)]
        // Floats on opposite sides of 0
        [InlineData(1.000000001f, -1.0f, true)]
        [InlineData(-1.000000001f, 1.0f, true)]
        [InlineData(10 * float.Epsilon, 10 * -float.Epsilon, false)]
        [InlineData(10000 * float.Epsilon, 10000 * -float.Epsilon, true)]
        // Floats really close to eachother
        [InlineData(float.Epsilon, float.Epsilon, false)]
        [InlineData(-float.Epsilon, -float.Epsilon, false)]
        [InlineData(float.Epsilon, -float.Epsilon, false)]
        [InlineData(float.Epsilon, 0, false)]
        [InlineData(-float.Epsilon, 0, false)]
        [InlineData(0.000000001f, float.Epsilon, true)]
        [InlineData(0.000000001f, -float.Epsilon, true)]
        [InlineData(-0.000000001f, float.Epsilon, true)]
        [InlineData(-0.000000001f, -float.Epsilon, true)]

        public void Given_TwoFloats_Then_CorrectInequality(float a, float b, bool expected, float threshold = TestingThreshold)
        {
            bool result_a = Comparisons.AreInequal(a, b, threshold);
            bool result_b = Comparisons.AreInequal(b, a, threshold);
            bool result = (result_a == result_b) && (result_a == expected);
            Assert.True(result, string.Format("AreEqual({0}, {1}, {2}) = {3}", a, b, threshold, result_a));
        }
    }
}
