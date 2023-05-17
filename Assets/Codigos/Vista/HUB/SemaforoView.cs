using UnityEngine;

public class SemaforoView : MonoBehaviour
{
    public Light verde;
    public Light amarillo;
    public Light rojo;

    private void Start()
    {
        verde.enabled = false;
        amarillo.enabled = false;
        rojo.enabled = false;
    }

    public void EncenderVerde()
    {
        verde.enabled = true;
        amarillo.enabled = false;
        rojo.enabled = false;
    }

    public void EncenderAmarillo()
    {
        verde.enabled = false;
        amarillo.enabled = true;
        rojo.enabled = false;
    }

    public void EncenderRojo()
    {
        verde.enabled = false;
        amarillo.enabled = false;
        rojo.enabled = true;
    }
}