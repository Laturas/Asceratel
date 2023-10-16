using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController _characterController;

    void Awake() => _characterController = GetComponent<CharacterController>();

    [Header("Player Movement")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float acceleration;
    [Header("Object Initialization")]
    [SerializeField] private Transform CameraOrientation;
    [SerializeField] private GameObject MoveTo;
    [SerializeField] private NoiseMeter noiseMeter;

    [SerializeField] private bool speederActive;

    float horizontalInput;

    Vector3 moveDirection;


    // Update is called once per frame
    void FixedUpdate()
    {
        // Welcome to if statement hell. Allow me to make it somewhat readable
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speederActive = true;
        } else 
        {
            speederActive = false;
        }
        if (Input.GetKey(KeyCode.W))
        {
            if (!speederActive) {
                if (moveSpeed <= 2F)
                {
                    moveSpeed = moveSpeed + acceleration;
                }
                if (moveSpeed >= 2F)
                {
                    moveSpeed = moveSpeed - acceleration;
                }
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            } else 
            {
                if (moveSpeed <= 4.5F)
                {
                    moveSpeed = moveSpeed + acceleration;
                }
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            }
        } 
        if (Input.GetKey(KeyCode.S))
        {
            if (!speederActive) {
                if (moveSpeed <= 2F)
                {
                    moveSpeed = moveSpeed + acceleration;
                }
                if (moveSpeed >= 2F)
                {
                    moveSpeed = moveSpeed - acceleration;
                }
            transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);
            } else 
            {
                if (moveSpeed <= 4.5F)
                {
                    moveSpeed = moveSpeed + acceleration;
                }
            transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);
            }
        }

        //Strafing
        if (Input.GetKey(KeyCode.D))
        {
            if (moveSpeed <= 2F)
            {
                moveSpeed = moveSpeed + acceleration;
            }
            if (moveSpeed >= 2F)
            {
                moveSpeed = moveSpeed - acceleration;
            }
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (moveSpeed <= 2F)
            {
                moveSpeed = moveSpeed + acceleration;
            }
            if (moveSpeed >= 2F)
            {
                moveSpeed = moveSpeed - acceleration;
            }
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
        
        //***Noise meter stuff***
        
        noiseMeter.speederMovement(speederActive);

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.W)) 
        {
            noiseMeter.normalMovement(true);
        }
        if ((Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.W)) 
        && !(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.W))) 
        {
            noiseMeter.normalMovement(false);
        }
    }
}
