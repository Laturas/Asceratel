using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManegement : MonoBehaviour
{
    // Static/non-animating light sources
    [SerializeField] private GameObject staticLights;

    // Pillar Lights at the beginning of the game
    [SerializeField] private GameObject lPillarLight1;
    [SerializeField] private GameObject lPillarLight2;
    [SerializeField] private GameObject lPillarLight3;

    [SerializeField] private GameObject rPillarLight1;
    [SerializeField] private GameObject rPillarLight2;
    [SerializeField] private GameObject rPillarLight3;

    // Door Light (In the graveyard)
    [SerializeField] private GameObject doorLight;

    /**
    * Call this function to turn off all light sources in the game. 
    */
    public void LightsSet(bool lightStatus)
    {
        staticLights.SetActive(lightStatus);

        lPillarLight1.SetActive(lightStatus);
        lPillarLight2.SetActive(lightStatus);
        lPillarLight3.SetActive(lightStatus);

        rPillarLight1.SetActive(lightStatus);
        rPillarLight2.SetActive(lightStatus);
        rPillarLight3.SetActive(lightStatus);

        doorLight.SetActive(lightStatus);
    }
}
