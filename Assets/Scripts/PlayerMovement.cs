using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController _characterController;
    private Rigidbody rb;

    [Header("Player Movement")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float acceleration;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float speederBoost;
    [Header("Object Initialization")]
    [SerializeField] private Transform CameraOrientation;
    [SerializeField] private NoiseMeter noiseMeter;

    private bool speederActive;
    float horizontalInput;
    Vector3 moveDirection;
    Vector3 playerDirection = Vector3.zero;

    void Awake() 
    {
        _characterController = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        speederActive = (Input.GetKey(KeyCode.LeftShift));
        move();
        
        //***Noise meter stuff***
        noiseMeter.speederMovement(speederActive);

        noiseMeter.normalMovement((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.W)));
        
        if ((Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.W)) 
        && !(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.W))) 
        {
            noiseMeter.normalMovement(false);
        }
    }

    void move()
    {
        Vector3 dir = Direction();
        dir = dir.normalized * acceleration;
        if (speederActive) {dir *= speederBoost;}

        if (Mathf.Abs(rb.velocity.magnitude) <= maxSpeed)
        {
            rb.AddForce(dir, ForceMode.Acceleration);
        }
    }

    // This gets the direction the player is inputting in, and returns that direction.
    private Vector3 Direction()
    {
        Vector3 hAxis = Vector3.zero;
        Vector3 vAxis = Vector3.zero;
        if (Input.GetKey(KeyCode.W)) {hAxis += Vector3.forward;}
        if (Input.GetKey(KeyCode.S)) {hAxis += Vector3.back;}
        if (Input.GetKey(KeyCode.A)) {vAxis += Vector3.left;}
        if (Input.GetKey(KeyCode.D)) {vAxis += Vector3.right;}
        Vector3 direction = hAxis + vAxis;
        moveDirection = direction;

        return rb.transform.TransformDirection(direction);
    }
}
