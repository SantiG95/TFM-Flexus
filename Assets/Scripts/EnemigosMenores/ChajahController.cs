using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChajahController : MonoBehaviour
{
    public int numeroNoche;
    public bool presente = false;
    public bool enojado = false;
    public float contador;

    private AudioSource sonidoChaja;
    private Animator animator;

    public AudioClip sonidoNormal;
    public AudioClip sonidoEnojado;

    private CocoControl coco;
    private PatoControl pato;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        sonidoChaja = GetComponent<AudioSource>();

        coco = GameObject.Find("Coco").GetComponent<CocoControl>();
        pato = GameObject.Find("Pato").GetComponent<PatoControl>();

        resetearContador();
    }

    // Update is called once per frame
    void Update()
    {
        if (!presente)
        {
            contador -= Time.deltaTime;
            if(contador < 0)
            {
                aparecer();
            }
        }
    }

    private void OnMouseDown()
    {
        if (presente && !enojado)
        {
            if(Random.Range(0,10) < 1)
            {
                enojarse();
            }
            else
            {
                desaparecer();
                resetearContador();
            }
        }
    }

    private void aparecer()
    {
        animator.SetTrigger("ChajahAparece");
        presente = true;
        sonidoChaja.clip = sonidoNormal;
        sonidoChaja.Play();

        for (int i = 0; i < 4; i++)
        {
            coco.aumentarDificultad();
            pato.aumentarDificultad();
        }
    }

    private void desaparecer()
    {
        animator.SetTrigger("ChajahDesaparece");
        presente = false;
        sonidoChaja.Stop();

        for (int i = 0; i < 4; i++)
        {
            coco.disminuirDificultad();
            pato.disminuirDificultad();
        }
    }

    void resetearContador()
    {
        contador = Random.Range(40, 500 - 92 * numeroNoche);
    }

    void enojarse()
    {
        animator.SetTrigger("ChajahEnojado");
        sonidoChaja.clip = sonidoEnojado;
        sonidoChaja.Play();
        enojado = true;

        for (int i = 0; i < 3; i++)
        {
            coco.aumentarDificultad();
            pato.aumentarDificultad();
        }
    }

    public void establecerNoche(int nNoche)
    {
        numeroNoche = nNoche;
    }

    public void detener()
    {
        sonidoChaja.Stop();
    }
}
