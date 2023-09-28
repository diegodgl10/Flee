using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mochila : MonoBehaviour
{
    // Sonidos de interaccion
    public AudioClip audioClipMochila;
    public AudioSource audioSourceMochila;
    private PlayerMov player;

    // Start is called before the first frame update
    void Start()
    {
        this.audioSourceMochila = this.GetComponent<AudioSource>();
        try
        {
            this.player = GameObject.Find("Paco").GetComponent<PlayerMov>();
        }
        catch (System.NullReferenceException)
        {

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            this.audioSourceMochila.PlayOneShot(this.audioClipMochila);
            this.player.PonerMochila();
        }
    }
}
