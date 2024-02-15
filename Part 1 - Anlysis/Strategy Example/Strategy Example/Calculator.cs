namespace StaragyExample
{
      internal class Calculator
      {
            private IMathmaticalOperation MathmaticalOperation { get; set; }

            public Calculator(IMathmaticalOperation mathmaticalOperation)
            {
                  MathmaticalOperation = mathmaticalOperation;
            }

            public double Calculate(double firstNumber, double secondNumber)
            {
                  return MathmaticalOperation.Calculate(firstNumber, secondNumber);
            }
      }
}
