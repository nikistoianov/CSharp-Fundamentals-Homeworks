namespace _3.DependencyInversion.Strategies
{
    public class MultiplicationStrategy : ICalculateable
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand * secondOperand;
        }
    }
}
