using UnityEngine;

public class PointManager : MonoBehaviour
{
    public LevelManager LevelManager;
    public CarStats carStats;
    public float TotalPoint;

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
        checkPoint();
    }

    public void ExtraPoint_Egg()
    {
        TotalPoint += Extra_Egg;
    }

    public void ExtraPoint_Pig()
    {
        TotalPoint += Extra_Pig;
    }


    public void checkPoint()
    {
        if (TotalPoint >= 10) //10000)
        {
            LevelManager.updateTier(5);
        }
        else if (TotalPoint >= 7) //5000)
        {
            LevelManager.updateTier(4);
        }
        else if (TotalPoint >= 5) //1000)
        {
            LevelManager.updateTier(3);
        }
        else if (TotalPoint >= 3)//300)
        {
            LevelManager.updateTier(2);
        }
        else if (TotalPoint >= 2)//50)
        {
            LevelManager.updateTier(1);
        }
    }
}
