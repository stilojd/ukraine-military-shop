using Unity.VisualScripting;
using UnityEngine;

public class StoreTrigger : MonoBehaviour
{
    [SerializeField] private Store _store;
    private bool _playerInStore;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            _playerInStore = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            _playerInStore = false;
            _store.Exit();
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