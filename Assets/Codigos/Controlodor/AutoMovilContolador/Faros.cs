using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Faros : MonoBehaviour
{
    public Light Luz;
    void Start()
    {
        Luz.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Faros"))
        {
            if(Luz.enabled == true)
            {
                Luz.enabled = false;
            }
            else if(Luz.enabled == false)
            {
                Luz.enabled = true;
            }
        }
    }
}
