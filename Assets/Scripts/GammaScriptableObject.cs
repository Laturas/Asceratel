using UnityEngine;

[CreateAssetMenu(fileName = "GammaScriptableObject", menuName = "ScriptableObjects/Gamma")] 
public class GammaScriptableObject : ScriptableObject
{
    [SerializeField] private float gamma = 1.0F;

    public float getGammaLevel()
    {
        return gamma;
    }
}
