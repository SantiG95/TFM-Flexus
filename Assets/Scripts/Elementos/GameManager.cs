using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int numeroNoche;

    public GameObject transicion;
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


    // Start is called before the first frame update
    void Start()
    {
        puerta = GameObject.Find("Puerta").GetComponent<PuertaController>();
        chapa = GameObject.Find("Chapa").GetComponent<ChapaController>();

        transicion.SetActive(true);
        cargarPartida();
        prepararPartida();

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
            actualizarEnemigos();
        }
    }

    void controlarTiempo()
    {
        if(tiempo == tiempoFinal)
        {
            lanzarFinal(false);
            tiempo = 0;
            guardarPartida();
        }
    }

    public void lanzarFinal(bool asesinado)
    {
        desactivarEnemigos(); 
        juegoContinua = false;
        UI.SetActive(true);
        Mapa.SetActive(false);
        botonesMapa.SetActive(false);
        if (asesinado)
        {
            GameObject.Find("Transicion").GetComponent<Transicion>().oscurecerPantallaMuerte();
            StartCoroutine(hacerCambioTitulo());
        }
        else
        {
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
        if (numeroNoche <= 5)
        {
            SceneManager.LoadScene("Juego");
        }
        else
        {
            SceneManager.LoadScene("Gracias");
        }
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

    void guardarPartida()
    {
        int mejorNoche = PlayerPrefs.GetInt("mejorNoche");
        if(numeroNoche < 5)
        {
            numeroNoche++;
        }

        if(numeroNoche > mejorNoche)
        {
            PlayerPrefs.SetInt("mejorNoche", numeroNoche);
        }
        PlayerPrefs.SetInt("nocheActual", numeroNoche);
    }

    void cargarPartida()
    {
        numeroNoche = PlayerPrefs.GetInt("nocheActual");
    }

    void prepararPartida()
    {
        switch (numeroNoche)
        {
            case 1:
                listaEnemigos[0].GetComponent<CocoControl>().ponerDificultad(2);
                listaEnemigos[1].GetComponent<PatoControl>().ponerDificultad(0);
                break;

            case 2:
                listaEnemigos[0].GetComponent<CocoControl>().ponerDificultad(5);
                listaEnemigos[1].GetComponent<PatoControl>().ponerDificultad(2);
                break;

            case 3:
                listaEnemigos[0].GetComponent<CocoControl>().ponerDificultad(7);
                listaEnemigos[1].GetComponent<PatoControl>().ponerDificultad(10);
                break;

            case 4:
                listaEnemigos[0].GetComponent<CocoControl>().ponerDificultad(10);
                listaEnemigos[1].GetComponent<PatoControl>().ponerDificultad(7);
                break;

            case 5:
                listaEnemigos[0].GetComponent<CocoControl>().ponerDificultad(13);
                listaEnemigos[1].GetComponent<PatoControl>().ponerDificultad(12);
                break;
        }
        
    }

    void desactivarEnemigos()
    {
        listaEnemigos[0].GetComponent<CocoControl>().desactivar();
        listaEnemigos[1].GetComponent<PatoControl>().desactivar();
    }

    void actualizarEnemigos()
    {
        switch (tiempo)
        {
            case 180:
                listaEnemigos[0].GetComponent<CocoControl>().aumentarDificultad();
                break;

            case 270:
                listaEnemigos[0].GetComponent<CocoControl>().aumentarDificultad();
                listaEnemigos[1].GetComponent<PatoControl>().aumentarDificultad();
                break;

            case 360:
                listaEnemigos[0].GetComponent<CocoControl>().aumentarDificultad();
                listaEnemigos[1].GetComponent<PatoControl>().aumentarDificultad();
                break;
        }
    }



}
