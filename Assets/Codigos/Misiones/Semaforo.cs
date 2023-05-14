using System.Collections;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Semaforo : MonoBehaviour
{
    public Light verde;
    public Light amarillo;
    public Light rojo;
    
    void Start()
    {
        StartCoroutine(CambiarSemaforo());
    }

    IEnumerator CambiarSemaforo()
    {
        while (true)
        {
            // Encender luz verde
            verde.enabled = true;
            amarillo.enabled = false;
            rojo.enabled = false;
            yield return new WaitForSeconds(10f);

            // Encender luz amarilla
            verde.enabled = false;
            amarillo.enabled = true;
            rojo.enabled = false;
            yield return new WaitForSeconds(2f);

            // Encender luz roja
            verde.enabled = false;
            amarillo.enabled = false;
            rojo.enabled = true;
            yield return new WaitForSeconds(10f);

            // Encender luz amarilla
            verde.enabled = false;
            amarillo.enabled = true;
            rojo.enabled = false;
            yield return new WaitForSeconds(2f);
        }
    }
}