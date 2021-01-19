using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SalaPrincipalScript : MonoBehaviour//, IPointerDownHandler
{
    private Animator animacionesAtaque;

    private GameObject puerta;
    private GameObject chapa;

    private AudioSource sonidosSusto;
    public AudioClip sonidoCoco;

    public AudioClip easterEgg;

    // Start is called before the first frame update
    void Start()
    {
        sonidosSusto = GetComponent<AudioSource>();
        animacionesAtaque = GetComponent<Animator>();

        puerta = GameObject.Find("Puerta");
        chapa = GameObject.Find("Chapa");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void cocoAtaca()
    {
        puerta.SetActive(false);
        chapa.SetActive(false);
        animacionesAtaque.SetTrigger("cocoAtaca");
        sonidosSusto.PlayOneShot(sonidoCoco, 1);
        GameObject.Find("Main Camera").GetComponent<AudioSource>().Stop();

        GameObject.Find("Manager").GetComponent<GameManager>().lanzarFinal(true);
    }

    private void OnMouseDown()
    {
        sonidosSusto.PlayOneShot(easterEgg, 1);
    }
}