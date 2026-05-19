using UnityEngine;

[CreateAssetMenu(menuName = "ZodiacBuff/Pig")]
public class PigBuff: Buff
{
    public PointManager pointManager;

    public override void Apply(CarStats stats)
    {
        stats.pointManager.ExtraPoint_Pig();
    }
}
