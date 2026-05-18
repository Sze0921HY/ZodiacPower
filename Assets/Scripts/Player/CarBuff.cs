using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBuff : MonoBehaviour
{
    public BuffManager buffManager;
    public CarStats stats;

    public List<Buff> UnlockedBuff;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UnlockedBuff = new List<Buff>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void AssignBuff(Buff buff)
    {
        UnlockedBuff.Add(buff);

    }
}
