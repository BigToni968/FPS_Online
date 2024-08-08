using UnityEngine;
using Game.Units;
using Patterns;
using TMPro;

namespace Game.UI
{
    public interface IUI_WindowHint : IInitialization<IUnit>, IView, IUpdater
    {
        public Transform Target { get; }

        public void SetHint(string hint);
    }

    public class WindowHint : ViewController, IUI_WindowHint
    {
        [field: SerializeField] public TextMeshProUGUI Hint { get; private set; }
        [field: SerializeField] public Transform Target { get; private set; }

        public void Init(IUnit data)
        {
            Target = data.Transform;
        }

        public void SetHint(string hint)
        {
            Hint.SetText(hint);
        }

        public override void Hide()
        {
            base.Hide();
            Hint.SetText(string.Empty);
        }

        public void OnUpdate()
        {
            transform.LookAt(Target);
        }
    }
}