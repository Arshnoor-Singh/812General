using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    Vector2 movementValues;
    Vector2 mousePosition;

    public CinemachineVirtualCamera playerVirtualCamera;
    public float movementSpeed = 5f;
    public float interactionDistance = 10f;

    public void IAMovement(InputAction.CallbackContext context)
    {
        movementValues = context.ReadValue<Vector2>();
    }

    public void IAMouseLook(InputAction.CallbackContext context)
    {
        mousePosition = context.ReadValue<Vector2>();
        Debug.Log(mousePosition);
    }

    public void IAJump(InputAction.CallbackContext context)
    {

    }

    public void IAInteract(InputAction.CallbackContext context)
    {
        if(context.started == true)
        {
            Interact();
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(movementValues.x * movementSpeed * Time.deltaTime, 0, movementValues.y * movementSpeed * Time.deltaTime);
    }

    void Interact()
    {
        Debug.Log("Interaction Received");

        // Get the direction in which the player camera is looking and store that in a variable
        // The type of this variable will be a Vector3
        Vector3 playerCameraDirection = playerVirtualCamera.transform.forward;

        // Store the information about the ray being used in raycast in a variable
        // The type of this variable is Ray
        // A ray basically needs a point of origin and a direction
        Ray interactionRay = new Ray(playerVirtualCamera.transform.position, playerCameraDirection);

        // Store the data of whatever the ray hits in a variable
        // This variable will be of the type RaycastHit
        RaycastHit rayTargetInfo;

        // Using the information above, we will fire a ray and we will check if it hits something or not
        if (Physics.Raycast(interactionRay, out rayTargetInfo, interactionDistance))
        {
            // If the raycast hits something, draw a debug line in red color
            Debug.DrawLine(playerVirtualCamera.transform.position, playerVirtualCamera.transform.position + (playerCameraDirection * interactionDistance), Color.red, 2f);

            // Since the raycast has hit something, we can get the information about whatever was hit using the rayTargetInfo variable
            Debug.Log("Ray hit an object with the name " + rayTargetInfo.transform.name);
        }
        else
        {
            // If the raycast does not hit anything, draw a debug line in Green Color
            Debug.DrawLine(playerVirtualCamera.transform.position, playerVirtualCamera.transform.position + (playerCameraDirection * interactionDistance), Color.green, 2f);
        }
    }
}
