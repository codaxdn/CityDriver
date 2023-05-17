using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CambiarImagen : MonoBehaviour
{   
    public Button boton;
    public Image imagen;
    public Sprite imagenBajaPuntuacion;
    public Sprite imagenMediaPuntuacion;
    public Sprite imagenAltaPuntuacion;
    public Sprite imagenmuybaja;
    public Sprite bloqueado;
    public string Nivel;
    private int puntuacion;

    void Start()
    {

    }
    void Update()
    {
        if(boton.interactable == true)
        {
            if(PlayerPrefs.HasKey(Nivel))
            {
                puntuacion = PlayerPrefs.GetInt(Nivel);
                if (puntuacion >= 80)
                {
                    imagen.sprite = imagenAltaPuntuacion;
                }
                else if (puntuacion >= 40 && puntuacion < 80)
                {
                    imagen.sprite = imagenMediaPuntuacion;
                }
                else if (puntuacion >= 20 && puntuacion < 40)
                {
                    imagen.sprite = imagenBajaPuntuacion;
                }
                else
                {
                    imagen.sprite = imagenmuybaja;
                }
            }
            else
            {
                imagen.sprite = imagenmuybaja;
            }
        }
        else
        {
            imagen.sprite = bloqueado;
        }      
    }
}