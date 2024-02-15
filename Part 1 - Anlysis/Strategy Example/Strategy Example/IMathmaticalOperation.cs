namespace StaragyExample
{
      internal interface IMathmaticalOperation
      {
            public double Calculate(double x, double y);
      }


      public class TimesOperation : IMathmaticalOperation
      {
            public double Calculate(double x, double y)
            {
                  return x * y;
            }
      }

      public class AddOperation : IMathmaticalOperation
      {
            public double Calculate(double x, double y)
            {
                  return x + y;
            }
      }

      public class MinusOperation : IMathmaticalOperation
      {
            public double Calculate(double x, double y)
            {
                  return x - y;
            }
      }

      public class DevideOperation : IMathmaticalOperation
      {
            public double Calculate(double x, double y)
            {
                  return x / y;
            }
      }
}

