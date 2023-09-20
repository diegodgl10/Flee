using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasilloDestroy : MonoBehaviour
{
    public GameObject pasillo;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.pasillo, 2.0f);
        }
    }
}
