using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//script to rush at the player's current location
public class RMovementScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private Transform cPoint;
    public float speed;

    public GameObject P_point;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent <Rigidbody2D>();

        cPoint = P_point.transform;
    }

    // Update is called once per frame
    void Update()
    {


    }
}
