using UnityEngine;

public class Object : MonoBehaviour
{
    public ObjectEnum TierObject;
    public float Point;

    public float force = 10f;

    private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initializedPoint();


    }



    public void FlyAway(Vector3 hitDirection)
    {
        rb.linearVelocity = Vector3.zero; // optional reset

        rb.AddForce(hitDirection * force, ForceMode.Impulse);
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

