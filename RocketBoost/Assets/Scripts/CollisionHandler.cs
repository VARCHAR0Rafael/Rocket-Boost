using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "FirstPoint":
                Debug.Log("This is the Starting point");
                break;
            case "Finish":
                Debug.Log("Level Complete");
                break;
            default:
                Debug.Log("You blew up");
                break;
        }
    }
}
