using UnityEngine;

[CreateAssetMenu(menuName = "ZodiacBuff/Pig")]
public class PigBuff: Buff
{
    public override void Apply(CarStats stats)
    {
        Debug.LogWarning("Pig POWERRRR");
    }
}
