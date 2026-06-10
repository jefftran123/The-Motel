using UnityEngine;
using TMPro;

public class PlayerInteract : MonoBehaviour
{
    [Header("References")]
    public Camera mainCamera;
    public GameObject promptUI;

    [Header("Settings")]
    public float interactRange = 2f;

    void Update()
    {
        Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, interactRange))
        {
            if (hitInfo.collider.CompareTag("InteractableDoor"))
            {
                promptUI.SetActive(true);

                if (Input.GetKeyDown(KeyCode.F))
                {
                    
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
}