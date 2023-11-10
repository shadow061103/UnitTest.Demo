namespace UnitTest.Demo
{
    public class Calculator
    {
        public int Add(int first, int second)
        { return first + second; }

        public int Minus(int firstNumber, int secondNumber)
        {
            var result = firstNumber - secondNumber;
            return result;
        }

        public double Mix(int first, int second, int third)
        {
            if ((first + second).Equals(0))
                throw new ArgumentException("first + second總和不可為零");
            if (third.Equals(0))
                throw new ArgumentException("third不可為零");
            var result = (first + second) / third;
            return result;
        }

        internal int AddInternal(int a, int b)
        {
            return a + b;
        }

        public async Task<double> MixAsync(int first, int second, int third)
        {
            if ((first + second).Equals(0))
                throw new ArgumentException("first + second總和不可為零");
            if (third.Equals(0))
                throw new ArgumentException("third不可為零");
            var result = (first + second) / third;

            return await Task.FromResult(result);
        }
    }
}