using System;

namespace Patterns
{
    public interface IObserver<T> where T : ISubject
    {
        public void Notify(T subject);
    }
}