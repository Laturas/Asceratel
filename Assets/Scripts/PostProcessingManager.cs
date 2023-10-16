using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostProcessingManager : MonoBehaviour
{
    [SerializeField] private GameObject PostProcessing;
    [SerializeField] private GameObject CameraPostProcessing;
    [SerializeField] private GameObject CameraGammaLight;

    [SerializeField] private GammaScriptableObject gammaScriptableObject;
    [SerializeField] private float currentGamma;

    // Start is called before the first frame update
    void Start()
    {
        // Default post processing effects. Turns out the lights too.
        PostProcessing.SetActive(false);
        PostProcessing.SetActive(true);
        CameraPostProcessing.SetActive(false);
        CameraGammaLight.SetActive(false);
    }

    /* This script activates and deactivates the post processing effects. 
    true = funky post processing | false = funky post processing is set to off */
    public void CameraPostProcessingSet(bool status)
    {
        PostProcessing.SetActive(!status);
        CameraPostProcessing.SetActive(status);
        CameraGammaLight.SetActive(status);
    }
}
