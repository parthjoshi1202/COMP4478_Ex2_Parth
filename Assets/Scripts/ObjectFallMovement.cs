//This script spawns the fish and bombs and detects collision using Box Collider 2D
//It uses Random coordinates to spawn them on various parts of the screen, every few seconds 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectFallMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject[] obstacle;

    private BoxCollider2D collide;
    float x1, x2;

    void Awake()
    {
        collide = GetComponent<BoxCollider2D> ();

        x1 = transform.position.x - collide.bounds.size.x / 2f;
        x2 = transform.position.x + collide.bounds.size.x / 2f;
    }

    void Start()
    {
        StartCoroutine(ObjectFall(1f));
    }

    IEnumerator ObjectFall(float time)
    {
        yield return new WaitForSecondsRealtime(time);

        Vector3 temp = transform.position;
        temp.x = Random.Range(x1, x2);

        Instantiate (obstacle[Random.Range(0, obstacle.Length)], temp, Quaternion.identity);

        StartCoroutine(ObjectFall(Random.Range(1f, 2f)));
    }
}
