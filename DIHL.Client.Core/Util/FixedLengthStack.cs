using System.Collections.Generic;

namespace DIHL.Client.Core.Util
{
    public class FixedLengthStack<T> where T : class
    {
        private readonly int _maxLength;
        private readonly LinkedList<T> _container;

        public int Count => _container.Count;

        public bool Empty => Count == 0;

        public FixedLengthStack(int maxLength)
        {
            _maxLength = maxLength;
            _container = new LinkedList<T>();
        }

        public T Peek()
        {
            if (_container.Count > 0)
                return _container.First.Value;
            return null;
        }

        public T Pop()
        {
            if (_container.Count > 0)
            {
                var first = _container.First;
                _container.RemoveFirst();
                return first.Value;
            }
            return null;
        }

        public void Push(T t)
        {
            _container.AddFirst(t);
            if (_container.Count > _maxLength)
                _container.RemoveLast();
        }
    }
}
