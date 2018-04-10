namespace _3.DependencyInversion
{
    using Strategies;

    public class PrimitiveCalculator
    {
        //private bool isAddition;
        //private AdditionStrategy additionStrategy;
        //private SubtractionStrategy subtractionStrategy;
        private ICalculateable currentStrategy;

        public PrimitiveCalculator()
        {
            //this.additionStrategy = new AdditionStrategy();
            //this.subtractionStrategy = new SubtractionStrategy();
            //this.isAddition = true;
            currentStrategy = new AdditionStrategy();
        }

        public void ChangeStrategy(char @operator)
        {
            switch (@operator)
            {
                case '+':
                    currentStrategy = new AdditionStrategy();
                    //this.isAddition = true;
                    break;
                case '-':
                    currentStrategy = new SubtractionStrategy();
                    //this.isAddition = false;
                    break;
                case '*':
                    currentStrategy = new MultiplicationStrategy();
                    break;
                case '/':
                    currentStrategy = new DivisionStrategy();
                    break;
            }
        }

        public int PerformCalculation(int firstOperand, int secondOperand)
        {
            //if (this.isAddition)
            //{
            //    return additionStrategy.Calculate(firstOperand, secondOperand);
            //}
            //else {
            //    return subtractionStrategy.Calculate(firstOperand, secondOperand);
            //}
            return currentStrategy.Calculate(firstOperand, secondOperand);
        }
    }
}
