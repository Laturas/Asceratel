/*using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class ChangeVolumeComponent : MonoBehaviour
{
    [SerializeField] private Volume volume;
    [SerializeField] private ColorParameter lift;
    [SerializeField] private ColorParameter gamma;
    [SerializeField] private ColorParameter gain;

    void Start()
    {
        if (volume == null) 
        {
            volume = this.GetComponent<Volume>();
        }

        if (volume.profile == null) 
        {
            Debug.LogError("No Volume Profile assigned to the Volume Component");
            return;
        }

        if (lift == null || gamma == null || gain == null) 
        {
            Debug.LogError("One or more Color Parameters are missing");
            return;
        }

        var liftChannel = volume.profile.components[1];
        if (liftChannel != null) 
        {
            liftChannel = gamma.value;
        }
        Debug.Log(liftChannel);
    }

    void Update()
    {
    }
}*/