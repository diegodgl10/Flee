using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    // Velocidad de movimiento y de rotacion
    public float speed = 25, rotationalSpeed = 25;
    // Movimiento vertial y horizontal
    private float horizontalMov;

    // Variable para contar tiempo
    private float tiempoTranscurrido = 0f;
    // Variable de tiempo de espera antes de mover de nuevo
    private float intervalo = 0.093f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
    }

    // Movimiento del jugador
    private void Movimiento()
    {
        /*
        this.horizontalMov = Input.GetAxis("Horizontal");
        bool disponible =  !Physics.Raycast(transform.position, Vector3.left, 3f, LayerMask.GetMask("Obstacle"));
        disponible = disponible && !Physics.Raycast(transform.position, Vector3.left, 3f, LayerMask.GetMask("Terrain"));
        if (disponible == false)
        {
            Debug.Log("No esta disponible");
        }
        if (this.horizontalMov != 0 && disponible)
        {
            float movEnX;
            if (this.horizontalMov > 0)
            {
                movEnX = 8f;
            } else
            {
                movEnX = -8f;
            }
            movEnX = movEnX * Time.deltaTime * this.rotationalSpeed;
            this.transform.Translate(movEnX, 0, 0);
        }*/
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

    /** Verifica si hay colisiones con objetos que tengan un BoxCollider
     * return True si hay colision, False en otro caso
     */
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

    /**
     * Nos indica si ya paso un segundo
     */
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
