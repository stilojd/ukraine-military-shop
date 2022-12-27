using Assets.Scripts.Other;
using UnityEngine;

namespace Assets.Scripts.CharacterInventory
{
    public class ChestTrigger : MonoBehaviour
    {
        [SerializeField] private int _gold;
        [SerializeField] private GameObject _helper;

        private PlayerInteraction _playerInteraction;
        private bool _playerInTrigger;

        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (collider2D.tag == "Player")
            {
                _helper.SetActive(true);
                _playerInTrigger = true;
                _playerInteraction = collider2D.gameObject.GetComponent<PlayerInteraction>();
            }
        }

        private void OnTriggerExit2D(Collider2D collider2D)
        {
            if (collider2D.tag == "Player")
            {
                _helper.SetActive(false);
                _playerInTrigger = false;
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F) && _playerInTrigger)
            {
                _playerInteraction.Take(_gold);
                Destroy(this.gameObject);
            }
        }
    }
}