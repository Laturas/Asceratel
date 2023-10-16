using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LostCamera : MonoBehaviour
{
    [SerializeField] private GameObject lostCam;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            lostCam.SetActive(false);
        }
    }
}
