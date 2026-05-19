using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ZodiacBuff/Monkey")]
public class MonkeyBuff: Buff
{
    public List<Buff> randomBuffs;

    public BuffManager buffManager;

    public override void Apply(CarStats stats)
    {
        int index = Random.Range(0, randomBuffs.Count);
        Buff buff = randomBuffs[index];

        buff.Apply(stats);

        stats.GetComponent<CarStats>().buffManager.HandleMonkey(buff);
    }
}
