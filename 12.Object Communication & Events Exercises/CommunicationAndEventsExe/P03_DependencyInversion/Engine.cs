namespace P03_DependencyInversion
{
    using contrasts;
    using System;
    using System.Linq;

    public class Engine : IEngine
    {
        public void Run(PrimitiveCalculator calculator)
        {

            string input = "";
            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split().ToArray();
                string command = tokens[0];

                if (command == "mode")
                {
                    char @operator = char.Parse(tokens[1]);
                    IStrategy strategyToChange = FindStrategy(@operator);
                    calculator.changeStrategy(strategyToChange);
                }
                else
                {
                    int numberOne = int.Parse(command);
                    int numberTwo = int.Parse(tokens[1]);
                    Console.WriteLine(calculator.performCalculation(numberOne, numberTwo));
                }

            }

        }

        public static IStrategy FindStrategy(char @operator)
        {
            IStrategy strategyToChange = null;

            switch (@operator)
            {
                case '+':
                    strategyToChange = new AdditionStrategy();
                    break;
                case '-':
                    strategyToChange = new SubtractionStrategy();
                    break;
                case '*':
                    strategyToChange = new MultiplicationStrategy();
                    break;
                case '/':
                    strategyToChange = new DivisionStrategy();
                    break;
                default:
                    throw new ArgumentException($"Invalid operator {@operator} !");
            }

            return strategyToChange;

        }

    }
}
