
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Misiones : MonoBehaviour
{
    public GameObject menu1;
    // Start is called before the first frame update
    void Start()
    {
        menu1.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            Mensaje1();
        }
    }
    
    public void Mensaje1()
    {
        menu1.SetActive(false);
    }
}
