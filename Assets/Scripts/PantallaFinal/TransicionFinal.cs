using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TransicionFinal : MonoBehaviour
{
    private Image pantallaNegra;
    private SonidosJuego sonidosJuego;

    // Start is called before the first frame update
    void Start()
    {
        sonidosJuego = GameObject.Find("Main Camera").GetComponent<SonidosJuego>();

        pantallaNegra = GetComponent<Image>();
        StartCoroutine(transicionCamara(true));
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator transicionCamara(bool despejar)
    {
        for (float i = 1; i >= 0; i -= Time.deltaTime)
        {
            // set color with i as alpha
            pantallaNegra.color = new Color(1, 1, 1, i);
            yield return null;
        }

        yield return new WaitForSeconds(7);
        for (float i = 0; i <= 1; i += Time.deltaTime)
        {
            // set color with i as alpha
            pantallaNegra.color = new Color(1, 1, 1, i);
            yield return null;
        }

        SceneManager.LoadScene("Titulo");
    }

    
}

