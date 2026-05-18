using UnityEngine;

[CreateAssetMenu(menuName = "ZodiacBuff/Dragon")]
public class DragonBuff: Buff
{
    public override void Apply(CarStats stats)
    {
        stats.Dragon.SetActive(true);
    }
}
