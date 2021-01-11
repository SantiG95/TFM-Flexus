using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraController : MonoBehaviour
{
    public Camera camara;

    public GameObject camaraActual;
    public GameObject camaraGuardada;

    public Vector3 ultimaPosicion;
    public bool mirandoCamaras = false;

    private GameObject botonesCamaraPrincipal;
    public GameObject UI;

    private GameObject bordeDerecho;
    private GameObject bordeIzquierdo;
    public float velocidadPaneo = 3;


    // Start is called before the first frame update
    void Start()
    {
        botonesCamaraPrincipal = GameObject.Find("Botones Camara Principal");
        ultimaPosicion = GameObject.Find("Mesas").gameObject.transform.position;

        bordeDerecho = GameObject.Find("BordeDerecho");
        bordeIzquierdo = GameObject.Find("BordeIzquierdo");

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            cambiarModo();
        }
        paneoHabitacion();

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

    void paneoHabitacion()
    {
        if (camaraActual.name != "Sala Principal")
        {
            Camera.main.transform.Translate(Vector3.right * velocidadPaneo * Time.deltaTime);

            if (bordeDerecho.transform.position.x >= camaraActual.GetComponent<LimitesCamara>().limiteDerecha ||
                bordeIzquierdo.transform.position.x <= camaraActual.GetComponent<LimitesCamara>().limiteIzquierda)
            {
                velocidadPaneo *= -1;
            }

        }
    }
}
