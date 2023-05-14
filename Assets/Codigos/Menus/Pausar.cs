using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausar : MonoBehaviour
{
    public GameObject menuDePausa;
    public AudioListener audioListener;

    // Start is called before the first frame update
    void Start()
    {
        menuDePausa.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pausar();
        }
    }
    
    public void pausar()
    {
        if(Time.timeScale == 1)
        {
            Time.timeScale = 0;
            menuDePausa.SetActive(true);
            audioListener.enabled = false; // desactiva el AudioListener

        }
        else
        {
            Time.timeScale = 1;
            menuDePausa.SetActive(false);
            audioListener.enabled = true; // activa el AudioListener
        }
    }
    
    public void despausar()
    {
        menuDePausa.SetActive(false);
        Time.timeScale = 1;
        audioListener.enabled = true; // activa el AudioListener
    }
}