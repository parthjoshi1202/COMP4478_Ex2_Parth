//This script is for making the net move left and right using left and right arrow keys
//As well as to ensure the net does not go beyond the game screen
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class NetMovement : MonoBehaviour
{
    //setting speed of the net
    float speed = 10f;
    float minX, maxX;

    private Rigidbody2D net;

    void Awake()
    {
        net = GetComponent<Rigidbody2D> ();
    }

    //Start is called before the first frame update
    //Setting minimum and maximum coordinates
    void Start ()
    {
        Vector3 coord = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        minX = -coord.x + 1.8f;
        maxX = coord.x - 1.8f;
    }

    //Update is called once per frame
    //Setting minimum and maximum coordinates
    //Setting the velocity 
    void Update ()
    {
        Vector3 temp = transform.position;

        if(temp.x >  maxX)
            temp.x = maxX;

        if(temp.x < minX)
            temp.x = minX;

        transform.position = temp;

        Vector2 v = net.velocity;
        v.x = Input.GetAxis("Horizontal") * speed;
        net.velocity = v;
    }
}
