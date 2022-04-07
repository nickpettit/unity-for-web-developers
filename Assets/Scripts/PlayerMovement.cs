using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    RollingMovement m_rollingMovement;

    void Start()
    {
        m_rollingMovement = GetComponent<RollingMovement>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 movement = context.ReadValue<Vector2>();
        m_rollingMovement.m_movementDirection = new Vector3(movement.x, 0f, movement.y);
    }
}
