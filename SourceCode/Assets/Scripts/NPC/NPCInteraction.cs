using System;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private NPCDialogue dialogueToShow;
    [SerializeField] private GameObject interactionBox;

    public NPCDialogue DialogueToShow => dialogueToShow;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DialogueController.Instance.NPCSelected = this;
            interactionBox.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DialogueController.Instance.NPCSelected = null;
            DialogueController.Instance.CloseDialoguePanel();
            interactionBox.SetActive(false);
        }
    }
}