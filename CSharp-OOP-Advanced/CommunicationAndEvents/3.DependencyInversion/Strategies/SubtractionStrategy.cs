namespace _3.DependencyInversion.Strategies
{
	public class SubtractionStrategy : ICalculateable
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand - secondOperand;
        }
    }
}
