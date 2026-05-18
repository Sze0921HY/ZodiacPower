using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Header("References")]
    public PointManager pointManger;

    [Header("Level Setting")]
    public int CurrentTier = 0;
    [SerializeField]
    private int MaxTier;
    public List<bool> TierBool;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MaxTier = 6;
        TierBool = new List<bool>();
        for (int i = 0; i < MaxTier; i++)
        {
            TierBool.Add(false);
        }

        updateTier(CurrentTier);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void updateTier(int index)
    {
        TierBool[index] = true;
    }
}
