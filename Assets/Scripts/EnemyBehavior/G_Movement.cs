using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// apply this script to basic enemy types
// script does require you to set theiir movement paths

public class G_movements : MonoBehaviour
{
    public GameObject PointA;
    public GameObject PointB;
    private Rigidbody2D rb;
    private Animator anim;
    private Transform cPoint;
    public float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   //animations can be added in
        rb = GetComponent <Rigidbody2D>();
        //anim = GetComponent <Animator>();
        cPoint = PointB.transform;
        //anim.SetBool("isrunning", true);
    }

    // Update is called once per frame
    void Update()
    {
        //makes the enemy manuever based to where the points are
        Vector2 point = cPoint.position - transform.position;
        if(cPoint == PointB.transform)
        {
            rb.linearVelocity= new Vector2(speed, 0);

        }
        else
        {
            rb.linearVelocity = new Vector2(-speed, 0);
        }
        
        //switching directtions after reaching points(not working)
        if(Vector2.Distance(transform.position, cPoint.position) < .5f && cPoint == PointB.transform)
        {
            cPoint = PointA.transform;
        }
        if(Vector2.Distance(transform.position, cPoint.position) < .5f && cPoint == PointA.transform)
        {
            cPoint = PointB.transform;
        }

        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(PointA.transform.position, .5f);
        Gizmos.DrawWireSphere(PointB.transform.position, .5f);
        Gizmos.DrawLine(PointA.transform.position, PointB.transform.position);
    }
}
