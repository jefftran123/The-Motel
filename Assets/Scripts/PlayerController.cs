using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    private float walkingSpeed = 3f;
    private float runninggSpeed = 5f;
    private float currentSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Moving();
        Running();
    }

    void Moving()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * currentSpeed * Time.deltaTime);
    }

    void Running()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = runninggSpeed;
        }
        else
        {
            currentSpeed = walkingSpeed;
        }
    }
}
