namespace BallisticsSimulator
{
    public class SimulationParameters
    {
        public SimulationParameters(
            float projectileMass,
            float projectileCoefficientOfDrag,
            float gravitationalAcceleration)
        {
            ProjectileMass = projectileMass;
            ProjectileCoefficientOfDrag = projectileCoefficientOfDrag;
            GravitationalAcceleration = gravitationalAcceleration;
        }

        public float ProjectileMass { get; private init; }
        public float ProjectileCoefficientOfDrag { get; private init; }
        public float GravitationalAcceleration { get; private init; }
    }
}
