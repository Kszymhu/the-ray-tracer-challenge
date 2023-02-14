using TheRayTracerChallenge;

namespace BallisticsSimulator
{
    public struct SimulationStep
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

        public override string ToString()
        {
            return string.Format(
                "Time: {0}\n" +
                "Position: [{1}, {2}]\n" +
                "Velocity: [{3}, {4}]",
                Time,
                ProjectilePosition.X, ProjectilePosition.Y,
                ProjectileVelocity.X, ProjectileVelocity.Y);
        }
    }
}
