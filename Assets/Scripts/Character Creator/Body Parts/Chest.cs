using Unity.VisualScripting;
using UnityEngine;

public class Chest:MonoBehaviour
{
    [SerializeField] private int gold;
    private bool playerInTrigger;
    private PlayerInteraction _playerInteraction;

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.tag == "Player")
        {
            playerInTrigger = true;
            _playerInteraction = collider2D.gameObject.GetComponent<PlayerInteraction>();
        }
    }

    private void OnTriggerExit2D(Collider2D collider2D)
    {
        if (collider2D.tag == "Player")
        {
            playerInTrigger = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && playerInTrigger)
        {
            _playerInteraction.Take(gold);
            Destroy(this.gameObject);
        }
    }
}