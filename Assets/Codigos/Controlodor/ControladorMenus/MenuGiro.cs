using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuGiro : MonoBehaviour
{
    [SerializeField] private GameObject menuGiroDerecha;
    [SerializeField] private GameObject menuGiroIzquierda;
    private float tiempoMenuDireccionesActivo = 0f;
    // Start is called before the first frame update
    void Start()
    {
        menuGiroDerecha.SetActive(false);
        menuGiroIzquierda.SetActive(false);        
    }

    // Update is called once per frame
    void Update()
    {
        if (menuGiroDerecha.activeInHierarchy || menuGiroIzquierda.activeInHierarchy)
        {
            // Aumenta el tiempo que el menú ha estado activo
            tiempoMenuDireccionesActivo += Time.deltaTime;

            // Si ha pasado más de 3 segundos, desactiva el menú de direcciones
            if (tiempoMenuDireccionesActivo >= 4f)
            {
                menuGiroDerecha.SetActive(false);
                menuGiroIzquierda.SetActive(false); 
                tiempoMenuDireccionesActivo = 0f;
            }
        }
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "GirarDerecha")
        {


            menuGiroDerecha.SetActive(true);
            tiempoMenuDireccionesActivo = 0f;

        }
        else if (col.gameObject.tag == "GirarIzquierda")
        {

            menuGiroIzquierda.SetActive(true);
            tiempoMenuDireccionesActivo = 0f;
            
        }
    }
}
