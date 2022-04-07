using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] Transform m_target;
    [SerializeField] float m_retargetingSpeed = 1f;

    RollingMovement m_rollingMovement;

    void Start()
    {
        m_rollingMovement = GetComponent<RollingMovement>();
    }

    void FixedUpdate()
    {
        Vector3 m_targetDirection = (m_target.position - transform.position);
        float retargetSpeed = Vector3.SqrMagnitude(m_targetDirection) < 0.1f ? 1000f : m_retargetingSpeed;
        m_rollingMovement.m_movementDirection = Vector3.Lerp(m_rollingMovement.m_movementDirection, m_targetDirection.normalized, Time.fixedDeltaTime * retargetSpeed);
    }
}
