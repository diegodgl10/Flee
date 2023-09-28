using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Sonidos de interaccion
    public AudioClip audioClipEnemy;
    public AudioSource audioSourceEnemy;
    // Sonidos de interaccion
    public AudioClip audioClipAbsorbido;
    public AudioSource audioSourceAbsorbido;
    private PlayerMov player;

    // Start is called before the first frame update
    void Start()
    {
        this.audioSourceEnemy = this.GetComponent<AudioSource>();
        // this.audioSourceBackpack = this.GetComponent<AudioSource>();
        try
        {
            this.player = GameObject.Find("Paco").GetComponent<PlayerMov>();
        } catch (System.NullReferenceException)
        {

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!this.player.GetConMochila())
            {
                this.audioSourceEnemy.PlayOneShot(this.audioClipEnemy);
            } else
            {
                this.audioSourceAbsorbido.PlayOneShot(this.audioClipEnemy);
            }
            this.player.DisminuirCordura();
        }
    }
}
