using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class BuffManager : MonoBehaviour
{
    public List<Buff> BuffList;
    public List<Buff> BuffPool;
    public List<Buff> offeredBuffList;

    public GameObject player;
    public UIManager UImanager;

    private CarStats carSats;
    private CarBuff carBuff;


    void Awake()
    {
        BuffPool = new List<Buff>(BuffList);
        offeredBuffList = new List<Buff>();
    }

    private void Start()
    {
        carSats = player.GetComponent<CarStats>();
        carBuff = player.GetComponent<CarBuff>();
    }


    public bool levelUp()
    {
        if (BuffPool.Count == 0)
        {
            Debug.Log("No more buffs available");

           

            return false;
        }

        shuffle();
        ThreeBuffs();
        return true;
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
            UImanager.AssignText(i, BuffPool[i]);
        }

        // Hide extra buttons
        UImanager.HideUnusedButtons(count);
    }

    // no longer a void method, now returns a bool to indicate success or failure of picking a buff
    public bool pickBuff(int index)
    {
        if (index < 0 || index >= offeredBuffList.Count)
        {
            Debug.LogError($"Invalid buff index: {index}");
            return false;
        }

        Buff buff = offeredBuffList[index];
        buff.Apply(carSats);
        Debug.Log($"Unlocked buff: {buff}");

        if (buff.isContinue)
        {
            switch (buff.CurrentBuff)
            {
                case BuffEnum.Rooster:
                    StartCoroutine(RepeatEventBuffDuration(buff, carSats.RoosterAbility));
                    break;

                case BuffEnum.Pig:
                    StartCoroutine(RepeatEventBuffDuration(buff, carSats.PigAbility));
                    break;
            }
        }

        carBuff.AssignBuff(buff);

        BuffPool.Remove(buff);

        offeredBuffList.Clear();

        UImanager.ResetUI();

        Time.timeScale = 1f;
        return true;
    }

    public void HandleMonkey(Buff buff)
    {

        switch (buff.CurrentBuff)
        {
            case BuffEnum.Rooster:
                StartCoroutine(RepeatEventBuffDuration(buff, carSats.RoosterAbility));
                break;

            case BuffEnum.Pig:
                StartCoroutine(RepeatEventBuffDuration(buff, carSats.PigAbility));
                break;
        }
    }

    //made a coroutine for the events cause egg was spamming hella
    private IEnumerator RepeatEventBuffDuration(Buff buff, float time)
    {
        while (true)
        {
            yield return new WaitForSeconds(time);

            Debug.Log($"{buff}, Duration: {time}");

            buff.Apply(carSats);
        }
    }
}