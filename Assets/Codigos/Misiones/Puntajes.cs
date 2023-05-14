using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Puntajes : MonoBehaviour
{
    [SerializeField] private string Nivel;
    [SerializeField] private int limiteVelocidad;
    [SerializeField] private GameObject menuVelocidad;
    [SerializeField] private GameObject menuDireccionales;
    [SerializeField] private GameObject menuSemaforos;
    [SerializeField] private GameObject menuLuces;
    
    private float tiempoUltimaDisminucion = 0f;
    private int Puntaje = 100;
    private int PuntajeNivel;

    //FinNivel
    public AudioListener audioListener;
    public GameObject menuFin;
    public GameObject objeto;
    public Light LuzSemaforoRoja;
    public Light LuzCoche;
    //

    public GameObject DireccionalDerecha;
    public GameObject DireccionalIzquierda;
    public int puntajeNivelGuardado;

    private float tiempoMenuDireccionesActivo = 0f;
    private float tiempoMenuDireccionesActivoSemaforo = 0f;
    private float tiempoMenuLuces = 0f;

    
    [SerializeField] private Rigidbody rb;
    [SerializeField] public TMP_Text TextoPuntaje;

    //Velocidad
    [Header("UI")]
    private float speed = 0.0f;

    //Fin Velocidad

    // Start is called before the first frame update
    void Start()
    {
        PuntajeNivel = 100;

        menuFin.SetActive(false);
        menuDireccionales.SetActive(false);
        menuSemaforos.SetActive(false);
        menuLuces.SetActive(false);


        menuVelocidad.SetActive(false);
        
        if(PlayerPrefs.HasKey(Nivel))
        {
            puntajeNivelGuardado = PlayerPrefs.GetInt(Nivel);
        }
        else
        {
            puntajeNivelGuardado = 0;
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        TextoPuntaje.text = Puntaje.ToString();
        LimiteVelocidad();

        // Verifica si el menú de direcciones está activo
        if (menuDireccionales.activeInHierarchy)
        {
            // Aumenta el tiempo que el menú ha estado activo
            tiempoMenuDireccionesActivo += Time.deltaTime;

            // Si ha pasado más de 3 segundos, desactiva el menú de direcciones
            if (tiempoMenuDireccionesActivo >= 4f)
            {
                menuDireccionales.SetActive(false);
                tiempoMenuDireccionesActivo = 0f;
            }
        }

        if (menuSemaforos.activeInHierarchy)
        {
            // Aumenta el tiempo que el menú ha estado activo
            tiempoMenuDireccionesActivoSemaforo += Time.deltaTime;

            // Si ha pasado más de 3 segundos, desactiva el menú de direcciones
            if (tiempoMenuDireccionesActivoSemaforo >= 4f)
            {
                menuSemaforos.SetActive(false);
                tiempoMenuDireccionesActivoSemaforo = 0f;
            }
        }
        
        if (menuLuces.activeInHierarchy)
        {
            // Aumenta el tiempo que el menú ha estado activo
            tiempoMenuLuces += Time.deltaTime;

            // Si ha pasado más de 3 segundos, desactiva el menú de direcciones
            if (tiempoMenuLuces >= 4f)
            {
                menuLuces.SetActive(false);
                tiempoMenuLuces = 0f;
            }
        }

    }

    public void alterarPuntaje()
    {
        PlayerPrefs.SetInt(Nivel, Puntaje);
    }

    private void Semaforos()
    {
        int semaforo = 20;
    }

    private void LimiteVelocidad()
    {
        int velocidad = 10;
        if(rb != null) // Chequea si el objeto rb existe
        {
            speed = rb.velocity.magnitude * 4.2f;
        }
        if(speed > limiteVelocidad)
        {
            float tiempoActual = Time.time; // Obtiene el tiempo actual en segundos.
            float tiempoDesdeUltimaDisminucion = tiempoActual - tiempoUltimaDisminucion;
            if(tiempoDesdeUltimaDisminucion >= 4f) // Si han pasado al menos 2 segundos desde la última disminución.
            {
                
                Puntaje -= 10;
                if(Puntaje <= 0)
                {
                    Puntaje = 0;
                }

                TextoPuntaje.text = Puntaje.ToString();
                tiempoUltimaDisminucion = tiempoActual; // Actualiza el tiempo de la última disminución.
                Debug.Log(Puntaje);
            }
            menuVelocidad.SetActive(true);
        }
        else
        {
            menuVelocidad.SetActive(false);
        }
    }




    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "DirIzquierda")
        {
            if (DireccionalIzquierda.activeInHierarchy == false)
            {
                Puntaje -= 20;
                if (Puntaje <= 0)
                {
                    Puntaje = 0;
                }
                // Activa el menú de direcciones
                menuDireccionales.SetActive(true);
                // Reinicia el tiempo que el menú ha estado activo
                tiempoMenuDireccionesActivo = 0f;
            }
        }
        else if (col.gameObject.tag == "DirDerecha")
        {
            if (DireccionalDerecha.activeInHierarchy == false)
            {
                Puntaje -= 20;
                if (Puntaje <= 0)
                {
                    Puntaje = 0;
                }
                menuDireccionales.SetActive(true);
                tiempoMenuDireccionesActivo = 0f;
            }
        }
        else if (col.gameObject.tag == "FinNivel")
        {
            if (puntajeNivelGuardado < Puntaje)
            {
                alterarPuntaje();
            }
            Debug.Log(Puntaje);
            Debug.Log(puntajeNivelGuardado);

            audioListener.enabled = false;
            Destroy(objeto.gameObject);
            menuFin.SetActive(true);
            Time.timeScale = 0;
        }
        else if (col.gameObject.tag == "Semaforo")
        {
            if (LuzSemaforoRoja.isActiveAndEnabled)
            {
                Puntaje -= 30;
                if (Puntaje <= 0)
                {
                    Puntaje = 0;
                }
                menuSemaforos.SetActive(true);
                tiempoMenuDireccionesActivoSemaforo = 0f;
            }
        }
        else if (col.gameObject.tag == "Luces")
        {
            if (!LuzCoche.isActiveAndEnabled)
            {
                Puntaje -= 10;
                if (Puntaje <= 0)
                {
                    Puntaje = 0;
                }
                menuLuces.SetActive(true);
                tiempoMenuLuces = 0f;
            }
        }
    }

}