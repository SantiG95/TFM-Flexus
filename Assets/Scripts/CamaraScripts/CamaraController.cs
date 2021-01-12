using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraController : MonoBehaviour
{
    public Camera camara;
    public bool juegoContinua = true;

    public GameObject camaraActual;
    public GameObject camaraGuardada;

    public Vector3 ultimaPosicion;
    public bool mirandoCamaras = false;

    private GameObject botonesCamaraPrincipal;
    public GameObject mapa;

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
    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        else if (juegoContinua)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                cambiarModo();
            }
            paneoHabitacion();
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
        mapa.SetActive(mirandoCamaras);
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

            if (bordeDerecho.transform.position.x > camaraActual.GetComponent<LimitesCamara>().limiteDerecha ||
                bordeIzquierdo.transform.position.x < camaraActual.GetComponent<LimitesCamara>().limiteIzquierda)
            {
                velocidadPaneo *= -1;
            }

        }
    }

    public void sinEnergia()
    {
        juegoContinua = false;
        if (camaraActual.name != "Sala Principal")
        {
            cambiarModo();
        }
    }
}
