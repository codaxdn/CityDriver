using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class LobbyPruebas
{
    [UnityTest]
    public IEnumerator BotonesLobby_RedireccionCorrecta()
    {
        // Cargar la escena del lobby
        SceneManager.LoadScene("Lobby");

        // Esperar un frame para que se complete la carga de la escena
        yield return null;

        // Obtener una referencia al botón de redirección en la escena
        Button botonRedireccion = GameObject.Find("BtnIniciar").GetComponent<Button>();

        // Verificar que el botón no sea nulo
        Assert.NotNull(botonRedireccion, "El botón Iniciar no se encuentra en la escena 'Lobby'");

        // Simular clic en el botón de redirección
        botonRedireccion.onClick.Invoke();

        // Esperar un frame para que se complete la carga de la escena redireccionada
        yield return null;

        // Obtener la escena actual
        Scene escenaActual = SceneManager.GetActiveScene();

        // Verificar que la escena actual sea diferente a la escena "Lobby"
        Assert.AreNotEqual("Lobby", escenaActual.name, "El botón en la escena 'Lobby' no lleva a otra ventana");

        yield break;
    }

    [UnityTest]
    public IEnumerator EscenaMenu_PanelExistente()
    {
        // Cargar la escena "Menu"
        SceneManager.LoadScene("Lobby");

        // Esperar un frame para que se complete la carga de la escena
        yield return null;

        // Obtener una referencia al panel en la escena
        GameObject panelMenu = GameObject.Find("Fondo");

        // Verificar que el panel no sea nulo
        Assert.NotNull(panelMenu, "El panel 'Fondo' no se encuentra en la escena 'Menu'");

        yield break;
    }
}