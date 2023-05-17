using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MenuOpciones : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    public void PantallaCompleta(bool PantallaCompleta){

        Screen.fullScreen = PantallaCompleta;

    }


    public void CambiarVolumen(float volumen){

        audioMixer.SetFloat("Volumen", volumen);
    }

    public void CambiarCalidad(int index){
        int calidad = index + 1;

        QualitySettings.SetQualityLevel(calidad);

    }
}
