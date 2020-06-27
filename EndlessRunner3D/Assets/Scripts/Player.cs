using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float moveSpeed = 5f;

    Rigidbody rb;

    public float xLimit = 2.4f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {

        float h = Input.GetAxis("Horizontal");

        Vector3 movement = transform.right * h * moveSpeed;
        movement.y = rb.velocity.y;
        rb.velocity = movement;

        Vector3 curPos = transform.position;
        curPos.x = Mathf.Clamp(curPos.x,-xLimit,xLimit);
        transform.position = curPos;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            Debug.Log("Game Over");
        }else if (collision.gameObject.tag == "Ground")
        {
            //Enable Jump
        }
    }

}
