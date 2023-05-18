using UnityEngine;
using UnityEngine.UI;
using NUnit.Framework;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using System.Collections;

namespace Tests
{
    public class MenuMisionesPruebas
    {
        [UnityTest]
        public IEnumerator BotonesActivosDesactivos_Correctos()
        {
            // Cargar la escena "MenuMisiones"
            SceneManager.LoadScene("MenuMisiones");

            // Esperar un frame para que se complete la carga de la escena
            yield return null;

            // Obtener referencias a los botones de nivel en la escena
            Button btnTutorial = GameObject.Find("BtnTutorial").GetComponent<Button>();
            Button btnMision1 = GameObject.Find("BtnMision1").GetComponent<Button>();
            Button btnMision2 = GameObject.Find("BtnMision2").GetComponent<Button>();
            Button btnMision3 = GameObject.Find("BtnMision3").GetComponent<Button>();
            Button btnMision4 = GameObject.Find("BtnMision4").GetComponent<Button>();

            // Verificar que se hayan encontrado los botones de nivel en la escena
            Assert.NotNull(btnTutorial, "No se encontró el botón 'BtnTutorial' en la escena 'MenuMisiones'");
            Assert.NotNull(btnMision1, "No se encontró el botón 'BtnMision1' en la escena 'MenuMisiones'");
            Assert.NotNull(btnMision2, "No se encontró el botón 'BtnMision2' en la escena 'MenuMisiones'");
            Assert.NotNull(btnMision3, "No se encontró el botón 'BtnMision3' en la escena 'MenuMisiones'");
            Assert.NotNull(btnMision4, "No se encontró el botón 'BtnMision4' en la escena 'MenuMisiones'");

            // Verificar el estado de los botones de nivel
            Assert.AreEqual(PlayerPrefs.HasKey("Tutorial") && PlayerPrefs.GetInt("Tutorial") >= 60, btnTutorial.interactable, "El botón 'BtnTutorial' no tiene el estado esperado");
            Assert.AreEqual(PlayerPrefs.HasKey("Mision1") && PlayerPrefs.GetInt("Mision1") >= 60, btnMision1.interactable, "El botón 'BtnMision1' no tiene el estado esperado");
            Assert.AreEqual(PlayerPrefs.HasKey("Mision2") && PlayerPrefs.GetInt("Mision2") >= 60, btnMision2.interactable, "El botón 'BtnMision2' no tiene el estado esperado");
            Assert.AreEqual(PlayerPrefs.HasKey("Mision3") && PlayerPrefs.GetInt("Mision3") >= 60, btnMision3.interactable, "El botón 'BtnMision3' no tiene el estado esperado");
            Assert.AreEqual(PlayerPrefs.HasKey("Mision4") && PlayerPrefs.GetInt("Mision4") >= 60, btnMision4.interactable, "El botón 'BtnMision4' no tiene el estado esperado");
        }
    }
}