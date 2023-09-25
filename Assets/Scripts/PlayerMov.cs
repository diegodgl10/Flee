using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    // Velocidad de movimiento y de rotacion
    // private float speed = 25, rotationalSpeed = 25;
    // Movimiento vertial y horizontal
    private float horizontalMov;

    // Variable para contar tiempo
    private float tiempoTranscurrido = 0f;
    // Variable de tiempo de espera antes de mover de nuevo
    private float intervalo = 0.07f;

    // Nivel de cordura
    private int cordura;

    // Entorno de juego
    Envirioment envirioment;

    // Start is called before the first frame update
    void Start()
    {
        this.cordura = 3;
        this.envirioment = GameObject.Find("Envirioment").GetComponent<Envirioment>();
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
    }

    // Movimiento del jugador
    private void Movimiento()
    {
        this.horizontalMov = Input.GetAxis("Horizontal");
        if (this.horizontalMov != 0)
        {
            Vector3 nuevaPosicion;
            if (this.horizontalMov > 0)
            {
                nuevaPosicion = this.transform.position + Vector3.right * 4.0f;
            } else
            {
                nuevaPosicion = this.transform.position + Vector3.left * 4.0f;
            }
            bool puedeMoverse = !HayColision(nuevaPosicion);
            if (puedeMoverse && TiempoDeEspera())
            {
                this.transform.position = nuevaPosicion;
            }
        }
    }

    // Verifica si hay colisiones con objetos que tengan un BoxCollider
    // return True si hay colision, False en otro caso
    private bool HayColision(Vector3 posicionObjetivo)
    {
        Collider[] colliders = Physics.OverlapBox(posicionObjetivo, GetComponent<Collider>().bounds.size / 2);
        foreach (Collider collider in colliders)
        {
            if (collider != GetComponent<Collider>())
            {
                return true;
            }
        }
        return false;
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Camilla")
        {
            EliminarJugador("Camilla");
        }
        if (collision.gameObject.tag == "Botes")
        {
            EliminarJugador("Botes");
        }
        if (collision.gameObject.tag == "Archivero")
        {
            EliminarJugador("Archivero");
        }
    }

    /* Metodo para hacer que el jugador pierda */
    private void EliminarJugador(string razon)
    {
        this.cordura = 0;
        this.envirioment.SetRazon(razon);
        this.envirioment.SetCordura(this.cordura);
        this.gameObject.SetActive(false);
    }

    /**
     * Regresa el nivel de cordura
     */
    public int GetCordura()
    {
        return this.cordura;
    }

    /**
     * Diminuye en 1 el nivel de cordura
     */
    public void DisminuirCordura()
    {
        if (this.cordura <= 1)
        {
            EliminarJugador("Enemy");
        }
        else
        {
            this.cordura = this.cordura - 1;
            this.envirioment.SetCordura(this.cordura);
        }
    }

}
