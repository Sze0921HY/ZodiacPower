using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffManager : MonoBehaviour
{
    public List<Buff> BuffList;
    public List<Buff> BuffPool;
    public List<Buff> offeredBuffList;

    public CarStats player;
    public UIManager UImanager;

    void Awake()
    {
        BuffPool = new List<Buff>(BuffList);
        offeredBuffList = new List<Buff>();
    }

    private void Start()
    {

    }


    public void levelUp()
    {
        shuffle();
        ThreeBuffs();
    }


    public void shuffle()
    {
        for (int i = 0; i < BuffPool.Count; i++)
        {
            int randomIndex = Random.Range(i, BuffPool.Count);

            Buff temp = BuffPool[i];
            BuffPool[i] = BuffPool[randomIndex];
            BuffPool[randomIndex] = temp;
        }
    }

    public void ThreeBuffs()
    {
        offeredBuffList.Clear();

        int count = Mathf.Min(3, BuffPool.Count);

        for (int i = 0; i < count; i++)
        {
            offeredBuffList.Add(BuffPool[i]);
            UImanager.AssignText(BuffPool[i]);
        }
    }

    public void pickBuff(int index)
    {
        Buff buff = offeredBuffList[index];

        buff.Apply(player);

        BuffPool.Remove(buff);

        //Debug.Log(offeredBuffList[index]);

        offeredBuffList.Clear();
        UImanager.ResetUI();
    }
}