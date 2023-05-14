using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonPlay : MonoBehaviour
{
    public AudioListener audioListener;
    public GameObject menuDePausa;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void despausar()
    {
       audioListener.enabled = true;
        menuDePausa.SetActive(false);
        Time.timeScale = 1;
    }
}
