using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MenuOpciones : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private UnityEngine.UI.Toggle pantallaCompletaToggle;
    [SerializeField] private UnityEngine.UI.Slider volumenSlider;

    private void Start()
    {
        // Establecer el estado del checkbox de pantalla completa basado en PlayerPrefs
        bool pantallaCompleta = PlayerPrefs.GetInt("PantallaCompleta", 0) == 1;
        pantallaCompletaToggle.isOn = pantallaCompleta;
        SetPantallaCompleta(pantallaCompleta);

        // Establecer el valor del volumen basado en PlayerPrefs
        float volumen = PlayerPrefs.GetFloat("Volumen", 0.5f);
        volumenSlider.value = volumen;
        CambiarVolumen(volumen);

        // Asignar el evento OnValueChanged al Toggle
        pantallaCompletaToggle.onValueChanged.AddListener(OnPantallaCompletaToggleChanged);
    }

    private void OnPantallaCompletaToggleChanged(bool value)
    {
        SetPantallaCompleta(value);
    }

    public void SetPantallaCompleta(bool pantallaCompleta)
    {
        // Establecer el modo de pantalla completa
        Screen.fullScreen = pantallaCompleta;

        // Guardar el estado en PlayerPrefs
        PlayerPrefs.SetInt("PantallaCompleta", pantallaCompleta ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void CambiarVolumen(float volumen)
    {
        // Ajustar el volumen usando el AudioMixer
        audioMixer.SetFloat("Volumen", volumen);

        // Guardar el valor del volumen en PlayerPrefs
        PlayerPrefs.SetFloat("Volumen", volumen);
        PlayerPrefs.Save();
    }

    public void CambiarCalidad(int index)
    {
        // Ajustar la calidad según el índice seleccionado
        int calidad = index;
        QualitySettings.SetQualityLevel(calidad);
    }
}