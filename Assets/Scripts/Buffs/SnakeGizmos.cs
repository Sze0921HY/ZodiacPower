using UnityEngine;

public class SnakeGizmo : MonoBehaviour
{
    public float radius = 2f;

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);

        // optional: show targets
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        Gizmos.color = Color.yellow;

        foreach (GameObject e in enemies)
        {
            Vector3 diff = e.transform.position - transform.position;
            diff.y = 0;

            if (diff.sqrMagnitude <= radius * radius)
            {
                Gizmos.DrawLine(transform.position, e.transform.position);
            }
        }
    }
}