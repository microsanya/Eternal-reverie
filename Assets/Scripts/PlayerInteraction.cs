using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{

    private Iteractable currentInteractable;

    void Update()
    {
        if (currentInteractable != null && Input.GetKeyDown(KeyCode.E))
        {
            currentInteractable.Interact();
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("interactable"))
        {
            currentInteractable = other.GetComponent<Iteractable>();
            currentInteractable.ShowHint();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("interactable"))
        {
            return;
        }

        Iteractable interactable = other.GetComponent<Iteractable>();

        if (interactable != null && interactable == currentInteractable)
        {
            interactable.HideHint();
            currentInteractable = null;
        }
    }
}
