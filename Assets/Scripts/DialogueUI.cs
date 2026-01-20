using UnityEngine;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    public static DialogueUI Instance;

    public TextMeshProUGUI dialogueText;
    public float dusplayTime = 3f;

    private void Awake()
    {
        Instance = this;
        dialogueText.text = "";
    }

    public void ShowText(string text)
    {
        StopAllCoroutines();
        StartCoroutine(ShowRoutine(text));
    }

    private System.Collections.IEnumerator ShowRoutine(string text)
    {
        dialogueText.text = text;
        yield return new WaitForSeconds(dusplayTime);
        dialogueText.text = "";
    }
}
