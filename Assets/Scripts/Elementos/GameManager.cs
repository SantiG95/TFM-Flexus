using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int numeroNoche = 1;

    public GameObject UI;
    public GameObject Mapa;
    public GameObject botonesMapa;
    public List<GameObject> listaEnemigos;
    public GameObject Camara;
    public PuertaController puerta;
    public ChapaController chapa;
    public GameObject finDelJuegoTexto;
    public bool juegoContinua = true;
    public int tiempoFinal = 540;

    public float contador = 0;
    public int tiempo = 0;
    public float cansancio = 100;
    public float tiempoDescuento = 9.6f;

    public float contadorReset = 0;


    // Start is called before the first frame update
    void Start()
    {
        puerta = GameObject.Find("Puerta").GetComponent<PuertaController>();
        chapa = GameObject.Find("Chapa").GetComponent<ChapaController>();

        StartCoroutine(contarTiempo());
    }

    // Update is called once per frame
    void Update()
    {
        contarEnergia();
        if (juegoContinua)
        {
            actualizarConsumo();
            sinEnergia();
        }
        controlarTiempo();
    }

    public void contarEnergia()
    {
        if (juegoContinua)
        {
            contador += Time.deltaTime;
            if(contador >= tiempoDescuento)
            {
                cansancio -= 1;
                contador = 0;
            }
            
        }
    }

    IEnumerator contarTiempo()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            tiempo++;
        }
    }

    void controlarTiempo()
    {
        if(tiempo == tiempoFinal)
        {
            lanzarFinal(false);
        }
    }

    public void lanzarFinal(bool asesinado)
    {
        Camara.GetComponent<CamaraController>().juegoContinua = false;
        juegoContinua = false;
        if (asesinado)
        {
            UI.SetActive(true);
            Mapa.SetActive(false);
            botonesMapa.SetActive(false);
            //finDelJuegoTexto.gameObject.SetActive(true);
            GameObject.Find("Transicion").GetComponent<Transicion>().oscurecerPantallaMuerte();
            StartCoroutine(hacerCambioTitulo());
        }
        else
        {
            UI.SetActive(true);
            Mapa.SetActive(false);
            botonesMapa.SetActive(false);
            //finDelJuegoTexto.gameObject.SetActive(true);
            GameObject.Find("Transicion").GetComponent<Transicion>().oscurecerPantallaVictoria();
            StartCoroutine(hacerCambioSiguiente());
        }

    }

    IEnumerator hacerCambioTitulo()
    {
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene("Titulo");
    }

    IEnumerator hacerCambioSiguiente()
    {
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene("Gracias");
    }

    void actualizarConsumo()
    {
        float nuevoTiempoDescuento = 9.6f;
        if (!puerta.puertaAbierta)
        {
            nuevoTiempoDescuento /= 2;
        }
        if (!chapa.puertaAbierta)
        {
            nuevoTiempoDescuento /= 2;
        }
        if (Camara.GetComponent<CamaraController>().camaraActual.name != "Sala Principal")
        {
            nuevoTiempoDescuento /= 2;
        }
        tiempoDescuento = nuevoTiempoDescuento;
    }

    void sinEnergia()
    {
        if(cansancio == 0)
        {
            juegoContinua = false;
            Camara.GetComponent<CamaraController>().sinEnergia();
            if (!puerta.puertaAbierta)
            {
                puerta.cambiarSprite();
            }
            if (!chapa.puertaAbierta)
            {
                chapa.cambiarSprite();
            }
        }
    }




}
