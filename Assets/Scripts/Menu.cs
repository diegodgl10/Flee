using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    // Sonidos de ambiente
    public AudioClip audioClipMenu;
    public AudioSource audioSourceMenu;

    // Start is called before the first frame update
    void Start()
    {
        this.audioSourceMenu = this.GetComponent<AudioSource>();
        this.audioSourceMenu.PlayOneShot(this.audioClipMenu);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
