using System.Collections;
using System.Net.Http.Headers;

namespace Structure_de_donnée
{
    public class IsCollection<T> : IList<T>
    {
        private List<T> _data = new();

        public IEnumerator<T> GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            if (!Contains(item))
            {
                _data.Add(item);
            }
        }

        public void Clear()
        {
            _data.Clear();
        }

        public bool Contains(T item)
        {
            // Super algo de contains ...
            var trouve = false;
            foreach (var i in _data)

            {
                if (i != null && i.Equals(item))

                {
                    trouve = true;
                    break;

                }

            }
            return trouve;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            if (arrayIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(arrayIndex));

            if (Count > array.Length - arrayIndex)
                throw new ArgumentException("The destination array has fewer elements than the collection.");
            for (var i = 0; i < _data.Count; i++)
            {
                array[i + arrayIndex] = _data[i];
            }
        }

        public bool Remove(T item)

        {
            // Super algo de remove ...
            var resultat = false;
            for (var i = 0; i < _data.Count; i++)

            {
                var cur = _data[i];
                if (cur != null && cur.Equals(item))

                {
                    resultat = true;
                    _data.RemoveAt(i);
                    break;

                }

            }
            return resultat;

        }

        public int IndexOf(T item)
        {
            // Super algo de IndexOf ...
            for (var i = 0; i < _data.Count; i++)

            {
                var cur = _data[i];
                if (cur != null && cur.Equals(item))

                {
                    return i;

                }

            }
            return
           -1;
        }

        public void Insert(int index, T item)
        {
            _data.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            _data.RemoveAt(index);
        }

        public int Count { get { return _data.Count; } }
        public bool IsReadOnly { get { return false; } }

        public T this[int index] 
        { 
            get => _data[index]; 
            set => _data[index] = value; 
        }
    }
}
