namespace CsharpChallenges
{
    public static class PrimeCalculator
    {
            public static List<int> GetPrimes(int n)
        {
            List<int> primes = [];
            if (n < 2) return primes;

            bool[] isPrime = new bool[n + 1];
            for (int i = 2; i <= n; i++) isPrime[i] = true;

            for (int i = 2; i * i <= n; i++)
            {
                if (isPrime[i])
                {
                    for (int j = i * i; j <= n; j += i)
                    {
                        isPrime[j] = false;
                    }
                }
            }

            for (int i = 2; i <= n; i++)
            {
                if (isPrime[i]) primes.Add(i);
            }

            return primes;
        }
    }
}