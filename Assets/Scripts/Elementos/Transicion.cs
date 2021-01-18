using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Transicion : MonoBehaviour
{
    private Image pantallaNegra;
    public  GameObject pantallaBlanca;
    public Text textoNoche;
    public Text horaFinalTexto;
    private SonidosJuego sonidosJuego;

    // Start is called before the first frame update
    void Start()
    {
        sonidosJuego = GameObject.Find("Main Camera").GetComponent<SonidosJuego>();
        textoNoche.text = "Noche " + GameObject.Find("Manager").GetComponent<GameManager>().numeroNoche;

        pantallaNegra = GetComponent<Image>();
        StartCoroutine(transicionCamara(true));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator transicionCamara(bool despejar)
    {
        if (despejar)
        {
            yield return new WaitForSeconds(3);
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                pantallaNegra.color = new Color(1, 1, 1, i);
                textoNoche.color = new Color(1, 1, 1, i);
                yield return null;
            }
            GetComponent<Canvas>().sortingOrder = -1;

        }
        else
        {
            yield return new WaitForSeconds(1);
            GetComponent<Canvas>().sortingOrder = 2;
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                // set color with i as alpha
                pantallaNegra.color = new Color(1, 1, 1, i);
                yield return null;

            }
        }
    }

    public void oscurecerPantallaMuerte()
    {
        StartCoroutine(oscurecerPorMuerte());
    }

    IEnumerator oscurecerPorMuerte()
    {
        yield return new WaitForSeconds(1);
        pantallaBlanca.SetActive(true);
        textoNoche.text = "FIN DEL JUEGO";
        GetComponent<Canvas>().sortingOrder = 2;
        yield return new WaitForSeconds(0.5f);
        for (float i = 0; i <= 1; i += Time.deltaTime)
        {
            // set color with i as alpha
            pantallaNegra.color = new Color(1, 1, 1, i);
            textoNoche.color = new Color(1, 1, 1, i);
            yield return null;
        }
    }


    public void oscurecerPantallaVictoria()
    {
        StartCoroutine(oscurecerPorVictoria());
    }

    IEnumerator oscurecerPorVictoria()
    {
        GetComponent<Canvas>().sortingOrder = 2;
        sonidosJuego.reproducirAlarma();
        for (float i = 0; i <= 1; i += Time.deltaTime)
        {
            // set color with i as alpha
            pantallaNegra.color = new Color(1, 1, 1, i);
            horaFinalTexto.color = new Color(1, 1, 1, i);
            yield return null;
        }
        yield return new WaitForSeconds(2);
        sonidosJuego.reproducirVictoria();
        yield return new WaitForSeconds(6);

    }
}
