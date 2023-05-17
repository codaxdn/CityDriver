using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Direccionales : MonoBehaviour
{

    
    public GameObject derecha ;
    public GameObject izquierda;

    // Start is called before the first frame update
    void Start()
    {
        derecha.gameObject.SetActive(false);
        izquierda.gameObject.SetActive(false);
        derecha.GetComponent<Renderer>().material.color = Color.yellow;
        izquierda.GetComponent<Renderer>().material.color = Color.yellow;
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Q))
        {
            if(izquierda.activeInHierarchy == true){
                izquierda.gameObject.SetActive(false);
                derecha.gameObject.SetActive(false);
            }else{
                izquierda.gameObject.SetActive(true);
                derecha.gameObject.SetActive(false);
            }
            
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            if(derecha.activeInHierarchy == true){
                derecha.gameObject.SetActive(false);
                izquierda.gameObject.SetActive(false);
            }else{
                derecha.gameObject.SetActive(true);
                izquierda.gameObject.SetActive(false);
            }
            
        }
    }
}
