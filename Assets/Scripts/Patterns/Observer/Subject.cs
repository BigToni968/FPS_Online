using System.Collections.Generic;

namespace Patterns
{
    public interface ISubject
    {
        public void Invoke();
    }

    public interface ISubjectLogic<T> : ISubject where T : ISubject
    {
        public IReadOnlyList<IObserver<T>> Observers { get; }

        public void Add(IObserver<T> observer);
        public void Remove(IObserver<T> observer);
    }
}