using UnityEngine;

[CreateAssetMenu(menuName = "ZodiacBuff/Horse")]
public class HorseBuff : Buff
{
    public float multiplier = 1.4f;

    public override void Apply(CarStats stats)
    {
        stats.speed *= multiplier;
    }
}