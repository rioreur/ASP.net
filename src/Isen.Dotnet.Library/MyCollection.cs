using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace Isen.Dotnet.Library
{
    /// <summary>
    /// Utiliser pour créer et manipuler une liste
    /// </summary>
    public class MyCollection<T> : IList<T>
    {
        // Stockage interne de la liste
        private T[] _values;
        public T[] Values => _values;
        public int Count => _values.Length; // Pas de () car la méthode est un accesseur

        public bool IsReadOnly => false; // Utilisé pour l'héritage de IList

        public MyCollection()
        {
            // Initialisation de la liste (aucuns éléments)
            Clear();
        }

        public MyCollection(T[] array)
        {
            _values = array;
        }

        public bool Contains(T item) => IndexOf(item) >= 0;

        public void CopyTo(T[] array, int index)
        {
            if (array == null) throw new ArgumentNullException();
            if(index < 0) throw new IndexOutOfRangeException();
            if (Count + index > array.Length) throw new ArgumentException();

            for(int i = 0; i < Count; i++)
            {
                array[index + i] = this[i];
            }
        }

        public void Add(T item)
        {
            var tmpArray = new T[Count + 1];
            for (var i = 0; i < Count; i++)
            {
                tmpArray[i] = this[i];
            }
            tmpArray[Count] = item;
            _values = tmpArray;
        }

        public void RemoveAt(int index)
        {
            if (_values?.Length == null ||
                index > Count ||
                index < 0)
                throw new IndexOutOfRangeException();

            var tmpArray = new T[Count - 1];
            for (var i = 0; i < tmpArray.Length; i++)
            {
                tmpArray[i] = this[i < index ? i : i + 1];
            }
            _values = tmpArray;
        }

        public int IndexOf(T item)
        {
            for(var i = 0; i < Count; i++)
            {
                if (item.Equals(this[i]))
                {
                    return i;
                }
            }
            return -1;
        }

        public bool Remove(T item)
        {
            var index = IndexOf(item);
            if (index >=0) RemoveAt(index);
            return index >= 0;
        }

        public void Insert(int index, T item)
        {
            if (index > Count || index < 0)
                throw new IndexOutOfRangeException();
            
            var tmpArray = new T[Count + 1];
            for(int i = 0; i < tmpArray.Length; i++)
            {
                if (i < index) tmpArray[i] = this[i];
                else if (i == index) tmpArray[i] = item;
                else tmpArray[i] = this[i - 1];
            }
            _values = tmpArray;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (var i = 0; i < Count; i++)
            {
                yield return this[i];
            }
        }

        public void Clear() => _values = new T[0];

        // Accesseur indexeur (opérateur [])
        public T this[int index]
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

        public bool Contains(string item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(string[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}