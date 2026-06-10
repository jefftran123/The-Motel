using UnityEngine;

public class DoorController : MonoBehaviour
{
    public bool isOpen;

    [Header("Rotation Angles")]
    public float openAngle = 90f;
    public float smoothSpeed = 3f;

    private Quaternion closedRotation;
    private Quaternion openRotation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateStatus();
        openRotation = Quaternion.Euler(0, openAngle, 0);
        closedRotation = Quaternion.Euler(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        OpenOrCloseDoor();
    }

    void UpdateStatus()
    {
        float currentLocalY = transform.localEulerAngles.y;

        if (Mathf.Abs(currentLocalY) > Mathf.Abs(openAngle) / 2f)
        {
            isOpen = true;
        }
        else
        {
            isOpen = false;
        }
    }

    void OpenOrCloseDoor()
    {
        if (isOpen)
        {
            transform.localRotation = Quaternion.Slerp(transform.localRotation, openRotation, Time.deltaTime * smoothSpeed);
        }
        else
        {
            transform.localRotation = Quaternion.Slerp(transform.localRotation, closedRotation, Time.deltaTime * smoothSpeed);
        }
    }

    public void ToggleDoor()
    {
        isOpen = !isOpen;
    }
}
