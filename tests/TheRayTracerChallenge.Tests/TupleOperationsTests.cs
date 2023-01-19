using TheRayTracerChallenge.FloatMath;

namespace TheRayTracerChallenge.Tests
{
    public class TupleOperationsTests
    {
        // v.Magnitude
        // --- (1, 2, 3).Magnitude = MathF.sqrt(14)
        // f * v, v * f
        // --- 5 * (1, 2, 3) = (5, 10, 15)
        // --- (1, 2, 3) * 5 = (5, 10, 15)
        // v / f
        // --- (1, 2, 3) / 10 = (.1, .2, .3)
        // v + v
        // --- (1, 2, 3) + (4, 5, 6) = (5, 7, 9)
        // v - v
        // --- (1, 2, 3) - (6, 5, 4) = (-5, -3, -1)
        // v dot v
        // --- DotProduct((1, 2, 3), (4, 5, 6)) = 32
        // v cross v
        // --- CrossProduct((1, 2, 3), (4, 5, 6)) = (-3, 6, -3) 
        //
        // p - p
        // --- (1, 2, 3) - (6, 5, 4) = (-5, -3, -1)
        // p + v
        // --- (1, 2, 3) + (4, 5, 6) = (5, 7, 9)
        // p - v
        // --- (1, 2, 3) - (6, 5, 4) = (-5, -3, -1)
    }
}
