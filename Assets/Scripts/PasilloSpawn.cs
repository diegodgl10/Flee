using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasilloSpawn : MonoBehaviour
{
    // Pasillo tipo 1
    public GameObject pasilloT1;
    // Pasillo tipo 2
    public GameObject pasilloT2;
    // Lugar de spawn
    public Transform spawn;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            int tipoPasillo = Random.Range(1, 3);
            if (tipoPasillo == 1) {
                Instantiate(this.pasilloT1, this.spawn.position, this.spawn.rotation);
            } else
            {
                Instantiate(this.pasilloT2, this.spawn.position, this.spawn.rotation);
            }
        }
    }
}
