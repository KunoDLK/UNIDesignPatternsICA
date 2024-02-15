using StaragyExample;

Calculator calculator = null;
do
{
      int stratNumber;
      Console.WriteLine("Select Strtagy");
      Console.WriteLine("1. Add");
      Console.WriteLine("2. Minus");
      Console.WriteLine("3. Times");
      Console.WriteLine("4. Devide");
      try
      {
            stratNumber = int.Parse(Console.ReadLine());
      }
      catch (Exception)
      {
            continue;
      }

      switch (stratNumber)
      {
            case 1:
                  calculator = new Calculator(new AddOperation());
                  break;
            case 2:
                  calculator = new Calculator(new MinusOperation());
                  break;
            case 3:
                  calculator = new Calculator(new TimesOperation());
                  break;
            case 4:
                  calculator = new Calculator(new DevideOperation());
                  break;

            default:
                  continue;
      }

}
while (calculator == null);


while (true)
{

      try
      {
            Console.WriteLine("Enter the first number");
            int firstNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the second number");
            int secondNumber = int.Parse(Console.ReadLine());

            Console.WriteLine(calculator.Calculate(firstNumber, secondNumber));
      }
      catch (Exception)
      {
            Console.WriteLine("Error");
            throw;
      }
}