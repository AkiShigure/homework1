using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPMovement : MonoBehaviour
{
    public float speed = 3f;
    Rigidbody rbody;
    private Transform characterTransform;
    private bool isGround;
    public float gravity;
    public float jumpHeight;
    private AudioSource footPlayer;
    
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        characterTransform = transform;
        footPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGround)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                var currentVelocity = rbody.velocity;
                rbody.velocity = new Vector3(currentVelocity.x, CalculateJumpHeightSpeed(), currentVelocity.z);
            }
        }
        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");
        if ((Horizontal != 0 || Vertical != 0)&&isGround)
        {
            if (footPlayer.isPlaying == false)
            {
                footPlayer.Play();
            }
        }
        else
        {
            footPlayer.Stop();
        }
    }
    
    private void FixedUpdate()
    {
        if (isGround)
        {
            float moveX = Input.GetAxis("Horizontal");
            float moveY = Input.GetAxis("Vertical");
            var currentDirection = new Vector3(moveX, 0, moveY);
            currentDirection = characterTransform.TransformDirection(currentDirection);
            currentDirection *= speed;
            var currentVelocity = rbody.velocity;
            var velocityChange = currentDirection - currentVelocity;
            velocityChange.y = 0;

            rbody.AddForce(velocityChange, ForceMode.VelocityChange);

           
        }

        rbody.AddForce(new Vector3(0, -gravity *rbody.mass, 0));

    }

    private float CalculateJumpHeightSpeed()
    {
        return Mathf.Sqrt(2 * jumpHeight * gravity);
    }

    private void OnCollisionStay(Collision collision)
    {
        isGround = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        isGround = false;
    }
}
