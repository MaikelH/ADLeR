using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADLER.Collections
{
    public class Stack<T> : IEnumerable<T>, ICollection, IEnumerable
    {
        public Stack()
        {

        }

        public Stack(int Capacity)
        {

        }
        
        
        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void CopyTo(System.Array array, int index)
        {
            throw new NotImplementedException();
        }


        public int Count
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsSynchronized
        {
            get { throw new NotImplementedException(); }
        }

        public object SyncRoot
        {
            get { throw new NotImplementedException(); }
        }
    }
}
