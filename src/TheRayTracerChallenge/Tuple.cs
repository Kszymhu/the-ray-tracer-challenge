namespace TheRayTracerChallenge
{
    public abstract class Tuple
    {
        private readonly List<float> _coordinates;

        protected Tuple(float x, float y, float z, float w)
        {
            _coordinates = new List<float> { x, y, z, w };
        }

        public float X { get => _coordinates[0]; }
        public float Y { get => _coordinates[1]; }
        public float Z { get => _coordinates[2]; }
        public float W { get => _coordinates[3]; }

        public float this[int i]
        {
            get { return _coordinates[i]; }
            private set { _coordinates[i] = value; }
        }

        public List<float> GetCoordinates()
        {
            return _coordinates;
        }

        public override string ToString()
        {
            return string.Format("[{0}, {1}, {2}, {3}]", X, Y, Z, W);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y, Z, W);
        }
    }
}
