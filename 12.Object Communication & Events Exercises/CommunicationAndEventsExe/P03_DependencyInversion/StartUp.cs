namespace P03_DependencyInversion
{
    using P03_DependencyInversion.contrasts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        static void Main(string[] args)
        {
            PrimitiveCalculator calculator = new PrimitiveCalculator(new AdditionStrategy());

            IEngine engine = new Engine();

            engine.Run(calculator);
        }
        
    }
}
