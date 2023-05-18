using UnityEngine;
using UnityEngine.UI;
using NUnit.Framework;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using System.Collections;

namespace Tests
{
    public class TutorialPruebas
    {
        [UnityTest]
        public IEnumerator VerificarPanelMensajeTutorial1Activo()
        {
            // Cargar la escena "Tutorial"
            SceneManager.LoadScene("Tutorial");

            // Esperar un frame para que se complete la carga de la escena
            yield return null;

            // Obtener referencia al panel MensajeTutorial1
            GameObject mensajeTutorial1 = GameObject.Find("MensajeTutorial1");

            // Verificar que el panel MensajeTutorial1 esté activo al iniciar la escena
            Assert.IsTrue(mensajeTutorial1.activeSelf, "El panel 'MensajeTutorial1' no está activo al iniciar la escena 'Tutorial'");
        }
    }
}