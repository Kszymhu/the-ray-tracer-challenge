namespace TheRayTracerChallenge.FloatMath
{
    public static class Comparisons
    {
        // got it by clicking boxes at https://www.h-schmidt.net/FloatConverter/IEEE754.html
        public const float SmallestNormalFloat = 1.1754943508222875079687365372222456778186655567720875215087517062784172594547271728515625e-38f;

        public static bool AreEqual(float a, float b, float threshold = 0.00001f)
        {
            // Algorithm shamelessly stolen from https://floating-point-gui.de/errors/comparison/
            // Big thanks to the original author.

            if (a == b)
            {
                return true;
            }

            float absoluteA = MathF.Abs(a);
            float absoluteB = MathF.Abs(b);
            float absoluteDifference = MathF.Abs(a - b);
            bool closeToZero = (a == 0 || b == 0 || absoluteA + absoluteB < SmallestNormalFloat);

            if (closeToZero) // Use absolute difference
            {
                return absoluteDifference < (threshold * SmallestNormalFloat);
            }
            else // Use relative difference
            {
                float relativeDifference = absoluteDifference / MathF.Min((absoluteA + absoluteB), float.MaxValue);
                return relativeDifference < threshold;
            }
        }

        public static bool AreInequal(float a, float b, float threshold = 0.0001f)
        {
            return !AreEqual(a, b, threshold);
        }

        public static bool IsGreater(float a, float b, float threshold = 0.0001f)
        {
            return AreInequal(a, b, threshold) && a > b;
        }

        public static bool IsLess(float a, float b, float threshold = 0.0001f)
        {
            throw new NotImplementedException();
        }

        public static bool IsGreaterOrEqual(float a, float b, float threshold = 0.0001f)
        {
            throw new NotImplementedException();
        }

        public static bool IsLessOrEqual(float a, float b, float threshold = 0.0001f)
        {
            throw new NotImplementedException();
        }
    }
}