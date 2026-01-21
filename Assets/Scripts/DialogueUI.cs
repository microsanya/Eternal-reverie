using UnityEngine;
using TMPro;
using System.Collections;

public class DialogueUI : MonoBehaviour
{
    public static DialogueUI Instance;

    public TextMeshProUGUI dialogueText;
    public float letterDelay = 0.04f;

    private Coroutine typingCoroutine;
    private string currentText;
    private bool isTyping;
    private bool isOpen;

    //public float dusplayTime = 3f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        // Instance = this;
        dialogueText.text = "";
        dialogueText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (!isOpen)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isTyping)
            {
                SkipTyping();
            }
            else
            {
                Close();
            }
        }
    }

    public void ShowText(string text)
    {
        if (isOpen)
        {
            Close();
        }
        
        currentText = text;
        isOpen = true;
        dialogueText.gameObject.SetActive(true);
        typingCoroutine = StartCoroutine(TypeText());
        //StopAllCoroutines();
        //StartCoroutine(ShowRoutine(text));
    }

    IEnumerator TypeText()
    {
        isTyping = true;
        dialogueText.text = "";

        foreach (char letter in currentText)
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(letterDelay);
        }

        isTyping = false;
    }

    void SkipTyping()
    {
        //if (typingCoroutine != null)
        //{
            StopCoroutine(typingCoroutine);
        //}

        dialogueText.text = currentText;
        isTyping = false;
    }

    void Close()
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }
        dialogueText.text = "";
        dialogueText.gameObject.SetActive(false);
        isTyping = false;
        isOpen = false;
    }
    //private System.Collections.IEnumerator ShowRoutine(string text)
    //{
    //    dialogueText.text = text;
    //    //yield return new WaitForSeconds(dusplayTime);
    //    dialogueText.text = "";
    //}
}
