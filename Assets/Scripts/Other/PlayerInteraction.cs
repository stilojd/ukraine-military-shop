using Assets.Scripts.CharacterInventory;
using UnityEngine;

namespace Assets.Scripts.Other
{
    public class PlayerInteraction : MonoBehaviour
    {
        [SerializeField] private GameObject _store;
        [SerializeField] private Inventory _inventory;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                _inventory.gameObject.SetActive(!_inventory.gameObject.activeSelf);
            }
        }

        public void Take(int money)
        {
            _inventory.AddMoney(money);
        }
    }
}