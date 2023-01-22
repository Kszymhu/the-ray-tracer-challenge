using TheRayTracerChallenge.FloatMath;

namespace TheRayTracerChallenge.Tests
{
    public class TupleTests
    {
        [Fact]
        public void Given_Vector_Then_CorrectXYZW()
        {
            float x = 1;
            float y = 2;
            float z = 3;
            float w = 0;

            Vector vector = new(x, y, z);
            Assert.True(Comparisons.AreEqual(vector.X, x));
            Assert.True(Comparisons.AreEqual(vector.Y, y));
            Assert.True(Comparisons.AreEqual(vector.Z, z));
            Assert.True(Comparisons.AreEqual(vector.W, w));

        }

        [Fact]
        public void Given_Point_Then_CorrectXYZW()
        {
            float x = 1;
            float y = 2;
            float z = 3;
            float w = 1;

            Point point = new(x, y, z);
            Assert.True(Comparisons.AreEqual(point.X, x));
            Assert.True(Comparisons.AreEqual(point.Y, y));
            Assert.True(Comparisons.AreEqual(point.Z, z));
            Assert.True(Comparisons.AreEqual(point.W, w));

        }

        [Fact]
        public void Given_Vector_Then_CorrectCoordinates()
        {
            List<float> coordinates = new() { 1, 2, 3, 0 };
            Vector vector = new(coordinates[0], coordinates[1], coordinates[2]);

            Assert.Equal(vector.GetCoordinates(), coordinates);
        }

        [Fact]
        public void Given_Point_Then_CorrectCoordinates()
        {
            List<float> coordinates = new() { 1, 2, 3, 1 };
            Point point = new(coordinates[0], coordinates[1], coordinates[2]);

            Assert.Equal(point.GetCoordinates(), coordinates);
        }

        public static IEnumerable<object> NamedVectorsData =>
            new List<object[]>
            {
                new object[] { Vector.Zero, 0, 0, 0 },
                new object[] { Vector.Left, -1, 0, 0 },
                new object[] { Vector.Right, 1, 0, 0 },
                new object[] { Vector.Down, 0, -1, 0 },
                new object[] { Vector.Up, 0, 1, 0 },
                new object[] { Vector.Back, 0, 0, -1 },
                new object[] { Vector.Forward, 0, 0, 1 }
            };
        [Theory]
        [MemberData(nameof(NamedVectorsData))]
        public void Given_Vector_Then_CorrectNamedValues(Vector vector, float x, float y, float z)
        {
            Assert.True(Comparisons.AreEqual(vector.X, x));
            Assert.True(Comparisons.AreEqual(vector.Y, y));
            Assert.True(Comparisons.AreEqual(vector.Z, z));
        }

        public static IEnumerable<object> NamedPointData =>
            new List<object[]>
            {
                new object[] { Point.Origin, 0, 0, 0 }
            };
        [Theory]
        [MemberData(nameof(NamedPointData))]
        public void Given_Point_Then_CorrectNamedValues(Point point, float x, float y, float z)
        {
            Assert.True(Comparisons.AreEqual(point.X, x));
            Assert.True(Comparisons.AreEqual(point.Y, y));
            Assert.True(Comparisons.AreEqual(point.Z, z));
        }

        [Fact]
        public void Given_Tuple_Then_CorrectStringRepresentation()
        {
            float x = 1;
            float y = 2;
            float z = 3;

            Vector vector = new(x, y, z);
            Point point = new(x, y, z);

            string vectorCorrect = string.Format("[{0}, {1}, {2}, {3}]", x, y, z, 0f);
            string pointCorrect = string.Format("[{0}, {1}, {2}, {3}]", x, y, z, 1f);

            Assert.Equal(vector.ToString(), vectorCorrect);
            Assert.Equal(point.ToString(), pointCorrect);
        }

        [Fact]
        public void Given_TwoTuples_When_Identical_Then_SameHashCodes()
        {
            float x = 1;
            float y = 2;
            float z = 3;

            Vector vectorA = new(x, y, z);
            Vector vectorB = new(x, y, z);
            Point pointA = new(x, y, z);
            Point pointB = new(x, y, z);

            Assert.Equal(vectorA.GetHashCode(), vectorB.GetHashCode());
            Assert.Equal(pointA.GetHashCode(), pointB.GetHashCode());
        }

        [Fact]
        public void Given_Tuple_Then_CorrectIndexing()
        {
            float x = 1;
            float y = 2;
            float z = 3;

            Vector vector = new(x, y, z);
            Point point = new(x, y, z);

            Assert.True(Comparisons.AreEqual(vector[0], x));
            Assert.True(Comparisons.AreEqual(vector[1], y));
            Assert.True(Comparisons.AreEqual(vector[2], z));
            Assert.True(Comparisons.AreEqual(vector[3], 0));
            Assert.True(Comparisons.AreEqual(point[0], x));
            Assert.True(Comparisons.AreEqual(point[1], y));
            Assert.True(Comparisons.AreEqual(point[2], z));
            Assert.True(Comparisons.AreEqual(point[3], 1));
        }
    }
}
