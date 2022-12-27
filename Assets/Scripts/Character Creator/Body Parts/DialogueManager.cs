using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private TMP_Text _answerText;
    [SerializeField] private GameObject _dialogueWindow; 
    private Queue<string> _sentences;

    private void Start()
    {
        _sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        _dialogueWindow.SetActive(true);
        Debug.Log("Start dialogue with: "+dialogue.name);
        _sentences.Clear();
        foreach (var sentence in dialogue.sentences)
        {
            _sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (_sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = _sentences.Dequeue();
        _text.text = sentence;

        DisplayAnswerSentence();
        Debug.Log(sentence);
    }

    private void DisplayAnswerSentence()
    {
        if (_sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = _sentences.Dequeue();
        _answerText.text = sentence;
    }

    public void EndDialogue()
    {
        _dialogueWindow.SetActive(false);
        Debug.Log("End dialogue");
    }
}