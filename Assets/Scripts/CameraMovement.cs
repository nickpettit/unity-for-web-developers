using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Transform m_target;
    [SerializeField] Vector3 m_boardCenter;
    Vector3 m_offset;

    void Start()
    {
        // Calculate the offset at the start
        m_offset = transform.position - m_boardCenter;
    }

    void Update()
    {
        // Set the movement target to the target's position plus an X and Z offset.
        Vector3 target = new Vector3(m_target.position.x + m_offset.x,
                                     transform.position.y,
                                     m_target.position.z + m_offset.z);

        // Linearly interpolate the position from the current position to the target
        transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime);
    }
}
