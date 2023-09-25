using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Envirioment : MonoBehaviour
{
    // Pantalla
    public TMP_Text tmpDistancia;
    public TMP_Text tmpCordura;
    public TMP_Text gameOverDistancia;
    public TMP_Text gameOverMuerte;
    public GameObject screenGOInformation;
    public GameObject enemyScreen;
    public GameObject archiveroScreen;
    public GameObject botesScreen;
    public GameObject camillaScreen;

    private string razon;
    private int corduraPlayer = 3;

    // Distancia recorrida por el personaje
    private int distancia;
    // Variable para contar tiempo
    private float tiempoTranscurrido = 0f;
    // Variable de tiempo de espera antes de mover de nuevo
    private float intervalo = 1.0f;

    // Sonidos de ambiente
    public AudioClip audioClipEnvirioment;
    public AudioSource audioSourceEnvirioment;

    // Start is called before the first frame update
    void Start()
    {
        this.audioSourceEnvirioment = this.GetComponent<AudioSource>();
        this.audioSourceEnvirioment.PlayOneShot(this.audioClipEnvirioment);

        this.distancia = 0;
        this.tmpDistancia.text = "0";

        this.tmpCordura.text = this.corduraPlayer.ToString() + "/3";
    }

    // Update is called once per frame
    void Update()
    {
        if (this.corduraPlayer <= 0)
        {
            GameOver();
        } else if (TiempoDeEspera())
        {
            this.distancia++;
            Debug.Log(this.corduraPlayer);
            this.tmpDistancia.text = this.distancia.ToString();
        }
    }
    
    /* Pantalla de game over */
    private void GameOver()
    {
        this.screenGOInformation.SetActive(true);
        if (this.razon == "Enemy")
        {
            this.enemyScreen.SetActive(true);
            this.gameOverMuerte.text = "Death by: \nInsanity";
        }
        if (this.razon == "Camilla")
        {
            this.camillaScreen.SetActive(true);
            this.gameOverMuerte.text = "Death by: \nCollision";
        }
        if (this.razon == "Botes")
        {
            this.botesScreen.SetActive(true);
            this.gameOverMuerte.text = "Death by: \nTripping";
        }
        if (this.razon == "Archivero")
        {
            this.archiveroScreen.SetActive(true);
            this.gameOverMuerte.text = "Death by: \nCollision";
        }
        this.gameOverDistancia.text = "Distance:\n" + this.distancia.ToString();
    }

    /* Calcula el tiempo de espera para actualizar la distancia */
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
    
    /**
     * Define la razon por la que el personaje murio
     */
    public void SetRazon(string razon)
    {
        this.razon = razon;
    }

    /**
     * Define la cordura del personaje
     */
    public void SetCordura(int corduraPlayer)
    {
        this.corduraPlayer = corduraPlayer;
        this.tmpCordura.text = this.corduraPlayer.ToString() + "/3";
    }
}
