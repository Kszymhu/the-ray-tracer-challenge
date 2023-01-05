namespace TheRayTracerChallenge.Tests
{
    public class TupleEqualityTests
    {
        public static IEnumerable<object> VectorEqualityData =>
            new List<object[]>
            {
                new object[]
                {
                    new Vector(1000000f, -1000001f, 1000000f),
                    new Vector(1000001f, -1000000f, 1000001f),
                    true
                },
                new object[]
                {
                    new Vector(10000f, -10001f, 10000f),
                    new Vector(10001f, -10000f, 10001f),
                    false
                },
                new object[]
                {
                    new Vector(-1.0000001f, 1.0000002f, 1.0000001f),
                    new Vector(-1.0000002f, 1.0000001f, 1.0000002f),
                    true
                },
                new object[]
                {
                    new Vector(1.0001f, -1.0002f, -1.0001f),
                    new Vector(1.0002f, -1.0001f, -1.0002f),
                    false
                },
                new object[]
                {
                    new Vector(0.000000001000001f, 0.000000001000002f, -0.000000001000001f),
                    new Vector(0.000000001000002f, 0.000000001000001f, -0.000000001000002f),
                    true
                },
                new object[]
                {
                    new Vector(0.000000000001001f, 0.000000000001002f, -0.000000000001001f),
                    new Vector(0.000000000001002f, 0.000000000001001f, -0.000000000001002f),
                    false
                }
            };

        [Theory]
        [MemberData(nameof(VectorEqualityData))]
        public void Given_TwoVectors_Then_CorrectEquality(Vector a, Vector b, bool correct)
        {
            Assert.Equal(a == b, correct);
        }

        public static IEnumerable<object> PointEqualityData =>
            new List<object[]>
            {
                new object[]
                {
                    new Point(1000000f, -1000001f, 1000000f),
                    new Point(1000001f, -1000000f, 1000001f),
                    true
                },
                new object[]
                {
                    new Point(10000f, -10001f, 10000f),
                    new Point(10001f, -10000f, 10001f),
                    false
                },
                new object[]
                {
                    new Point(-1.0000001f, 1.0000002f, 1.0000001f),
                    new Point(-1.0000002f, 1.0000001f, 1.0000002f),
                    true
                },
                new object[]
                {
                    new Point(1.0001f, -1.0002f, -1.0001f),
                    new Point(1.0002f, -1.0001f, -1.0002f),
                    false
                },
                new object[]
                {
                    new Point(0.000000001000001f, 0.000000001000002f, -0.000000001000001f),
                    new Point(0.000000001000002f, 0.000000001000001f, -0.000000001000002f),
                    true
                },
                new object[]
                {
                    new Point(0.000000000001001f, 0.000000000001002f, -0.000000000001001f),
                    new Point(0.000000000001002f, 0.000000000001001f, -0.000000000001002f),
                    false
                }
            };

        [Theory]
        [MemberData(nameof(PointEqualityData))]
        public void Given_TwoPoints_Then_CorrectEquality(Point a, Point b, bool correct)
        {
            Assert.Equal(a == b, correct);
        }
    }
}
