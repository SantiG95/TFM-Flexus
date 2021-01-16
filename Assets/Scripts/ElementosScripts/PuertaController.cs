using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaController : MonoBehaviour
{
    private BoxCollider2D puertaBC;
    private PresenciaEnemigos enemigosPresentes;

    private SpriteRenderer spritePuerta;
    public List<Sprite> listaSprites;

    public bool puertaAbierta = true;
    public GameObject habitacionCamara;

    public bool juegoContinua;

    private AudioSource sonidosPuerta;
    public AudioClip puertaAbriendo;
    public AudioClip puertaCerrando;
    public AudioClip puertaGolpeada;

    // Start is called before the first frame update
    void Start()
    {
        enemigosPresentes = GameObject.Find("Sala Principal").GetComponent<PresenciaEnemigos>();
        puertaBC = GetComponent<BoxCollider2D>();
        spritePuerta = GetComponent<SpriteRenderer>();
        sonidosPuerta = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        habitacionCamara = GameObject.Find("Main Camera").GetComponent<CamaraController>().camaraActual;
        juegoContinua = GameObject.Find("Manager").GetComponent<GameManager>().juegoContinua;

        actualizarImagenEnemigos();
    }

    private void OnMouseDown()
    {
        if (juegoContinua)
        {
            cambiarSprite();
            if (puertaAbierta)
            {
                sonidosPuerta.PlayOneShot(puertaCerrando, 1);
            }
            else
            {
                sonidosPuerta.PlayOneShot(puertaAbriendo, 1);
            }
        }
    }

    public void cambiarSprite(int numeroLista)
    {

        spritePuerta.sprite = listaSprites[numeroLista];
    }

    void actualizarImagenEnemigos()
    {
        if (enemigosPresentes.cocoPresente && (habitacionCamara.name != "Sala Principal" || !juegoContinua))
        {
            cambiarSprite(2);
        }
    }

    public void cambiarSprite()
    {
        if (puertaAbierta)
        {
            cambiarSprite(1);
            puertaAbierta = false;
        }
        else
        {
            if (enemigosPresentes.cocoPresente)
            {
                cambiarSprite(2);
            }
            else
            {
                cambiarSprite(0);
            }
            puertaAbierta = true;
        }
    }

    public void sonidoPuertaGolpeada()
    {
        if (Random.Range(0, 100) < 50)
        {
            sonidosPuerta.PlayOneShot(puertaGolpeada, 1);
        }
    }

}
