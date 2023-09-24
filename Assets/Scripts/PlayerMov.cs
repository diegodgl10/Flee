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
    private float intervalo = 0.08f;

    // Nivel de cordura
    private int cordura;

    // Start is called before the first frame update
    void Start()
    {
        this.cordura = 3;
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
        if (collision.gameObject.tag == "Obstacle")
        {
            this.cordura = 0;
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            --this.cordura;
        }
    }

    /**
     * Regresa el nivel de cordura
     */
    public int getCordura()
    {
        return this.cordura;
    }
}
