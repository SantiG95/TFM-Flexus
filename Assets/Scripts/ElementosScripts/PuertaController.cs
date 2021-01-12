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

    // Start is called before the first frame update
    void Start()
    {
        enemigosPresentes = GameObject.Find("Sala Principal").GetComponent<PresenciaEnemigos>();
        puertaBC = GetComponent<BoxCollider2D>();
        spritePuerta = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        habitacionCamara = GameObject.Find("Main Camera").GetComponent<CamaraController>().camaraActual;
        actualizarImagenEnemigos();
    }

    private void OnMouseDown()
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

    public void cambiarSprite(int numeroLista)
    {

        spritePuerta.sprite = listaSprites[numeroLista];
    }

    void actualizarImagenEnemigos()
    {
        if (enemigosPresentes.cocoPresente && habitacionCamara.name != "Sala Principal")
        {
            cambiarSprite(2);
        }
    }

}
