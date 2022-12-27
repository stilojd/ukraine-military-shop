using UnityEngine;

namespace Assets.Scripts.Store
{
    public class StoreTrigger : MonoBehaviour
    {
        [SerializeField] private Store _store;
        [SerializeField] private GameObject _helper;
        
        private bool _playerInStore;

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.tag == "Player")
            {
                _playerInStore = true;
                _helper.SetActive(true);
            }
        }

        private void OnTriggerExit2D(Collider2D collider)
        {
            if (collider.tag == "Player")
            {
                _playerInStore = false;
                _store.Exit();
                _helper.SetActive(false);
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F) && _playerInStore)
            {
                _store.SwitchStoreUiState();
            }
        }
    }
}