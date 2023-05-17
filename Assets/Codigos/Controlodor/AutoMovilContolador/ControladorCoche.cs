using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorCoche : MonoBehaviour
{
    private float entradaHorizontal, entradaVertical;
    private float anguloGiroActual, fuerzaFrenadoActual;
    private bool estaFrenando;

    // Configuración
    [SerializeField] private float fuerzaMotor, fuerzaFrenado, anguloGiroMaximo;

    // Wheel Colliders
    [SerializeField] private WheelCollider colliderRuedaDelanteraIzquierda, colliderRuedaDelanteraDerecha;
    [SerializeField] private WheelCollider colliderRuedaTraseraIzquierda, colliderRuedaTraseraDerecha;

    // Ruedas
    [SerializeField] private Transform transformRuedaDelanteraIzquierda, transformRuedaDelanteraDerecha;
    [SerializeField] private Transform transformRuedaTraseraIzquierda, transformRuedaTraseraDerecha;

    private void FixedUpdate()
    {
        ObtenerEntrada();
        ControlarMotor();
        ControlarGiro();
        ActualizarRuedas();
    }

    private void ObtenerEntrada()
    {
        // Entrada de giro
        entradaHorizontal = Input.GetAxis("Horizontal");

        // Entrada de aceleración
        entradaVertical = Input.GetAxis("Vertical");

        // Entrada de frenado
        estaFrenando = Input.GetKey(KeyCode.Space);
    }

    private void ControlarMotor()
    {
        colliderRuedaDelanteraIzquierda.motorTorque = entradaVertical * fuerzaMotor;
        colliderRuedaDelanteraDerecha.motorTorque = entradaVertical * fuerzaMotor;
        fuerzaFrenadoActual = estaFrenando ? fuerzaFrenado : 0f;
        AplicarFrenado();
    }

    private void AplicarFrenado()
    {
        colliderRuedaDelanteraDerecha.brakeTorque = fuerzaFrenadoActual;
        colliderRuedaDelanteraIzquierda.brakeTorque = fuerzaFrenadoActual;
        colliderRuedaTraseraIzquierda.brakeTorque = fuerzaFrenadoActual;
        colliderRuedaTraseraDerecha.brakeTorque = fuerzaFrenadoActual;
    }

    private void ControlarGiro()
    {
        anguloGiroActual = anguloGiroMaximo * entradaHorizontal;
        colliderRuedaDelanteraIzquierda.steerAngle = anguloGiroActual;
        colliderRuedaDelanteraDerecha.steerAngle = anguloGiroActual;
    }

    private void ActualizarRuedas()
    {
        ActualizarRuedaIndividual(colliderRuedaDelanteraIzquierda, transformRuedaDelanteraIzquierda);
        ActualizarRuedaIndividual(colliderRuedaDelanteraDerecha, transformRuedaDelanteraDerecha);
        ActualizarRuedaIndividual(colliderRuedaTraseraDerecha, transformRuedaTraseraDerecha);
        ActualizarRuedaIndividual(colliderRuedaTraseraIzquierda, transformRuedaTraseraIzquierda);
    }

    private void ActualizarRuedaIndividual(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 posicion;
        Quaternion rotacion;
        wheelCollider.GetWorldPose(out posicion, out rotacion);
        wheelTransform.rotation = rotacion;
        wheelTransform.position = posicion;
    }
}