using System;
using System.Text;

namespace Isen.Dotnet.Library
{
    /// <summary>
    /// Utiliser pour créer et manipuler une liste de string
    /// </summary>
    public class MyCollection
    {
        // Stockage interne de la liste
        private string[] _values;
        public int Count => _values.Length; // pas de () car la méthode est un accesseur
        public MyCollection()
        {
            // Initialisation de la liste (aucuns éléments)
            _values = new string[0];
        }

        public MyCollection(string[] array)
        {
            _values = array;
        }

        // Override de la fonction ToString
        public override string ToString()
        {
            var str = new StringBuilder();
            str.Append("[ ");
            foreach (var value in _values)
            {
                str.Append(value);
                str.Append(" ");
            }
            str.Append("]");
            return str.ToString();
        }
    }
}