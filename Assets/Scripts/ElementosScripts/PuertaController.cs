using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaController : MonoBehaviour
{
    private BoxCollider2D puertaBC;
    private ElementosSprite cambiaSprite;

    private SpriteRenderer spritePuerta;
    public List<Sprite> listaSprites;

    public bool puertaAbierta = true;

    // Start is called before the first frame update
    void Start()
    {
        puertaBC = GetComponent<BoxCollider2D>();
        cambiaSprite = GetComponent<ElementosSprite>();
        spritePuerta = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
            cambiarSprite(0);
            puertaAbierta = true;
        }
        
    }

    void cambiarSprite(int numeroLista)
    {

        spritePuerta.sprite = listaSprites[numeroLista];
    }
}
