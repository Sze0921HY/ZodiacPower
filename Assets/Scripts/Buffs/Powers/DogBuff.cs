using UnityEngine;

[CreateAssetMenu(menuName = "ZodiacBuff/Dog")]
public class DogBuff: Buff
{
    public override void Apply(CarStats stats)
    {
        if (!stats.Doggy.activeSelf)
        {
            stats.Doggy.SetActive(true);
        }
        else
        {
            stats.Doggy2.SetActive(true);
        }
    }
}
