using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desctructor : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            Destroy(collision.gameObject);
        }
    }

}
