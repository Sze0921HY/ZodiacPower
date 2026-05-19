using UnityEngine;

[CreateAssetMenu(menuName = "ZodiacBuff/Goat")]
public class GoatBuff: Buff
{
    public float extraForce = 10f;

    public override void Apply(CarStats stats)
    {
        stats.force += extraForce;
    }
}
