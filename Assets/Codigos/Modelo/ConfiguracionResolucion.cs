using UnityEngine;

public class ConfiguracionResolucion : MonoBehaviour
{
    private void Start()
    {
        AdaptarResolucion();
    }

    private void AdaptarResolucion()
    {
        Resolution currentResolution = Screen.currentResolution;
        Screen.SetResolution(currentResolution.width, currentResolution.height, Screen.fullScreen);
    }
}