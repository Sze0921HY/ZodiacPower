using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "ZodiacBuff/Snake")]
public class SnakeBuff : Buff
{
    public float radius = 2f;
    public float pullSpeed = 0.00001f;
    public float duration = 2f;

    public int maxPullNumber = 2;

    public override void Apply(CarStats stats)
    {
        stats.StartCoroutine(PullRoutine(stats));
    }

    IEnumerator PullRoutine(CarStats stats)
    {
        float r2 = radius * radius;

        while (true)
        {
            Collider[] hits = Physics.OverlapSphere(stats.transform.position, radius);

            int pulledCount = 0;

            foreach (Collider hit in hits)
            {
                //if it's not enemy
                if (!hit.CompareTag("Enemy")) continue;

                Object obj = hit.GetComponent<Object>();

                if (!(obj.TierObject == ObjectEnum.Tier1 || obj.TierObject == ObjectEnum.Tier2 || obj.TierObject == ObjectEnum.Tier3)) continue;


                //if it doesn't have rigidbody
                if (hit.attachedRigidbody == null) continue;


                //if already pulled 2 objects
                if (pulledCount >= maxPullNumber)
                    break;

                Debug.LogWarning(hits);
                Vector3 dir = stats.transform.position - hit.transform.position;
                dir.y = 0;

                hit.attachedRigidbody.AddForce(
                    dir.normalized * pullSpeed,
                    ForceMode.Acceleration
                );

                pulledCount++;
            }

            yield return null;
        }
    }
}