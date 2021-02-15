using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatoEnSalaScript : MonoBehaviour
{
    private PresenciaEnemigos enemigosPresentes;
    private SpriteRenderer spritePatoEnSala;
    public List<Sprite> listaSprites;

    private AudioSource sonidosPatoEnSala;
    public AudioClip patoEnSalaSonido;

    // Start is called before the first frame update
    void Start()
    {
        enemigosPresentes = GameObject.Find("Sala Principal").GetComponent<PresenciaEnemigos>();
        spritePatoEnSala = GetComponent<SpriteRenderer>();
        sonidosPatoEnSala = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemigosPresentes.patoPresente)
        {
            spritePatoEnSala.sprite = listaSprites[1];
        }
        else
        {
            spritePatoEnSala.sprite = listaSprites[0];
        }
    }
}
