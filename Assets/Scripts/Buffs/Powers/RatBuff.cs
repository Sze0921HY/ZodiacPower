using UnityEngine;

[CreateAssetMenu(menuName = "ZodiacBuff/Rat")]
public class RatBuff : Buff
{
    public float multiplier = 1.2f;

    public override void Apply(CarStats stats)
    {
        stats.scoreMultiplier *= multiplier;
    }
}