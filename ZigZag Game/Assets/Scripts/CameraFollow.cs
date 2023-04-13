using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject ball;

    private Vector3 offset; //Distance between the camera and the ball

    public float lerpRate; //To make the camera movement smoother 

    [HideInInspector]
    public bool gameOver;
    void Start()
    {
        offset = ball.transform.position - transform.position;
        //position of the ball - position of the camera
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            Follow();
        }
    }

    void Follow()
    {
        Vector3 pos = transform.position;
        Vector3 targetpos =ball.transform.position - offset;
        pos = Vector3.Lerp(pos, targetpos, lerpRate * Time.deltaTime);
        transform.position = pos;
    }
}
