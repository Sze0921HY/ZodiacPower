using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "ZodiacBuff/Tiger")]
public class TigerBuff : Buff
{


    public override void Apply(CarStats stats)
    {
        if (!stats.Tiger.enabled)
        {
            stats.Tiger.enabled = true;
        }
    }
}
