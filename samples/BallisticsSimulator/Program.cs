using TheRayTracerChallenge;

namespace BallisticsSimulator
{
    public class Program
    {
        static void Main()
        {
            float projectileMass = 0.25f;
            float projectileCoefficientOfDrag = 0.03f;
            float gravitationalAcceleration = 9.80665f;

            float timeStep = 0.0001f;
            float maxTime = 60.0f;

            Point initialPosition = Point.Origin;
            Vector initialVelocity = new(44.5f, 22.7f, 0f);

            SimulationParameters parameters = new(
                projectileMass,
                projectileCoefficientOfDrag,
                gravitationalAcceleration);

            SimulationStep initialStep = new(0f, initialPosition, initialVelocity);

            Simulation simulation = new(
                parameters,
                initialStep,
                timeStep,
                maxTime);

            simulation.Run();

            List<SimulationStep> steps = simulation.GetSteps();

            for(int i = 0; i < steps.Count; i++)
            {
                SimulationStep step = steps[i];
                string message = string.Format("Step index: {0}\n{1}\n", i, step);
                Console.WriteLine(message);
            }
        }
    }
}