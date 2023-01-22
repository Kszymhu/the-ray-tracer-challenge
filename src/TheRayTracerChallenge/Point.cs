namespace TheRayTracerChallenge
{
    public class Point : Tuple
    {
        public Point(float x, float y, float z) : base(x, y, z, 1) { }

        public static Point Origin { get => new(0, 0, 0); }


        public static bool operator ==(Point a, Point b)
        {
            return a.Equals(b);
        }
        public static bool operator !=(Point a, Point b)
        {
            return !a.Equals(b);
        }

        public static Vector operator -(Point a, Point b)
        {
            return new(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }
        public static Point operator -(Point a, Vector b)
        {
            return new(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }
        public static Point operator +(Point a, Vector b)
        {
            return new(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }
        public static Point operator +(Vector a, Point b)
        {
            return new(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        public override bool Equals(object? obj) { return base.Equals(obj); }
        public override int GetHashCode() { return base.GetHashCode(); }
    }
}
