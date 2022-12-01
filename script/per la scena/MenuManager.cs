using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void Gioca()
    {
        SceneManager.LoadScene("Game");
    }

    public void Esci()
    {
        //termina la applicazione
        Application.Quit();
    }
}