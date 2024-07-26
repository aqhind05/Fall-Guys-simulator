using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class thirdPersonScript : MonoBehaviour
{
    public CharacterController controller;

    public Transform cam;

    //variables
    public float speed = 6f;

    public float turnSmoothTime = 0.1f;

    float turnSmoothVelocity;

    public float jumpForce = 10f;
    private float verticalVelocity = 0f;



    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            // Rotate the player towards the camera direction
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            // Move the player in the camera-relative direction
            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
    controller.Move(moveDirection.normalized* speed * Time.deltaTime);
}

// Handle jumping
bool isGrounded = CheckGround();
if (isGrounded && Input.GetButtonDown("Jump"))
{
    verticalVelocity = jumpForce;
}
else
{
    verticalVelocity -= 9.81f * Time.deltaTime; // Apply gravity
}

// Apply the vertical velocity
controller.Move(Vector3.up * verticalVelocity * Time.deltaTime);
    }

    private bool CheckGround()
{
    // Raycast downwards to check if the player is on the ground
    RaycastHit hit;
    if (Physics.Raycast(transform.position, Vector3.down, out hit, controller.height / 2 + 0.1f))
    {
        return true;
    }
    return false;
}
}

