using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BotonMapa : MonoBehaviour, IPointerDownHandler
{
    public GameObject habitacion;
    public Sprite botonActivado;
    public Sprite botonDesactivado;
    public bool activa;

    private CamaraController camara;
    private Image sprite;

    private SonidosJuego sonidoCamara;

    // Start is called before the first frame update
    void Start()
    {
        camara = GameObject.Find("Main Camera").GetComponent<CamaraController>();
        sprite = GetComponent<Image>();

        sonidoCamara = GameObject.Find("Main Camera").GetComponent<SonidosJuego>();
    }

    void Update()
    {
        cambiarSprite();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        sonidoCamara.reproducirSonidoCambioCamara();
        camara.cambiarUbicacion(habitacion.transform.position);
        camara.camaraActual = habitacion;
        camaraActiva();
    }

    public void ponerCamarasNoActivas()
    {
        for (int i = 1; i < 8; i++)
        {
            GameObject.Find("Boton" + i.ToString()).GetComponent<BotonMapa>().camaraNoActiva();
        }
    }

    void cambiarSprite()
    {
        if (activa)
        {
            sprite.sprite = botonActivado;
        }
        else
        {
            sprite.sprite = botonDesactivado;
        }
    }

    public void camaraActiva()
    {
        ponerCamarasNoActivas();
        activa = true;
        
    }

    public void camaraNoActiva()
    {
        activa = false;
    }
}
