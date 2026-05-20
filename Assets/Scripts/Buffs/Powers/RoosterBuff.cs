using UnityEngine;
using System.Collections;
using Unity.VisualScripting.Antlr3.Runtime.Misc;


[CreateAssetMenu(menuName = "ZodiacBuff/Rooster")]
public class RoosterBuff: Buff
{
    public GameObject eggsPrefab;
    public float spawnDuration;


   

    public override void Apply(CarStats stats)
    {
        SpawnEgg(stats);
    }
 

    public void SpawnEgg(CarStats stats)
    {
        GameObject eggInstance = Instantiate(eggsPrefab);

        eggInstance.transform.position = stats.Rooster.transform.position;
    }
}
