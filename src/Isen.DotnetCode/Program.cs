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

            var array = new String[] {"Je", "suis", "presque", "une", "phrase"};
            MyCollection myCollection = new MyCollection(array);
            Console.WriteLine(myCollection);
        }
    }
}
