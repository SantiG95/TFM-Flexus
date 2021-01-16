using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapaController : MonoBehaviour
{
    public bool puertaAbierta = true;

    private Animator animatorChapa;
    public  bool juegoContinua;

    private AudioSource sonidosChapa;
    public AudioClip chapaCorriendo;
    public AudioClip chapaGolpeada;

    // Start is called before the first frame update
    void Start()
    {
        sonidosChapa = GetComponent<AudioSource>();
        animatorChapa = GetComponent<Animator>();
        animatorChapa.SetBool("Abierto", true);
    }

    // Update is called once per frame
    void Update()
    {
        juegoContinua = GameObject.Find("Manager").GetComponent<GameManager>().juegoContinua;
    }

    private void OnMouseDown()
    {
        if (juegoContinua)
        {
            cambiarSprite();
        }
    }

    public void cambiarSprite()
    {
        sonidosChapa.PlayOneShot(chapaCorriendo, 1);
        if (puertaAbierta)
        {
            animatorChapa.SetTrigger("Moviendo");

            puertaAbierta = false;
            animatorChapa.SetBool("Abierto", false);
        }
        else
        {
            animatorChapa.SetTrigger("Moviendo");
            animatorChapa.SetBool("Abierto", true);
            puertaAbierta = true;
        }
    }

    public void sonidoChapaGolpeada()
    {
        sonidosChapa.PlayOneShot(chapaGolpeada, 1);
    }
}
