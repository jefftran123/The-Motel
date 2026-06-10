using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    private float walkingSpeed = 3f;
    private float runninggSpeed = 5f;
    private float currentSpeed;

    [Header("Gravity Settings")]
    public float gravity = -9.81f;
    private Vector3 velocity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Moving();
        Running();
        HandlingGravity();
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

    void HandlingGravity()
    {
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
