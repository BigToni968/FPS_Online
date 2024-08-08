using UnityEngine.EventSystems;
using Game.UI.Displays;
using UnityEngine;
using Zenject;

namespace Game.UI
{
    public class UI_Installer : MonoInstaller
    {
        [field: SerializeField] public EventSystem EventSystem { get; private set; }
        [field: SerializeField] public UI_Inventory Inventory { get; private set; }
        [field: SerializeField] public UI_BaseDisplay[] Displays { get; private set; }

        private IUI_Manager _UI_Manager;

        public override void InstallBindings()
        {
            _UI_Manager = new UI_Manager();
            _UI_Manager.Add(EventSystem);
            _UI_Manager.Add<IUI_Inventory>(Inventory);

            for (int i = 0; i < Displays.Length; i++)
            {
                _UI_Manager.Add(Displays[i]);
            }

            Container.BindInstance<IUI_Manager>(_UI_Manager).AsSingle();
        }

        private void OnDestroy()
        {
            for (int i = _UI_Manager.UIElements.Count - 1; i >= 0; i--)
            {
                _UI_Manager.Remove(_UI_Manager.UIElements[i]);
            }
        }
    }
}