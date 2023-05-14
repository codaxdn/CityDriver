using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarMenu : MonoBehaviour
{   

    
    // Start is called before the first frame update
    public void CambiarEscena(string nombre)
    {

        Time.timeScale = 1;
        SceneManager.LoadScene(nombre);
    }
}
