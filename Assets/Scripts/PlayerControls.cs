using UnityEngine.EventSystems;
using UnityEngine;
using TMPro;

public class NewBehaviourScript : MonoBehaviour
{
    private Camera cam;
    private TextMeshProUGUI promptText;

    public GameObject interactPrompt;
    void Start()
    {
        cam = Camera.main;
        promptText = interactPrompt.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 3))
        {
            InteractableObject interactable = hit.collider.GetComponent<InteractableObject>();

            if (interactable != null)
            {
                promptText.text = "press E to interact";

                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("We hit: " + hit.collider.name);
                    interactable.Interact();
                }
            }
            else
            {
                promptText.text = "";
            }


        }
        else
        {
            promptText.text = "";
        }
       


    }

}
