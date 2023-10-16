using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        Graphics.CopyTexture(blackImage, LastImage);
        LastTakenImage.texture = blackImage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakePicture()
    {
        Graphics.CopyTexture(CameraRT, LastImage);
        LastTakenImage.texture = LastImage;
        postProcessingManager.CameraPostProcessingSet(false);
    }
    public void blackOutScreen()
    {
        Graphics.CopyTexture(blackImage, LastImage);
        LastTakenImage.texture = blackImage;
    }
}
