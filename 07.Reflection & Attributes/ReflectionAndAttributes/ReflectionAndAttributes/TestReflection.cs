using System;
using System.Collections.Generic;
using System.Text;

namespace ReflectionDemo
{

    public class TestReflection: IBaseInterface, IDerivedInterfase
    {
        private static string privateStatic = "";
        public static string publicStatic = "";

        private string privateInstance = "";
        public string publicInstance = "";

        public int PublicIntProperty { get; set; }
        private int PrivateIntProperty { get; set; }

        public TestReflection()
        {
            Console.WriteLine("EMPTY CONSTRUCTOR");
            PublicIntProperty = 0;
            PrivateIntProperty = 0;
        }

        public TestReflection(int test)
        {
            Console.WriteLine("INT CONSTRUCTOR");
        }

        public TestReflection(string test)
        {
            Console.WriteLine("STRING CONSTRUCTOR");
        }

        public TestReflection(double test)
        {
            Console.WriteLine("DOUBLE CONSTRUCTOR");
        }   
    }

    interface IBaseInterface
    {}

    interface IDerivedInterfase
    {}
}