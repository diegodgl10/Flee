using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawm : MonoBehaviour
{
    // Spawn de enemigos
    public GameObject[] spawnsEnemigos = new GameObject[6];
    public GameObject enemigo;

    // Spawn de obstaculos
    public GameObject[] spawnsObstaculos = new GameObject[12];
    public GameObject[] obstaculos = new GameObject[3];

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemys();
        SpawnObstacles();
    }

    // Spawnea enemigos de forma aleatoria
    private void SpawnEnemys()
    {
        for (int i = 0; i < 6; i++)
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
        for (int i = 0; i < 6; i++)
        {
            int colocarlo = Random.Range(0, 5);
            if (colocarlo != 1)
            {
                obstacleRandom = Random.Range(0, 3);
                Instantiate(this.obstaculos[obstacleRandom], this.spawnsObstaculos[posicion].transform.position, this.spawnsObstaculos[posicion].transform.rotation);
            }
            posicion++;
        }
    }
}
