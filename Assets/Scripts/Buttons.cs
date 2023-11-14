using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public GameObject menu;
    public GameObject controls;

    // Variable para contar tiempo
    private float tiempoTranscurrido = 0f;
    // Variable de tiempo de espera antes de iniciar el juego
    private float intervalo = 2.25f;

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void StartGame()
    {
        this.menu.SetActive(false);
        this.controls.SetActive(true);
        while (TiempoDeEspera() == false)
        {
            SceneManager.LoadScene("Flee");
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Flee");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void CleanData()
    {
        PlayerPrefs.DeleteAll();
    }

    // Nos indica si ya paso el tiempo de espera entre movimientos
    private bool TiempoDeEspera()
    {
        this.tiempoTranscurrido += Time.deltaTime;
        if (this.tiempoTranscurrido >= this.intervalo)
        {
            this.tiempoTranscurrido = 0f;
            return true;
        }
        return false;
    }
}
