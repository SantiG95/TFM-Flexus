using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraController : MonoBehaviour
{
    public GameObject camaraActual;
    public GameObject camaraGuardada;

    public Vector3 ultimaPosicion;
    public bool mirandoCamaras = false;

    private GameObject botonesCamaraPrincipal;
    public GameObject UI;

    // Start is called before the first frame update
    void Start()
    {
        botonesCamaraPrincipal = GameObject.Find("Botones Camara Principal");
        ultimaPosicion = GameObject.Find("Mesas").gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            cambiarModo();
        }
    }

    void cambiarModo()
    {
        mirandoCamaras = !mirandoCamaras;
        cambiarCamara();
        cambiarBotones();
    }

    void cambiarCamara()
    {
        GameObject cambio = camaraActual;

        camaraActual = camaraGuardada;
        camaraGuardada = cambio;

        if (mirandoCamaras)
        {
            ultimaPosicion = transform.position;
            transform.position = camaraActual.transform.position + new Vector3(0, 0, -10);
        }
        else
        {
            transform.position = ultimaPosicion;
        }
    }

    void cambiarBotones()
    {
        botonesCamaraPrincipal.SetActive(!mirandoCamaras);
        UI.SetActive(mirandoCamaras);
    }

    public void cambiarUbicacion(Vector3 ubicacion)
    {
        transform.position = ubicacion + new Vector3(0, 0, -10);
    }
}
