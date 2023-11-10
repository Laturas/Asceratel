using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorSceneTrigger : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform elevatorTransform;
    [SerializeField] private float speed;
    [SerializeField] private ElevatorDoorScript elevatorDoor;

    private bool elevatorTriggered;

    private float acceleration;

    void Start() 
    { 
        elevatorTriggered = false; 
        acceleration = 0.01F;
    }

    // Update is called once per frame
    void Update()
    {
        if (elevatorTriggered)
        {
            if (acceleration <= 2)
            {
                acceleration += 0.01F;
            }
            playerTransform.Translate(Vector3.down * speed * Time.deltaTime * acceleration); 
            elevatorTransform.Translate(Vector3.down * speed * Time.deltaTime * acceleration);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        elevatorDoor.CloseDoor();
    }

    public void TriggerElevator()
    {
        elevatorTriggered = true;
    }

    public void DisableElevator()
    {
        elevatorTriggered = false;
        acceleration = 0.01f;
    }
}
