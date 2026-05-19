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

    [Header("Event Duration")]
    public float RoosterAbility = 5f;
    public float PigAbility = 5f;

    //Testing Purpose//
    private Vector2 moveInput;
    private Rigidbody rb;
    public UIManager UImanager;


    //Refereces
    public PointManager pointManager;
    public BuffManager buffManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Testing Purpose//
    private void FixedUpdate()
    {
        Vector3 move = new Vector3(moveInput.x, 0f, moveInput.y);
        rb.linearVelocity = new Vector3(move.x * speed, rb.linearVelocity.y, move.z * speed);
    }



    //Testing Purpose//
    public void OnLevelUp(InputValue value)
    {
        UImanager.showLevelUpPanel();
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

}
