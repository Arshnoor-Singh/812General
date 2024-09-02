using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    Vector2 movementValues;
    Vector2 mousePosition;

    public CinemachineVirtualCamera playerVirtualCamera;
    public float movementSpeed = 5f;

    public void IAMovement(InputAction.CallbackContext context)
    {
        movementValues = context.ReadValue<Vector2>();
    }

    public void IAMouseLook(InputAction.CallbackContext context)
    {
        mousePosition = context.ReadValue<Vector2>();
    }

    public void IAJump(InputAction.CallbackContext context)
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(movementValues.x * movementSpeed * Time.deltaTime, 0, movementValues.y * movementSpeed * Time.deltaTime);
    }
}
