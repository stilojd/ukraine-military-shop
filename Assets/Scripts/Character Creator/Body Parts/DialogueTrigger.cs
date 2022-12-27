using UnityEngine;

public class DialogueTrigger: MonoBehaviour
{
    public Dialogue Dialogue;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(Dialogue);
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.tag == "Player")
        {
            TriggerDialogue();
        }
    }

    private void OnTriggerExit2D(Collider2D collider2D)
    {
        if (collider2D.tag == "Player")
        {
            FindObjectOfType<DialogueManager>().EndDialogue();
        }
        
    }
}