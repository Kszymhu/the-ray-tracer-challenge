namespace TheRayTracerChallenge
{
    public class Vector : Tuple
    {
        public Vector(float x, float y, float z) : base(x, y, z, 0) { }

        public static Vector Zero { get => new (0, 0, 0); }
        public static Vector Left { get => new (-1, 0, 0); }
        public static Vector Right { get => new (1, 0, 0); }
        public static Vector Down { get => new (0, -1, 0); }
        public static Vector Up { get => new (0, 1, 0); }
        public static Vector Back { get => new (0, 0, -1); }
        public static Vector Forward { get => new (0, 0, 1); }
    }
}
