using UnityEngine;

[CreateAssetMenu(menuName = "ZodiacBuff/Ox")]
public class OxBuff : Buff
{
    public float multiplier = 1.5f;

    public override void Apply(CarStats stats)
    {
        stats.width = stats.width * multiplier;

        stats.transform.localScale = new Vector3(stats.transform.localScale.x * stats.width, stats.transform.localScale.y, stats.transform.localScale.z);
    }
}
