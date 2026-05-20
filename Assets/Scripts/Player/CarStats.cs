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
    public float RoosterAbility = 5f;
    public float PigAbility = 5f;


    public UIManager UImanager;


    //Refereces
    public PointManager pointManager;
    public BuffManager buffManager;

    private void Awake()
    {

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Testing Purpose//
    private void FixedUpdate()
    {

    }



    //Testing Purpose//
    public void OnLevelUp(InputValue value)
    {
        UImanager.showLevelUpPanel();
    }

}
