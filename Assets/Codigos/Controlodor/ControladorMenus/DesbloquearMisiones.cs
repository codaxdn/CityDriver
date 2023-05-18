using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DesbloquearMisiones : MonoBehaviour
{
    public Button[] NivelBoton;
    public string[] GuardadoBoton;
    

    void Start()
    {
        for(int i = 0; i < GuardadoBoton.Length; i++)
        {
            if (!PlayerPrefs.HasKey(GuardadoBoton[i]) || PlayerPrefs.GetInt(GuardadoBoton[i]) < 60)
            {
                if (i+1 < NivelBoton.Length)
                {
                    NivelBoton[i+1].interactable = false;
                }
            }
        }
    }
}