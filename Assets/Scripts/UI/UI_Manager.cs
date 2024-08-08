using System.Collections.Generic;
using System.Linq;
using System;

namespace Game.UI
{
    public interface IUI_Manager
    {
        public IReadOnlyList<object> UIElements { get; }

        public void Add<T>(T instance);
        public void Remove<T>(T instance);

        public T Get<T>() where T : class;
    }

    public class UI_Manager : IUI_Manager
    {
        public IReadOnlyList<object> UIElements => _uiElements;

        private List<object> _uiElements;

        public UI_Manager()
        {
            _uiElements = new(5);
        }

        public void Add<T>(T instance)
        {
            _uiElements.Add(instance);
        }

        public void Remove<T>(T instance)
        {
            _uiElements.Remove(instance);
        }

        public T Get<T>() where T : class
        {
            Type find = typeof(T);
            Type[] types = null;

            for (int i = 0; i < _uiElements.Count; i++)
            {
                if (find.Equals(_uiElements[i].GetType()) ||
                    ((types = _uiElements[i].GetType().GetInterfaces()).Length > 0 && types.Contains(find)))
                {
                    return _uiElements[i] as T;
                }
            }

            return null;
        }

    }
}