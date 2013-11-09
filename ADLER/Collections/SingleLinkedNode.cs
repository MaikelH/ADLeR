using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADLER.Collections
{
    internal class SingleLinkedNode<T>
    {
        private T _value;
        private SingleLinkedNode<T> _next;

        public SingleLinkedNode() : this(default(T), null) 
        {
            
        }

        public SingleLinkedNode(T Value) : this(Value, null)
        {
            
        }

        public SingleLinkedNode(T Value, SingleLinkedNode<T> Next)
        {
            this._value = Value;
            this._next = Next;
        }

        public T Value
        {
            get { return this._value; }
            set { this._value = value;}
        }

        public SingleLinkedNode<T> Next 
        {
            get{ return this._next; }
            set { this._next = value; }
        }

    }
}
