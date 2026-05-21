using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    public LevelManager LevelManager;
    public UIManager uiManager;
    public CarStats carStats;
    public float TotalPoint;
    public List<float> targetPoint;

    [Header("Extra Points")]
    public float Extra_Egg = 150;
    public float Extra_Pig = 50;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TotalPoint = 0;
 
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void addPoint(Object objectPoint)
    {
        TotalPoint = TotalPoint + objectPoint.Point * carStats.scoreMultiplier;
        Debug.LogWarning(carStats.scoreMultiplier);
        uiManager.updatePointUI(TotalPoint);
        uiManager.updateBar(objectPoint.Point);
        checkPoint();
    }

    public void ExtraPoint_Egg()
    {
        TotalPoint += Extra_Egg;
        uiManager.updatePointUI(TotalPoint);
        checkPoint();
    }

    public void ExtraPoint_Pig()
    {
        TotalPoint += Extra_Pig;
        uiManager.updatePointUI(TotalPoint);
        checkPoint();
    }


    public void checkPoint()
    {
        if (TotalPoint >= 10000 && LevelManager.CurrentTier < 5) //10000)
        {
            LevelManager.updateTier(5);
        }
        else if (TotalPoint >= 5000 && LevelManager.CurrentTier < 4) //5000)
        {
            LevelManager.updateTier(4);
        }
        else if (TotalPoint >= 1000 && LevelManager.CurrentTier < 3) //1000)
        {
            LevelManager.updateTier(3);
        }
        else if (TotalPoint >= 300 && LevelManager.CurrentTier < 2)//300)
        {
            LevelManager.updateTier(2);
        }
        else if (TotalPoint >= 20 && LevelManager.CurrentTier < 1)//50)
        {
            LevelManager.updateTier(1);
        }
    }
}
