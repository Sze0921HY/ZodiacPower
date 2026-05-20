using UnityEngine;

public class Object : MonoBehaviour
{
    public ObjectEnum TierObject;
    public float Point;

    public float force = 0f;

    private Rigidbody rb;

    public bool isTouched;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initializedPoint();
        isTouched = false;

    }



    public void FlyAway(Vector3 hitDirection)
    {
        rb.linearVelocity = Vector3.zero; // optional reset

        rb.AddForce(hitDirection * force, ForceMode.Impulse);

        // Despawn after 3 seconds
        Destroy(gameObject, 3f);
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
                Point = 5;
                break;
            case ObjectEnum.Tier2:
                Point = 10;
                break;
            case ObjectEnum.Tier3:
                Point = 50;
                break;
            case ObjectEnum.Tier4:
                Point = 150;
                break;
            case ObjectEnum.Tier5:
                Point = 500;
                break;
            case ObjectEnum.Tier6:
                Point = 1000;
                break;
        }
    }
}

