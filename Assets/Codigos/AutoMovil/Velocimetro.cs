using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Velocimetro : MonoBehaviour
{

    public Rigidbody rb;
    [Header("UI")]
    public TMP_Text SpeedVelocidad;
    private float speed = 0.0f;


    // Update is called once per frame
    void Update()
    {
        //speed = rb.velocity.magnitude * 15.6f;
        speed = rb.velocity.magnitude * 4.2f;
        if(SpeedVelocidad != null)
            SpeedVelocidad.text = ((int)speed) + "Km/h";
        
    }
}
