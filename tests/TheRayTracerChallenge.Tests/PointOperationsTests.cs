namespace TheRayTracerChallenge.Tests
{
    public class PointOperationsTests
    {
        [Theory]
        [InlineData(1, 2, 3, 6, 5, 4)]
        public void Given_TwoPoints_Then_CorrectSubtraction(
            float x1, float y1, float z1,
            float x2, float y2, float z2)
        {
            Point point1 = new(x1, y1, z1);
            Point point2 = new(x2, y2, z2);
            Vector correct = new(x1 - x2, y1 - y2, z1 - z2);

            Assert.Equal(point1 - point2, correct);
        }

        [Theory]
        [InlineData(1, 2, 3, 4, 5, 6)]
        public void Given_PointAndVector_Then_CorrectAddition(
            float pointX, float pointY, float pointZ,
            float vectorX, float vectorY, float vectorZ)
        {
            Point point = new(pointX, pointY, pointZ);
            Vector vector = new(vectorX, vectorY, vectorZ);
            Point correct = new(pointX + vectorX, pointY + vectorY, pointZ + vectorZ);

            Assert.Equal(point + vector, correct);
            Assert.Equal(vector + point, correct);
        }

        [Theory]
        [InlineData(1, 2, 3, 6, 5, 4)]
        public void Given_PointAndVector_Then_CorrectSubtraction(
            float pointX, float pointY, float pointZ,
            float vectorX, float vectorY, float vectorZ)
        {
            Point point = new(pointX, pointY, pointZ);
            Vector vector = new(vectorX, vectorY, vectorZ);
            Point correct = new(pointX - vectorX, pointY - vectorY, pointZ - vectorZ);

            Assert.Equal(point - vector, correct);
        }
    }
}
