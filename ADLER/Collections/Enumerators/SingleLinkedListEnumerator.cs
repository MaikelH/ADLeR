using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADLER.Collections.Enumerators
{
    class SingleLinkedListEnumerator<T> : IEnumerator<T>
    {
        private readonly SingleLinkedNode<T> _startNode;
        private SingleLinkedNode<T> _currentNode;
        private bool _endReached = false;
		 

        internal SingleLinkedListEnumerator(SingleLinkedNode<T> startNode)
		{
		    _startNode = startNode;
		}

        public void Dispose()
        {
            _currentNode = null;
        }

        public bool MoveNext()
        {
            if (_currentNode == null && !_endReached)
			{
			    _currentNode = _startNode;
			    return true;
			}
			if (_currentNode == null && _endReached)
			{
			    return false;
			}
// ReSharper disable PossibleNullReferenceException
            if (_currentNode.Next == null)
// ReSharper restore PossibleNullReferenceException
            {
                _currentNode = null;
                _endReached = true;
                return false;
            }
            
            _currentNode = _currentNode.Next;

            return false;
        }

        public void Reset()
        {
            _currentNode = null;
            _endReached = false;
        }

        public T Current
        {
            get
            {
				if (_currentNode == null)
				{
				    return default(T);
				}
                return _currentNode.Value;
            }
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }
    }
}
