//This script collects the fishes and bombs using a game object which were not picked up by the net
//So that these can be reused rather than wasting resources and generating new copies of the fish and bomb sprite 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollect : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "bomb" || target.tag == "fish")
            target.gameObject.SetActive(false);
    }
}
