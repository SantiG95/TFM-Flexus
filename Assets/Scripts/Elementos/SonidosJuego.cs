using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidosJuego : MonoBehaviour
{
    private AudioSource sonidosJuego;
    public AudioClip sonidoCambioCamara;

    public AudioClip pasosCoco;
    public AudioClip pasosPato;

    public AudioClip ataqueCoco;
    public AudioClip ataquePato;

    public AudioClip patoTriste;
    public AudioClip patoLlamado1;
    public AudioClip patoLlamado2;
    public AudioClip patoLlamado3;

    public AudioClip alarma;
    public AudioClip victoria;

    public AudioClip chajahSonido;


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

    public void reproducirPatoTriste()
    {
        sonidosJuego.PlayOneShot(patoTriste, 0.15f);
    }

    public void reproducirPasosPato()
    {
        sonidosJuego.PlayOneShot(pasosPato, 1);
    }

    public void reproducirPatoLlamado()
    {
        switch (Random.Range(0, 3))
        {
            case 0:
                sonidosJuego.PlayOneShot(patoLlamado1, 0.15f);
                break;

            case 1:
                sonidosJuego.PlayOneShot(patoLlamado2, 0.3f);
                break;

            case 2:
                sonidosJuego.PlayOneShot(patoLlamado3, 0.3f);
                break;
        }
    }

    public void reproducirAtaquePato()
    {
        detenerSonido();
        sonidosJuego.PlayOneShot(ataquePato, 0.3f);
    }

    public void reproducirSonidoChajah()
    {
        sonidosJuego.PlayOneShot(chajahSonido, 1);
    }
}
