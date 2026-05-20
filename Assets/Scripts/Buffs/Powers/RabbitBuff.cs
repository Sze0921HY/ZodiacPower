using UnityEngine;

[CreateAssetMenu(menuName = "ZodiacBuff/Rabbit")]
public class RabbitBuff : Buff
{
    public float jump = 2;

    public override void Apply(CarStats stats)
    {
        stats.jump += jump;
    }
}
