using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    [SerializeField] private float Xsensitivity;
    [SerializeField] private float Ysensitivity;
    [SerializeField] private SettingsScriptableObj settings;
    [SerializeField] private CameraInfoScriptableObject camInfo;
    [SerializeField] private Transform camTransform;

    private float xRotation;
    private float yRotation;
    
    // I made these public when I was dumb and didn't know the implications.
    // I'm scared to change them now though
    // I've grown as a person
    public float Xrot;
    public float Yrot;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        settings.updateSensitivity(500F);
    }

    // Update is called once per frame
    void Update()
    {
        SetSensitivity(settings.getSensitivity());

        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * Xsensitivity;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * Ysensitivity;
    
        yRotation += mouseX;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);

        camInfo.setRotValues(camTransform.rotation.eulerAngles.x);
    }

    public void SetSensitivity(float sensitive)
    {
        Xsensitivity = sensitive;
        Ysensitivity = sensitive;
    }
}
