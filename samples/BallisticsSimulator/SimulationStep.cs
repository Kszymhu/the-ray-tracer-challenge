using TheRayTracerChallenge;

namespace BallisticsSimulator
{
    public class SimulationStep
    {
        public SimulationStep(float time, Point projectilePosition, Vector projectileVelocity)
        {
            Time = time;
            ProjectilePosition = projectilePosition;
            ProjectileVelocity = projectileVelocity;
        }

        public float Time { get; private init; }
        public Point ProjectilePosition { get; private init; }
        public Vector ProjectileVelocity { get; private init; }
    }
}
