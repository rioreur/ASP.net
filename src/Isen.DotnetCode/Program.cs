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
            myCollection.Add("mais");
            myCollection.Add("pas");
            myCollection.Add("trop");
            Console.WriteLine(myCollection);
            myCollection.RemoveAt(3);
            myCollection.RemoveAt(3);
            Console.WriteLine(myCollection);
            Console.WriteLine("index de \"phrase\" : " + myCollection.IndexOf("phrase"));
            Console.WriteLine("index de \"mais\" : " + myCollection.IndexOf("mais"));
        }
    }
}
