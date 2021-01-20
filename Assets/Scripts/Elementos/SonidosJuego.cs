using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidosJuego : MonoBehaviour
{
    private AudioSource sonidosJuego;
    public AudioClip sonidoCambioCamara;

    public AudioClip pasosCoco;

    public AudioClip ataqueCoco;

    public AudioClip alarma;
    public AudioClip victoria;


    // Start is called before the first frame update
    void Start()
    {
        sonidosJuego = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void detenerSonido()
    {
        sonidosJuego.Stop();
    }

    public void reproducirSonidoCambioCamara()
    {
        sonidosJuego.PlayOneShot(sonidoCambioCamara, 1);
    }

    public void reproducirPasosCoco()
    {
        sonidosJuego.PlayOneShot(pasosCoco, 0.3f);
    }

    public void reproducirAtaqueCoco()
    {
        detenerSonido();
        sonidosJuego.PlayOneShot(ataqueCoco, 0.8f);
    }

    public void reproducirAlarma()
    {
        detenerSonido();
        sonidosJuego.PlayOneShot(alarma, 0.2f);
    }
    public void reproducirVictoria()
    {
        detenerSonido();
        sonidosJuego.PlayOneShot(victoria, 0.3f);
    }
}
