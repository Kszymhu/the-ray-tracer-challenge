using TheRayTracerChallenge;

namespace BallisticsSimulator
{
    public struct ProjectileTraits
    {
        public float Mass { get; private init; }
        public float CoefficientOfDrag { get; private init; }
    }
}
