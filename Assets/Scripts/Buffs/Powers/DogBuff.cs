using UnityEngine;

[CreateAssetMenu(menuName = "ZodiacBuff/Dog")]
public class DogBuff: Buff
{
    public override void Apply(CarStats stats)
    {
        stats.Doggy.SetActive(true);
    }
}
