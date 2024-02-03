using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class NPCDialogue : MonoBehaviour
{
    [SerializeField] private GameObject _dialoguePanel;
    [SerializeField] private TMP_Text _dialogueText;
    [SerializeField] private bool _isPlayerCanMove;
    private MovementController _movementController;


    [SerializeField] private string[] _dialogueLines;
    private int currentLine = 0;

    [SerializeField] private float _letterSpeed = 0.05f;
    [SerializeField] private float DialogAwaitTime = 0.05f; 

    private void Start()
    {
        _dialoguePanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (_isPlayerCanMove == false && other.TryGetComponent<MovementController>(out MovementController movementController))
            {
                    _movementController = movementController;
                    _movementController.BlockMovement();
            }
            ShowDialogue();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HideDialogue();
        }
    }

    private void ShowDialogue()
    {
        _dialoguePanel.SetActive(true);
        StartCoroutine(DisplayDialogue());
    }

    private void HideDialogue()
    {
        _dialoguePanel.SetActive(false);
        StopAllCoroutines(); 
    }

    IEnumerator DisplayDialogue()
    {
        _dialogueText.text = ""; 
        foreach (char letter in _dialogueLines[currentLine].ToCharArray())
        {
            _dialogueText.text += letter;
            yield return new WaitForSeconds(_letterSpeed);
        }

     
        currentLine++;

        
        yield return new WaitForSeconds(2f);

        
        if (currentLine < _dialogueLines.Length)
        {
            StartCoroutine(DisplayDialogue()); 
        }
        else
        {
            HideDialogue();
            currentLine = 0;
            _movementController.PermitMovement();
        }
    }
}
