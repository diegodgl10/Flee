using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // Sonidos de interaccion
    public AudioClip audioClipObstacle;
    public AudioSource audioSourceObstacle;

    // Start is called before the first frame update
    void Start()
    {
        this.audioSourceObstacle = this.GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            this.audioSourceObstacle.PlayOneShot(this.audioClipObstacle);
        }
    }
}
