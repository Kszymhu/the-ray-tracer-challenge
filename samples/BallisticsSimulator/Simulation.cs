using TheRayTracerChallenge;
using TheRayTracerChallenge.FloatMath;

namespace BallisticsSimulator
{
    public class Simulation
    {
        private readonly List<SimulationStep> _steps;

        private SimulationParameters Parameters { get; init; }
        private float TimeStep { get; init; }
        private float MaxTime { get; init; }

        public Simulation(
            SimulationParameters parameters,
            SimulationStep initialStep,
            float timeStep,
            float maxTime)
        {
            Parameters = parameters;
            TimeStep = timeStep;
            MaxTime = maxTime;

            _steps = new() { initialStep };
        }

        public List<SimulationStep> GetSteps()
        {
            return _steps;
        }

        public void Run()
        {
            while(true)
            {
                SimulationStep lastStep = _steps.Last();

                bool didReachMaxTime = Comparisons.IsGreaterOrEqual(lastStep.Time, MaxTime);
                bool didReachGround = Comparisons.IsLessOrEqual(lastStep.ProjectilePosition.Y, 0);
                bool isFirstStep = _steps.Count == 1;
                bool shouldStop = (didReachMaxTime || didReachGround) && !isFirstStep;

                if (shouldStop)
                    return;

                SimulationStep nextStep = GetNextStep(lastStep);
                _steps.Add(nextStep);
            }
        }

        private Vector GetAcceleration(Vector velocity)
        {
            float accelerationBase =
                -(Parameters.ProjectileCoefficientOfDrag / Parameters.ProjectileMass)
                * MathF.Sqrt(velocity.Magnitude);

            float accelerationX = accelerationBase * velocity.X;
            float accelerationY = accelerationBase * velocity.Y - Parameters.GravitationalAcceleration;

            return new(accelerationX, accelerationY, 0.0f);
        }

        private SimulationStep GetNextStep(SimulationStep lastStep)
        {
            // 2nd order RK4 for this system of ODEs:
            // d_position / d_time = velocity
            // d_velocity / d_time = acceleration(velocity)

            Vector k0 = TimeStep * lastStep.ProjectileVelocity;
            Vector l0 = TimeStep * GetAcceleration(lastStep.ProjectileVelocity);

            Vector arg1 = lastStep.ProjectileVelocity + 0.5f * k0;
            Vector k1 = TimeStep * arg1;
            Vector l1 = TimeStep * GetAcceleration(arg1);

            Vector arg2 = lastStep.ProjectileVelocity + 0.5f * k1;
            Vector k2 = TimeStep * arg2;
            Vector l2 = TimeStep * GetAcceleration(arg2);

            Vector arg3 = lastStep.ProjectileVelocity + k2;
            Vector k3 = TimeStep * arg3;
            Vector l3 = TimeStep * GetAcceleration(arg3);

            float newTime = lastStep.Time + TimeStep;
            Point newPosition = lastStep.ProjectilePosition + (1 / 6f) * (k0 + 2 * k1 + 2 * k2 + k3);
            Vector newVelocity = lastStep.ProjectileVelocity + (1 / 6f) * (l0 + 2 * l1 + 2 * l2 + l3);

            return new(newTime, newPosition, newVelocity);
        }
    }
}
