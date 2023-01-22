using TheRayTracerChallenge.FloatMath;

namespace TheRayTracerChallenge.Tests
{
    public class TupleOperationsTests
    {
        [Theory]
        [InlineData(1, 2, 3)]
        public void Given_Vector_Then_CorrectMagnitude(float x, float y, float z)
        {
            Vector vector = new(x, y, z);
            float correctMagnitude = MathF.Sqrt(x * x + y * y + z * z);
            Assert.True(Comparisons.AreEqual(vector.Magnitude, correctMagnitude, Tuple.EqualityThreshold));
        }

        [Theory]
        [InlineData(1, 2, 3, 5)]
        public void Given_FloatAndVector_Then_CorrectScaling(float x, float y, float z, float f)
        {
            Vector vector = new(x, y, z);
            Vector correct = new(x * f, y * f, z * f);

            Assert.Equal(f * vector, correct);
            Assert.Equal(vector * f, correct);
        }

        [Theory]
        [InlineData(1, 2, 3, 5)]
        public void Given_FloatAndVector_Then_CorrectDivision(float x, float y, float z, float f)
        {
            Vector vector = new(x, y, z);
            Vector correct = new(x / f, y / f, z / f);

            Assert.Equal(vector / f, correct);
        }

        [Theory]
        [InlineData(1, 2, 3, 4, 5, 6)]
        public void Given_TwoVectors_Then_CorrectAddition(float x1, float y1, float z1, float x2, float y2, float z2)
        {
            Vector vector1 = new(x1, y1, z1);
            Vector vector2 = new(x2, y2, z2);
            Vector correct = new(x1 + x2, y1 + y2, z1 + z2);

            Assert.Equal(vector1 + vector2, correct);
            Assert.Equal(vector2 + vector1, correct);
        }

        [Theory]
        [InlineData(1, 2, 3, 6, 5, 4)]
        public void Given_TwoVectors_Then_CorrectSubtraction(float x1, float y1, float z1, float x2, float y2, float z2)
        {
            Vector vector1 = new(x1, y1, z1);
            Vector vector2 = new(x2, y2, z2);
            Vector correct = new(x1 - x2, y1 - y2, z1 - z2);

            Assert.Equal(vector1 - vector2, correct);
        }

        // v dot v
        // --- DotProduct((1, 2, 3), (4, 5, 6)) = 32
        // v cross v
        // --- CrossProduct((1, 2, 3), (4, 5, 6)) = (-3, 6, -3) 
        //
        // p - p
        // --- (1, 2, 3) - (6, 5, 4) = (-5, -3, -1)
        // p + v
        // --- (1, 2, 3) + (4, 5, 6) = (5, 7, 9)
        // p - v
        // --- (1, 2, 3) - (6, 5, 4) = (-5, -3, -1)
    }
}
