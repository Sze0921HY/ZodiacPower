using UnityEngine;

public class Object : MonoBehaviour
{
    public ObjectEnum TierObject;
    private float Point;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initializedPoint();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void initializedPoint()
    {
        switch (TierObject)
        {
            case ObjectEnum.Tier1:
                Point = 1;
                break;
            case ObjectEnum.Tier2:
                Point = 5;
                break;
            case ObjectEnum.Tier3:
                Point = 10;
                break;
            case ObjectEnum.Tier4:
                Point = 15;
                break;
            case ObjectEnum.Tier5:
                Point = 50;
                break;
            case ObjectEnum.Tier6:
                Point = 100;
                break;
        }
    }
}

