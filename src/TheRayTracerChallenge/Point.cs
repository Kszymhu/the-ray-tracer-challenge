namespace TheRayTracerChallenge
{
    public class Point : Tuple
    {
        public Point(float x, float y, float z) : base(x, y, z, 1) { }

        public static Point Origin { get => new (0, 0, 0); }
    }
}
