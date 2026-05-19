using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarStats : MonoBehaviour
{
    [Header("Zodiac References")]
    public GameObject Doggy;
    public GameObject Dragon;
    public GameObject Rooster;

    [Header("Basic stats Duration")]
    public float speed = 10f;
    public float scoreMultiplier = 1f;
    public float size = 1f;
    public float width = 1f;
    public float jump = 1f;
    public float force = 1f;

    [Header("Event Duration")]
    public float RoosterAbility = 5f;
    public float PigAbility = 5f;


    public UIManager UImanager;


    //Refereces
    public PointManager pointManager;
    public BuffManager buffManager;

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
