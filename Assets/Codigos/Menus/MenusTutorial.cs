using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenusTutorial : MonoBehaviour
{
    public GameObject menu1;
    public GameObject menu2;

    void Start()
    {
        menu1.SetActive(false);
        menu2.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            menu1.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            menu1.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            menu2.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "T1")
        {
            menu1.SetActive(true);
        }
        else if (col.gameObject.tag == "T2")
        {
            menu2.SetActive(true);
        }
    }
}