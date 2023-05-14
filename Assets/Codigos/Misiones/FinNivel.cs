using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinNivel : MonoBehaviour
{
    public AudioListener audioListener;
    public GameObject menuFin;
    public GameObject objeto;

    void Start()
    {
        menuFin.SetActive(false);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "FinNivel")
        {
            audioListener.enabled = false;
            Destroy(objeto.gameObject);
            menuFin.SetActive(true);
            Time.timeScale = 0;
        }
    }
}