namespace TheRayTracerChallenge
{
    public class Point : Tuple
    {
        public Point(float x, float y, float z) : base(x, y, z, 1) { }

        public static Point Origin { get => new (0, 0, 0); }

        public override bool Equals(object? obj) { return base.Equals(obj); }
        public override int GetHashCode() { return base.GetHashCode(); }

        public static bool operator ==(Point a, Point b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Point a, Point b)
        {
            return !a.Equals(b);
        }
    }
}
