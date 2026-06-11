using UnityEngine;
using TMPro;

public class PlayerInteract : MonoBehaviour
{
    [Header("References")]
    public Camera mainCamera;
    public TextMeshProUGUI promptText;
    public GameObject promptUI;

    [Header("Settings")]
    public float interactRange = 1f;

    void Update()
    {
        Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, interactRange))
        {
            if (hitInfo.collider.CompareTag("InteractableDoor"))
            {
                DoorController doorScript = hitInfo.collider.GetComponent<DoorController>();
                SetTextForDoor(doorScript.isOpen);
                promptUI.SetActive(true);

                if (Input.GetKeyDown(KeyCode.F))
                {
                    if (doorScript != null)
                    {
                        doorScript.ToggleDoor();
                    }
                }
            }
            else
            {
                promptUI.SetActive(false);
            }
        }
        else
        {
            promptUI.SetActive(false);
        }
    }

    void SetTextForDoor(bool isOpen)
    {
        if (isOpen)
        {
            promptText.SetText("F | Close door");
        } else
        {
            promptText.SetText("F | Open door");
        }
    }
}