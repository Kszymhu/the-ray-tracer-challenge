namespace TheRayTracerChallenge
{
    public class Vector : Tuple
    {
        public Vector(float x, float y, float z) : base(x, y, z, 0) { }

        public static Vector Zero { get => new(0, 0, 0); }
        public static Vector Left { get => new(-1, 0, 0); }
        public static Vector Right { get => new(1, 0, 0); }
        public static Vector Down { get => new(0, -1, 0); }
        public static Vector Up { get => new(0, 1, 0); }
        public static Vector Back { get => new(0, 0, -1); }
        public static Vector Forward { get => new(0, 0, 1); }

        public float Magnitude
        {
            get => MathF.Sqrt((X * X) + (Y * Y) + (Z * Z));
        }

        public Vector Normalized
        {
            get => this / Magnitude;
        }

        public static bool operator ==(Vector a, Vector b)
        {
            return a.Equals(b);
        }
        public static bool operator !=(Vector a, Vector b)
        {
            return !a.Equals(b);
        }

        public static Vector operator -(Vector a)
        {
            return new(-a.X, -a.Y, -a.Z);
        }

        public static Vector operator +(Vector a, Vector b)
        {
            return new(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }
        public static Vector operator -(Vector a, Vector b)
        {
            return new(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }
        public static Vector operator *(Vector a, float b)
        {
            return new(a.X * b, a.Y * b, a.Z * b);
        }
        public static Vector operator *(float a, Vector b)
        {
            return new(a * b.X, a * b.Y, a * b.Z);
        }
        public static Vector operator /(Vector a, float b)
        {
            return new(a.X / b, a.Y / b, a.Z / b);
        }

        public static float DotProduct(Vector a, Vector b)
        {
            return (a.X * b.X) + (a.Y * b.Y) + (a.Z * b.Z);
        }
        public static Vector CrossProduct(Vector a, Vector b)
        {
            float resultX = (a.Y * b.Z) - (a.Z * b.Y);
            float resultY = (a.Z * b.X) - (a.X * b.Z);
            float resultZ = (a.X * b.Y) - (a.Y * b.X);
            return new(resultX, resultY, resultZ);
        }

        public override bool Equals(object? obj) => base.Equals(obj);
        public override int GetHashCode() { return base.GetHashCode(); }
    }
}
