using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private bool started;

    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Start is called before the first frame update
    void Start()
    {
        started = false; //Actually by default it's set to false
    }

    // Update is called once per frame
    void Update()
    {
        if (!started)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb.velocity = new Vector3(speed, 0, 0);
                started = true;
            }
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            SwitchDirection();
        }
    }

    void SwitchDirection()
    {
        if (rb.velocity.z > 0)
        {
            rb.velocity = new Vector3(speed, 0, 0);
        }
        else if (rb.velocity.x > 0)
        {
            rb.velocity = new Vector3(0, 0, speed);
        }
    }
}
