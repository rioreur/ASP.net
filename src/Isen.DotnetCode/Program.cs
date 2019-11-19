using System;
using Isen.Dotnet.Library;

namespace Isen.DotnetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            // Hello test
            Hello hello = new Hello("World");
            Console.WriteLine(hello.Great());

            // MyCollection test d'initialisation
            var array = new String[] {"Je", "suis", "presque", "une", "phrase"};
            MyCollection myCollection = new MyCollection(array);
            Console.WriteLine(myCollection);
            // MyCollection test de "Add"
            myCollection.Add("mais");
            myCollection.Add("pas");
            myCollection.Add("trop");
            Console.WriteLine(myCollection);
            // MyCollection test de "RemoveAt"
            myCollection.RemoveAt(3);
            myCollection.RemoveAt(3);
            Console.WriteLine(myCollection);
            // MyCollection test de "IndexOf"
            Console.WriteLine("index de \"phrase\" : " + myCollection.IndexOf("phrase"));
            Console.WriteLine("index de \"mais\" : " + myCollection.IndexOf("mais"));
            // MyCollection test de l'accesseur indexer
            Console.WriteLine("troisième mot : " + myCollection[3]);
            myCollection[3] = "ou";
            Console.WriteLine("troisième mot : " + myCollection[3]);
        }
    }
}
