using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscenasTest
{
    private const float TiempoMaximoCarga = 5f; // Tiempo máximo de carga en segundos
    private string[] escenas = { "Mision2", "Mision3", "Mision4", "Mision1", "Lobby", "OpcionesLobby", "MenuMisiones" };

    [Test]
    public void TestCargaEscenas()
    {
        foreach (string escena in escenas)
        {
            float tiempoInicio = Time.realtimeSinceStartup;

            // Cargar la escena de forma sincrónica
            SceneManager.LoadScene(escena);

            float tiempoCarga = Time.realtimeSinceStartup - tiempoInicio;

            // Verificar si el tiempo de carga es menor o igual al tiempo máximo permitido
            Assert.LessOrEqual(tiempoCarga, TiempoMaximoCarga);
        }
    }
}