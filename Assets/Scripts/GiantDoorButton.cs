using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantDoorButton : MonoBehaviour
{
    [SerializeField] private Animator enormousDoor;
    public void buttonPressFinished()
    {
        enormousDoor.SetTrigger("OpenGiantDoor");
    }
}
