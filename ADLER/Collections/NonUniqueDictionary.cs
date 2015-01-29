using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NewsRetriever
{
    public class NonUniqueDictionary<T, X>
    {
        private Dictionary<T, HashSet<X>> _internalDictionary;

        public NonUniqueDictionary()
            : base()
        {
            _internalDictionary = new Dictionary<T, HashSet<X>>();
        }


        public IEnumerator<KeyValuePair<T, HashSet<X>>> GetEnumerator()
        {
            return _internalDictionary.GetEnumerator();
        }

        public void Add(KeyValuePair<T, HashSet<X>> item)
        {
            if (_internalDictionary.ContainsKey(item.Key))
            {
                _internalDictionary[item.Key].UnionWith(item.Value);
            }
            else
            {
                _internalDictionary.Add(item.Key, item.Value);
            }
        }

        public void Clear()
        {
            _internalDictionary.Clear();
        }

        public bool Contains(X obj)
        {
            return _internalDictionary.Keys.ToList()
                .Select(x => _internalDictionary[x]
                .Contains(obj))
                .Aggregate((b, b1) => b || b1);
        }

        public bool Contains(KeyValuePair<T, HashSet<X>> item)
        {
            return _internalDictionary.Contains(item);
        }


        public bool Remove(T key, X item)
        {
            return _internalDictionary[key].Remove(item);
        }

        public bool Remove(T key)
        {
            return _internalDictionary.Remove(key);
        }

        public int Count
        {
            get { return _internalDictionary.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool ContainsKey(T key)
        {
            return _internalDictionary.ContainsKey(key);
        }

        public void Add(T key, X value)
        {
            if (_internalDictionary.ContainsKey(key))
            {
                _internalDictionary[key].Add(value);
            }
            else
            {
                _internalDictionary.Add(key, new HashSet<X> { value });
            }
        }

        public void Add(T key, IEnumerable<X> value)
        {
            _internalDictionary.Add(key, new HashSet<X>(value));
        }

        public bool TryGetValue(T key, out HashSet<X> value)
        {
            throw new NotImplementedException();
        }

        public HashSet<X> this[T key]
        {
            get { return _internalDictionary[key]; }
            set { _internalDictionary[key] = value; }
        }

        public ICollection<T> Keys
        {
            get { return _internalDictionary.Keys; }
        }

        public ICollection<HashSet<X>> Values
        {
            get
            {
                List<HashSet<X>> values = new List<HashSet<X>>();

                _internalDictionary.Keys.ToList().ForEach(x => values.Add(_internalDictionary[x]));

                return values;
            }
        }
    }
}