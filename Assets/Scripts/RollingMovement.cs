using UnityEngine;

public class RollingMovement : MonoBehaviour
{
    [SerializeField] float m_speed = 15f;
    Rigidbody m_rigidbody;
    [HideInInspector] public Vector3 m_movementDirection;
    Vector3 m_startPosition;

    void Start()
    {
        // Gather components and variables that will be needed later
        m_rigidbody = GetComponent<Rigidbody>();
        m_startPosition = transform.position;
    }

    void FixedUpdate()
    {
        // Every physics tick, add a force equal to the movement vector multiplied by speed
        m_rigidbody.AddForce(m_movementDirection * m_speed);

        // If the Y position of the sphere is below the respawn height, reset its position
        if (transform.position.y <= GameManager.RespawnHeight)
            ResetPosition();
    }

    public void ResetPosition()
    {
        // Reset the velocity to zero and set the position back to start
        m_rigidbody.velocity = Vector3.zero;
        m_rigidbody.angularVelocity = Vector3.zero;
        transform.position = m_startPosition;
    }
}
