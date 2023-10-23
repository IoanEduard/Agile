using PrimeGenerator;

namespace PrimeGenerator_Tests
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestPrimes()
        {
            int[] nullArray = GeneratePrimes.GeneratePrimeNumbers(0);
            Assert.That(nullArray.Length, Is.EqualTo(0));

            int[] minArray = GeneratePrimes.GeneratePrimeNumbers(2);
            Assert.That(minArray.Length, Is.EqualTo(1));
            Assert.That(minArray[0], Is.EqualTo(2));

            int[] threeArray = GeneratePrimes.GeneratePrimeNumbers(3);
            Assert.That(threeArray.Length, Is.EqualTo(2));
            Assert.That(threeArray[0], Is.EqualTo(2));
            Assert.That(threeArray[1], Is.EqualTo(3));

            int[] centArray = GeneratePrimes.GeneratePrimeNumbers(100);
            Assert.That(centArray.Length, Is.EqualTo(25));
            Assert.That(centArray[24], Is.EqualTo(97));
        }
        [Test]
        public void TestExhaustive()
        {
            for (int i = 2; i < 500; i++)
                VerifyPrimeList(GeneratePrimes.GeneratePrimeNumbers(i));
        }
        private void VerifyPrimeList(int[] list)
        {
            for (int i = 0; i < list.Length; i++)
                VerifyPrime(list[i]);
        }
        private void VerifyPrime(int n)
        {
            for (int factor = 2; factor < n; factor++)
                Assert.IsTrue(n % factor != 0);
        }

    }
}