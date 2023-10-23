namespace PrimeGenerator
{
    public class GeneratePrimes_V1
    {
        public static int[] GeneratePrimeNumbers(int maxValue)
        {
            if (maxValue >= 2)
            {
                int s = maxValue + 1;
                bool[] f = new bool[s];
                int i;

                for (i = 0; i < s; i++)
                    f[i] = true;

                f[0] = f[1] = false;

                int j;
                for (i = 2; i < Math.Sqrt(s) + 1; i++)
                {
                    if (f[i])
                    {
                        for (j = 2 * i; j < s; j += i)
                            f[j] = false;
                    }
                }

                int count = 0;
                for (i = 0; i < s; i++)
                {
                    if (f[i]) count++;
                }

                int[] primes = new int[count];

                for (i = 0, j = 0; i < s; i++)
                {
                    if (f[i])
                        primes[j++] = i;
                }

                return primes;
            }
            else
            {
                return new int[0];
            }
        }
    }
    public class GeneratePrimes
    {
        private static int s;
        private static bool[] f;
        private static int[] result;

        public static int[] GeneratePrimeNumbers(int maxValue)
        {
            if (maxValue < 2) return new int[0];
            else
            {
                InitializeArrayOfIntegers(maxValue);
                CrossOutMultiples();
                PutUncrossedIntegersIntoResult();

                return result;
            }
        }
        private static void PutUncrossedIntegersIntoResult()
        {
            int i;
            int j;

            int count = 0;
            for (i = 0; i < s; i++)
            {
                if (f[i]) count++;
            }

            result = new int[count];

            for (i = 0, j = 0; i < s; i++)
            {
                if (f[i])
                    result[j++] = i;
            }
        }
        private static void CrossOutMultiples()
        {
            int i;
            int j;
            for (i = 2; i < Math.Sqrt(s) + 1; i++)
            {
                if (f[i])
                {
                    for (j = 2 * i; j < s; j += i)
                        f[j] = false;
                }
            }
        }
        private static void InitializeArrayOfIntegers(int maxValue)
        {
            s = maxValue + 1;
            f = new bool[s];
            int i;

            for (i = 0; i < s; i++)
                f[i] = true;

            f[0] = f[1] = false;
        }
    }
}