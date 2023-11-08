using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenManager : MonoBehaviour
{
    private bool camUp;

    [Header("Objects and Components")]
    [SerializeField] private GameObject ViewCamera;
    [SerializeField] private GameObject GameWorldCamera;
    [SerializeField] private GameObject NoPostCamera;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource cameraFail;
    [SerializeField] private GameObject timothy;
    [SerializeField] private GameObject shark;
    [SerializeField] private SharkScript sharkScriptObj;
    [SerializeField] private CameraInfoScriptableObject camInfo;
    private Animator animator;
    
    [Header("Scripts")]
    [SerializeField] private LightManager lightManagerScript;
    [SerializeField] private PostProcessingManager PostProcessingManager;
    [SerializeField] private InGameCam inGameCam;
    [SerializeField] private NoiseMeter noiseMeter;
    [SerializeField] private CongregationScript congregationScript;

    private bool initialized;
    private bool lightBroken;

    //Governs whether you can take a picture
    private bool camActivatable;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetTrigger("Close_Cam");
        camUp = false;
        ViewCamera.SetActive(false);
        initialized = true;
        lightBroken = false;
        camActivatable = false;
        sharkScriptObj.sharkReset();
    }

    public void setLightBroken(bool status)
    {
        lightBroken = status;
    }

    // Update is called once per frame
    void Update()
    {
        if (!initialized) {return;}

        ViewCamera.SetActive(true);

        if (Input.GetMouseButtonDown(1)) 
        {
            checkMouse2Click();
        }
        if (Input.GetMouseButtonDown(0)) 
        {
            if (!camUp || !camActivatable) {return;}

            checkMouseClick();
        }
    }

    void checkMouse2Click()
    {
        if (!camUp) 
        {
            if (!lightBroken)
            {
                lightManagerScript.CameraLightLevelSet(0.25F);
            }
            NoPostCamera.SetActive(true);
            animator.SetTrigger("Open_Cam");
            camUp = true;
            inGameCam.blackOutScreen();
            return;
        }

        PostProcessingManager.CameraPostProcessingSet(false);
        inGameCam.blackOutScreen();
        animator.SetTrigger("Close_Cam");
        camActivatable = false;
        camUp = false;
        GameWorldCamera.SetActive(true);
    }

    void checkMouseClick()
    {
        if (congregationScript.getCongTriggered())
        {
            congregationScript.setCongregation(true);
        }
        if (sharkScriptObj.getSharkActive() && !(camInfo.getRotValues() > 15 && camInfo.getRotValues() < 91))
        {
            shark.SetActive(true);
            sharkScriptObj.summonShark();
        }
        inGameCam.blackOutScreen();
        noiseMeter.cameraNoise(true);
        PostProcessingManager.CameraPostProcessingSet(true);
        audioSource.Play();
        StartCoroutine(audPlay());
    }

    IEnumerator audPlay()
    {
        //Wait Until Sound has finished playing
        while (audioSource.isPlaying)
        {
            yield return null;
        }

        //Audio has finished playing, disable GameObject
        ViewCamera.SetActive(true);
        inGameCam.TakePicture();
        noiseMeter.cameraNoise(false);
        if (congregationScript.getCongTriggered())
        {
            //If the congregation has been triggered, wait 0.5 seconds, then put the cam down
            //Also disables the congregation before the camera is put down
            yield return new WaitForSeconds(0.5F);
            
            congregationScript.setCongregation(false);
            PostProcessingManager.CameraPostProcessingSet(false);
            inGameCam.blackOutScreen();

            cameraFail.Play();

            //Close the camera
            animator.SetTrigger("Close_Cam");
            camUp = false;
            congregationScript.setCongregationTriggered(false);
            GameWorldCamera.SetActive(true);
        }
        timothy.SetActive(false);
        shark.SetActive(false);
    }

    public void CamAwayFinished() 
    {
        if (!lightBroken)
        {
            lightManagerScript.CameraLightLevelSet(1F);
        }
        //lightManagementScript.LightsSet(true);
        NoPostCamera.SetActive(true);
        GameWorldCamera.SetActive(true);
    }

    public void CamUpFinished() 
    {
        camActivatable = true;
        GameWorldCamera.SetActive(false);
    }

    public void CamAwayStart()
    {
        GameWorldCamera.SetActive(true);
    }
}
