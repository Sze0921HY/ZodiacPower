using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarStats : MonoBehaviour
{
    public float speed = 10f;
    public float scoreMultiplier = 1f;
    public float size = 1f;
    public float width = 1f;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //Testing Purpose
    public void OnLevelUp(InputValue value)
    {
        Debug.Log("Level Up");
    }

}
