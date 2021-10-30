using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//import importante para los cambios de escena
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void CambiarScenaClick(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void SalirJuego()
    {
        Application.Quit();
    }
}
