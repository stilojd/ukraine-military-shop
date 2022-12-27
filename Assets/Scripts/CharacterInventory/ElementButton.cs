using Assets.Scripts.CharacterInventory.Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.CharacterInventory
{
    [SerializeField]
    public class ElementButton : Button
    {
        [SerializeField] private Image _image;
        [SerializeField] private TMP_Text _prise;

        public void Construct(IElement element, Inventory inventory)
        {
            SetButtonInfo(element);
            this.onClick.AddListener(() => inventory.Select(element, this.gameObject));
        }

        public void Construct(IElement element, Store.Store store)
        {
            SetButtonInfo(element);
            this.onClick.AddListener(() => store.Select(element));
        }

        private void SetButtonInfo(IElement element)
        {
            _image.sprite = element.Sprite;
            _prise.text = element.Prise.ToString();
        }
    }
}