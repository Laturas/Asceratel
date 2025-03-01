using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class InGameCam : MonoBehaviour
{
    [SerializeField] RawImage LastTakenImage;
    [SerializeField] RenderTexture CameraRT;
    [SerializeField] Camera LinkedCamera;
    [SerializeField] private PostProcessingManager postProcessingManager;
    [SerializeField] private Texture2D blackImage;

    Texture2D LastImage;
    // Start is called before the first frame update
    void Start()
    {
        LastImage = new Texture2D(CameraRT.width, CameraRT.height, CameraRT.graphicsFormat, UnityEngine.Experimental.Rendering.TextureCreationFlags.None);
        LastTakenImage.color = new Color(0, 0, 0);
        LastTakenImage.texture = blackImage;
    }

    public void TakePicture()
    {
        Graphics.CopyTexture(CameraRT, LastImage);
        LastTakenImage.color = new Color(1, 1, 1);
        LastTakenImage.texture = LastImage;
        postProcessingManager.CameraPostProcessingSet(false);
    }
    public void blackOutScreen()
    {
        LastTakenImage.color = new Color(0, 0, 0);
        LastTakenImage.texture = blackImage;
    }
}
