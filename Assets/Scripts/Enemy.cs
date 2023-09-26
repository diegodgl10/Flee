using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Sonidos de interaccion
    public AudioClip audioClipEnemy;
    public AudioSource audioSourceEnemy;
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
            this.audioSourceEnemy.PlayOneShot(this.audioClipEnemy);
            this.player.DisminuirCordura();
        }
    }
}
