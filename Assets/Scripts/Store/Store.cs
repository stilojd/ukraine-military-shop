using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.CharacterInventory;
using Assets.Scripts.CharacterInventory.Interfaces;
using Assets.Scripts.Scriptable_Objects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Store
{
    public class Store : MonoBehaviour
    {
        [SerializeField] private List<Clothes> _elements;
        [SerializeField] private Inventory _inventory;
        [SerializeField] private GameObject _elementButton;

        [SerializeField] private GameObject _warning;
        [SerializeField] private Transform _inventoryElements;

        [SerializeField] private Image _image;
        [SerializeField] private Button _buyButton;
        [SerializeField] private TMP_Text _description;

        private List<Clothes> _playerElementsForSale;

        private void Start()
        {
            LoadInventory();
        }

        private void Buy(IElement element)
        {
            if (_inventory.GetMoneyAmount() - element.Prise >= 0)
            {
                _inventory.Pay(element.Prise);
                _inventory.AddElement(element);
                return;
            }

            StartCoroutine(ShowWarning());
        }

        private IEnumerator ShowWarning()
        {
            _warning.SetActive(true);

            yield return new WaitForSeconds(2f);

            _warning.SetActive(false);
        }

        private void LoadInventory()
        {
            foreach (var element in _elements)
            {
                var button = Instantiate(_elementButton, _inventoryElements);
                button.GetComponent<ElementButton>().Construct(element, this);
            }
        }

        public void Select(IElement element)
        {
            UpdateElementInfo(element);
            AddListeners(element);
        }

        private void UpdateElementInfo(IElement element)
        {
            _image.sprite = element.Sprite;
            _description.text = (element.Name + "\nPrice: $" + element.Prise);
        }

        private void AddListeners(IElement element)
        {
            _buyButton.onClick.RemoveAllListeners();
            _buyButton.onClick.AddListener(() => Buy(element));
        }

        public void SwitchStoreUiState()
        {
            bool state = !this.gameObject.activeSelf;
            this.gameObject.SetActive(state);
            _inventory.SetSellFunction(state);
            _inventory.gameObject.SetActive(state);
        }

        public void Exit()
        {
            this.gameObject.SetActive(false);
            _inventory.SetSellFunction(false);
            _inventory.gameObject.SetActive(false);   
        }
    }
}