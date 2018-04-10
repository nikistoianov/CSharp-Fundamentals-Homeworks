namespace _3.DependencyInversion.Strategies
{
    public class DivisionStrategy : ICalculateable
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand / secondOperand;
        }
    }
}
