using System;
using Isen.Dotnet.Library;

namespace Isen.DotnetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Hello hello = new Hello("World");
            Console.WriteLine(hello.Great());
        }
    }
}
