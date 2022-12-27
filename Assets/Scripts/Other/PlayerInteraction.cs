using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private GameObject _store;
    [SerializeField] private GameObject _inventory;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            _inventory.SetActive(!_inventory.gameObject.activeSelf);
        }
    }
}