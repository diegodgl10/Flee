using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Envirioment : MonoBehaviour
{
    public TMP_Text tmp;
    private int distancia;

    // Variable para contar tiempo
    private float tiempoTranscurrido = 0f;
    // Variable de tiempo de espera antes de mover de nuevo
    private float intervalo = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        this.distancia = 0;
        this.tmp.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        if (TiempoDeEspera())
        {
            this.distancia++;
            this.tmp.text = this.distancia.ToString();
        }
    }

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
