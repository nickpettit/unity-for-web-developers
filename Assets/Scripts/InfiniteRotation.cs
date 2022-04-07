using UnityEngine;

public class InfiniteRotation : MonoBehaviour
{
    [SerializeField] Vector3 m_axis;
    [SerializeField] float m_angle;

    void FixedUpdate()
    {
        transform.Rotate(m_axis, m_angle);
    }
}
