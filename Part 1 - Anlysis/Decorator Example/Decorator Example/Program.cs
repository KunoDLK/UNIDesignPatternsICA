using System;

namespace DecoratorPattern
{
    // The base Component interface defines operations that can be altered by decorators.
    public interface ICoffee
    {
        string GetDescription();
        double GetCost();
    }

    // Concrete Components provide default implementations of the operations.
    public class SimpleCoffee : ICoffee
    {
        public string GetDescription()
        {
            return "Simple coffee";
        }

        public double GetCost()
        {
            return 10;
        }
    }

    // The base Decorator class follows the same interface as the other components.
    // The primary purpose of this class is to define the wrapping interface for all concrete decorators.
    public abstract class CoffeeDecorator : ICoffee
    {
        protected ICoffee _coffee;

        public CoffeeDecorator(ICoffee coffee)
        {
            _coffee = coffee;
        }

        public virtual string GetDescription()
        {
            return _coffee.GetDescription();
        }

        public virtual double GetCost()
        {
            return _coffee.GetCost();
        }
    }

    // Concrete Decorators call the wrapped object and alter its result in some way.
    public class MilkCoffee : CoffeeDecorator
    {
        public MilkCoffee(ICoffee coffee) : base(coffee) { }

        public override string GetDescription()
        {
            return base.GetDescription() + ", with milk";
        }

        public override double GetCost()
        {
            return base.GetCost() + 2;
        }
    }

    public class SugarCoffee : CoffeeDecorator
    {
        public SugarCoffee(ICoffee coffee) : base(coffee) { }

        public override string GetDescription()
        {
            return base.GetDescription() + ", with sugar";
        }

        public override double GetCost()
        {
            return base.GetCost() + 1;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ICoffee coffee = new SimpleCoffee();
            Console.WriteLine($"Cost: {coffee.GetCost()} ; Ingredients: {coffee.GetDescription()}");

            coffee = new MilkCoffee(coffee);
            Console.WriteLine($"Cost: {coffee.GetCost()} ; Ingredients: {coffee.GetDescription()}");

            coffee = new SugarCoffee(coffee);
            Console.WriteLine($"Cost: {coffee.GetCost()} ; Ingredients: {coffee.GetDescription()}");

            Console.ReadKey();
        }
    }
}
