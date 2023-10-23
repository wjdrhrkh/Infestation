using UnityEngine;

public class Controlsky : MonoBehaviour
{
    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * 1.5f);
    }
}
