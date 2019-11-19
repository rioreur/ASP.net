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

        public void Add(string data)
        {
            var tmpArray = new string[Count + 1];
            for (var i = 0; i < Count; i++)
            {
                tmpArray[i] = _values[i];
            }
            tmpArray[Count] = data;
            _values = tmpArray;
        }

        public void RemoveAt(int index)
        {
            if (_values?.Length == null ||
                index > Count ||
                index < 0)
                throw new IndexOutOfRangeException();

            var tmpArray = new string[Count - 1];
            for (var i = 0; i < tmpArray.Length; i++)
            {
                tmpArray[i] = _values[i < index ? i : i + 1];
            }
            _values = tmpArray;
        }

        public int IndexOf(String value)
        {
            for(var i = 0; i < Count; i++)
            {
                if (value == _values[i])
                {
                    return i;
                }
            }
            return -1;
        }

        // Accesseur indexeur (opérateur [])
        public string this[int index]
        {
            get => _values[index];
            set => _values[index] = value;
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