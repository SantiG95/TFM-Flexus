using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidosJuego : MonoBehaviour
{
    private AudioSource sonidosJuego;
    public AudioClip sonidoCambioCamara;


    // Start is called before the first frame update
    void Start()
    {
        sonidosJuego = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void reproducirSonidoCambioCamara()
    {
        sonidosJuego.PlayOneShot(sonidoCambioCamara, 1);
    }
}
