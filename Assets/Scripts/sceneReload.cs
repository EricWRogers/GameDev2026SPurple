using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.Collections;
using Unity.VectorGraphics;
using UnityEditor;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Jobs;
using System.Reflection.Emit;

public class sceneReload : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator anim;
    public GameObject pb;
    public GameObject bb;
    private Transform schoimp;
    private Transform spimp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent <Rigidbody2D>();
        schoimp = pb.transform;
        spimp = bb.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (schoimp.position.y < spimp.position.y )
        {
            SceneManager.LoadScene("Level 1");
            
        }
    }
}
