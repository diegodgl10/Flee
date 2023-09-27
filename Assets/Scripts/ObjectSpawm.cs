using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawm : MonoBehaviour
{
    // Spawn de enemigos
    public GameObject[] spawnsEnemigos = new GameObject[8];
    public GameObject enemigo;

    // Spawn de obstaculos
    public GameObject[] spawnsObstaculos = new GameObject[14];
    public GameObject[] obstaculos = new GameObject[3];
    public GameObject[] spawnsBotes = new GameObject[3];
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemys();
        SpawnObstacles();
    }

    // Spawnea enemigos de forma aleatoria
    private void SpawnEnemys()
    {
        for (int i = 0; i < this.spawnsEnemigos.Length; i++)
        {
            int colocarlo = Random.Range(1, 6);
            if (colocarlo == 1)
            {
                Instantiate(this.enemigo, this.spawnsEnemigos[i].transform.position, this.spawnsEnemigos[i].transform.rotation);
            }
        }
    }

    // Spawnea obstaculos de forma aleatoria
    private void SpawnObstacles()
    {
        int posicion = 0;
        int obstacleRandom;
        for (int i = 0; i < this.spawnsObstaculos.Length; i++)
        {
            int colocarlo = Random.Range(1, 3);
            if (colocarlo == 1)
            {
                obstacleRandom = Random.Range(0, 2);
                Instantiate(this.obstaculos[obstacleRandom], this.spawnsObstaculos[posicion].transform.position, this.spawnsObstaculos[posicion].transform.rotation);
            }
            posicion++;
        }
        
        posicion = 0;
        for (int i = 0; i < this.spawnsBotes.Length; i++)
        {
            int colocarlo = Random.Range(1, 4);
            if (colocarlo != 1)
            {
                Instantiate(this.obstaculos[2], this.spawnsBotes[posicion].transform.position, this.spawnsBotes[posicion].transform.rotation);
            }
        }
    }
}
