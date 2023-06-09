using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private bool started;
    private bool gameOver;

    private Rigidbody rb;

    public GameObject particle;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Start is called before the first frame update
    void Start()
    {
        started = false; //Actually by default it's set to false
        gameOver = false;
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
                
                GameManager.instance.StartGame();
            }
        }
        
        Debug.DrawRay(transform.position,Vector3.down,Color.red);

        if (!Physics.Raycast(transform.position, Vector3.down, 1f))
            //The output of this statement is a condition, if the raycast collide with the platform or not
        {
            gameOver = true;
            rb.velocity = new Vector3(0, -25f, 0); //The ball falls down when gameover

            Camera.main.GetComponent<CameraFollow>().gameOver = true;
            
            GameManager.instance.GameOver();
        }


        if (Input.GetMouseButtonDown(0) && !gameOver)
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

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Diamond")
        {
            GameObject particleTemp = Instantiate (particle, collider.gameObject.transform.position, Quaternion.identity) as GameObject;
            Destroy(collider.gameObject);
            Destroy(particleTemp, 1f);
        }
    }
}
