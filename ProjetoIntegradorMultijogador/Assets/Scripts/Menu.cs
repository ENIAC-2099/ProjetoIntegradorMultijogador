using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Menu : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void Iniciar()
    {
        SceneManager.LoadScene("game"); 
    }


    public void Stop()
    {
        Debug.Log("Sai do jogo");
        Application.Quit();
    }
}
