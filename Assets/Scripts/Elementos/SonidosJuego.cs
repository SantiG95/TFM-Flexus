using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidosJuego : MonoBehaviour
{
    private AudioSource sonidosJuego;
    public AudioClip sonidoCambioCamara;

    public AudioClip pasosCoco;

    public AudioClip ataqueCoco;


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
        sonidosJuego.PlayOneShot(pasosCoco, 1);
    }

    public void reproducirAtaqueCoco()
    {
        Debug.Log("Entro");
        sonidosJuego.PlayOneShot(ataqueCoco, 1);
    }
}
