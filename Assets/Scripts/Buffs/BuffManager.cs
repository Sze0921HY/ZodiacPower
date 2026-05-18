using System.Collections.Generic;
using UnityEngine;

public class BuffManager : MonoBehaviour
{
    public List<Buff> BuffList;
    public List<Buff> offeredBuffList;
    public CarStats player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void levelUp()
    {
        
    }


    public void randomBuffs()
    {

    }

    public void pickBuff(Buff buff)
    {
        buff.Apply(player);
    }
}
