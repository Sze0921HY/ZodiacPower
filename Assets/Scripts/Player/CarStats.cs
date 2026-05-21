using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarStats : MonoBehaviour
{
    [Header("Zodiac References")]
    public GameObject Doggy;
    public GameObject Doggy2;
    public GameObject Dragon;
    public GameObject Rooster;
    public SphereCollider Tiger;

    [Header("Basic stats Duration")]
    public float speed = 10;
    public float scoreMultiplier =1;
    public float size = 1;
    public float width = 1;
    public float jump = 1;
    public float force =1;
    public float pullspeed = 1;
    public int maxPullNumber = 0;

    [Header("Event Duration")]
    public float RoosterAbility = 60f;
    public float PigAbility = 5f;

    public int currentIndex;


    public UIManager UImanager;


    //Refereces
    public PointManager pointManager;
    public BuffManager buffManager;
    public LevelManager levelManager;

    private void Awake()
    {

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentIndex = levelManager.CurrentTier;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Testing Purpose//
    private void FixedUpdate()
    {

    }

    public void updateIndex()
    {
        currentIndex++;
    }


/*    //Testing Purpose//
    public void OnLevelUp(InputValue value)
    {
        UImanager.showLevelUpPanel();
    }*/

}
