using UnityEngine.UI;
using UnityEngine;
using Game.Units;
using Patterns;
using TMPro;

namespace Game.UI.Displays
{
    public struct UIDisplayData
    {
        public Sprite Background;
        public string Title;
        public string Description;
    }

    public interface IUI_Display : IInitialization<UIDisplayData>, IView
    {
    }

    public abstract class UI_BaseDisplay : ViewController, IUI_Display
    {
        [field: SerializeField] public Image Background { get; private set; }
        [field: SerializeField] public TextMeshProUGUI Title { get; private set; }
        [field: SerializeField] public TextMeshProUGUI Description { get; private set; }

        private int _heshData = -1;

        public void Init(UIDisplayData data)
        {
            if (_heshData == -1)
            {
                Background.sprite = data.Background;
                Title.SetText(data.Title);
                Description.SetText(data.Description);
                _heshData = data.GetHashCode();
                return;
            }

            if (_heshData != data.GetHashCode())
            {
                Hide();
                Init(data);
            }
        }

        public bool TryShow(Transform item, float distance, LayerMask layer)
        {
            Collider[] collider = Physics.OverlapSphere(item.position, distance, layer);

            if (collider.Length > 0 && collider[0].TryGetComponent<Player>(out Player player) && Vector3.Distance(item.position, player.transform.position) <= distance)
            {
                Show();
                return true;
            }

            Hide();
            return false;
        }

        public override void Hide()
        {
            base.Hide();
            _heshData = -1;
            Background.sprite = null;
            Title.SetText(string.Empty);
            Description.SetText(string.Empty);
        }
    }
}