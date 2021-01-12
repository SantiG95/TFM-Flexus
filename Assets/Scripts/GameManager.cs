using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject UI;
    public GameObject Mapa;
    public GameObject botonesMapa;
    public List<GameObject> listaEnemigos;
    public GameObject Camara;
    public GameObject finDelJuegoTexto;
    public bool juegoContinua = true;
    public int tiempoFinal = 540;

    public float tiempo = 0;
    public float cansancio = 100;

    public float contadorReset = 0;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(contarEnergia());
        StartCoroutine(contarTiempo());
    }

    // Update is called once per frame
    void Update()
    {
        contarTiempo();
        controlarTiempo();
    }

    IEnumerator contarEnergia()
    {
        while (juegoContinua)
        {
            yield return new WaitForSeconds(9.6f);
            cansancio -= 1;
        }
    }

    IEnumerator contarTiempo()
    {
        while (juegoContinua)
        {
            yield return new WaitForSeconds(1);
            tiempo++;
        }
    }

    void controlarTiempo()
    {
        if(tiempo == tiempoFinal)
        {
            //lanzarFinal(false);
            lanzarFinal(true);
        }
    }

    public void lanzarFinal(bool asesinado)
    {
        Camara.GetComponent<CamaraController>().juegoContinua = false;
        listaEnemigos[0].GetComponent<CocoControl>().juegoActivo = false;
        if (asesinado)
        {
            UI.SetActive(true);
            Mapa.SetActive(false);
            botonesMapa.SetActive(false);
            finDelJuegoTexto.gameObject.SetActive(true);
            StartCoroutine(hacerCambioTitulo());

        }
    }

    IEnumerator hacerCambioTitulo()
    {
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene("Titulo");
    }

    

}
