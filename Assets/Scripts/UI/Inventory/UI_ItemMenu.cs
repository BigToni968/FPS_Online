using System.Collections.Generic;
using Game.Invetorys.Items;
using System.Collections;
using UnityEngine;
using Patterns;
using TMPro;

namespace Game.UI
{
    public class UI_ItemMenu : ViewController, IInitialization<(IItem Item, Vector3 newPos)>
    {
        [SerializeField] private TMP_Dropdown _dropdown;

        private void Start()
        {
            TMP_Dropdown.OptionDataList list = new();
            list.options.Add(new TMP_Dropdown.OptionData("Execute", null));
            list.options.Add(new TMP_Dropdown.OptionData("Drop", null));
            _dropdown.ClearOptions();
            _dropdown.AddOptions(list.options);
        }

        public void Init((IItem Item, Vector3 newPos) data)
        {
            transform.localPosition = data.newPos;
        }
    }
}