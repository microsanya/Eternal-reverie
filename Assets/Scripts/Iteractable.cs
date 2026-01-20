using UnityEngine;

public class Iteractable : MonoBehaviour
{
    [TextArea(2, 5)]
    public string interactionText;

    public InteractionHint hint;
    public Transform interactionPoint;

    public void Start()
    {
        if (hint != null)
        {
            hint.gameObject.SetActive(false);
        }
    }

    public void ShowHint()
    {
        hint.target = interactionPoint;
        hint.gameObject.SetActive(true);
    }

    public void HideHint()
    {
        hint.gameObject.SetActive(false);
    }
    public void Interact()
    {
        DialogueUI.Instance.ShowText(interactionText);
    }
}
