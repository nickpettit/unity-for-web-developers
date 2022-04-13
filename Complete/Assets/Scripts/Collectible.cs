using UnityEngine;

public class Collectible : MonoBehaviour
{
    float range = 0.4f;
    Vector3 m_startPosition;

    void Start()
    {
        m_startPosition = transform.position;
    }

    void OnTriggerStay(Collider other)
    {
        // If the other GameObject has a Score component, increment it
        other.gameObject.GetComponent<Score>().IncrementScore();

        // Move the position to a new random position within the board bounds
        transform.position = new Vector3(Random.Range(-range, range),
                                         transform.position.y,
                                         Random.Range(-range, range));
    }

    public void ResetPosition()
    {
        transform.position = m_startPosition;
    }
}
