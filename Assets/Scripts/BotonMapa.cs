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

    private CamaraController camara;
    private Image sprite;

    // Start is called before the first frame update
    void Start()
    {
        camara = GameObject.Find("Main Camera").GetComponent<CamaraController>();
        sprite = GetComponent<Image>();

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("clicky");
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

    public void camaraActiva()
    {
        ponerCamarasNoActivas();
        sprite.sprite = botonActivado;
    }

    public void camaraNoActiva()
    {
        sprite.sprite = botonDesactivado;
    }
}
