using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    // Velocidad de movimiento y de rotacion
    // private float speed = 25, rotationalSpeed = 25;
    // Movimiento vertial y horizontal
    private float horizontalMov;
    private float upForce = 366;
    private float downForce = 15;

    // Variable para contar tiempo
    private float tiempoTranscurrido = 0f;
    // Variable de tiempo de espera antes de mover de nuevo
    private float intervalo = 0.12f; // 0.085 movimiento mas rapido

    // Nivel de cordura
    private int cordura = 3;

    // Mochila puesto
    private float tiempoTranscurridoMochila = 0f;
    private bool conMochila = false;
    private float duracionMochila = 7.0f;

    // Aspectps
    public GameObject aspectoSinMochila;
    public GameObject aspectoConMochila;

    public Rigidbody rigidBody;

    // Entorno de juego
    Envirioment envirioment;

    // Start is called before the first frame update
    void Start()
    {
        this.aspectoSinMochila.SetActive(true);
        this.aspectoConMochila.SetActive(false);
        this.envirioment = GameObject.Find("Envirioment").GetComponent<Envirioment>();
        this.rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (this.conMochila)
        {
            this.tiempoTranscurridoMochila += Time.deltaTime;
            if (this.tiempoTranscurridoMochila >= this.duracionMochila)
            {
                this.tiempoTranscurridoMochila = 0f;
                QuitarMochila();
            }
        }


        if (Input.GetKeyDown(KeyCode.W) && TocandoSuelo())
        {
            this.rigidBody.AddForce(Vector3.up * this.upForce);
        }
        else
        {
            this.rigidBody.AddForce(Vector3.down * this.downForce, ForceMode.Force);
        }
        Movimiento();
    }

    private bool TocandoSuelo()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, 7.5f))
        {
            if (hit.collider.CompareTag("Estructura"))
            {
                return true;
            }
        }
        return false;
    }

    // Movimiento del jugador
    private void Movimiento()
    {
        this.horizontalMov = Input.GetAxis("Horizontal");
        if (this.horizontalMov != 0 && TiempoDeEspera())
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
            if (puedeMoverse)
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
            Transform objetoTransform = collider.transform;
            if (objetoTransform.CompareTag("Estructura"))
            {
                return true;
            }
        }
        return false;
        /*
        Collider[] colliders = Physics.OverlapBox(posicionObjetivo, GetComponent<Collider>().bounds.size / 2);
        foreach (Collider collider in colliders)
        {
            //if (collider.isTrigger == false && collider != GetComponent<Collider>())
            if(collider.isTrigger == false)
            {
                return true;
            }
        }
        return false;
        */
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

    public bool GetConMochila()
    {
        return this.conMochila;
    }

    /**
     * Diminuye en 1 el nivel de cordura
     */
    public void DisminuirCordura()
    {
        if (this.conMochila)
        {
            if (this.cordura < 3)
            {
                this.cordura++;
                return;
            }
        }
        if (this.cordura <= 1)
        {
            EliminarJugador("Enemy");
        }
        else
        {
            this.cordura--;
            this.envirioment.SetCordura(this.cordura);
        }
    }

    public void PonerMochila()
    {
        this.aspectoSinMochila.SetActive(false);
        this.aspectoConMochila.SetActive(true);
        this.tiempoTranscurridoMochila = 0f;
        this.conMochila = true;
    }

    private void QuitarMochila()
    {
        this.aspectoSinMochila.SetActive(true);
        this.aspectoConMochila.SetActive(false);
        this.tiempoTranscurridoMochila = 0f;
        this.conMochila = true;
    }

}
