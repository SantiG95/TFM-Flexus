using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class tituloFondo : MonoBehaviour
{
    public GameObject imagen1;
    public GameObject imagen2;
    public GameObject imagen3;
    public float tiempoMaximo = 2;

    private List<GameObject> imagenes = new List<GameObject>();

    void Start()
    {
        armarListaInicial();

        StartCoroutine(cambiaImagen());
    }

    void armarListaInicial()
    {
        // Añade las imagenes a la lista
        for (int i = 0; i < 3; i++)
        {
            imagenes.Add(imagen1);
        }
        imagenes.Add(imagen2);
        imagenes.Add(imagen3);
    }

    IEnumerator cambiaImagen()
    {
        // Codigo que cambia las imagenes
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(0, tiempoMaximo));
            alternarImagenes();
            yield return new WaitForSeconds(Random.Range(0, 0.5f));
            regresarImagen();
        }
    }

    void alternarImagenes()
    {
        // Elige una imagen y desactiva las que esten por encima
        GameObject imagenElegida = imagenes[Random.Range(0, imagenes.Count)];

        switch (imagenElegida.name)
        {
            case "Imagen2":
                imagen1.SetActive(false);
                break;

            case "Imagen3":
                imagen1.SetActive(false);
                imagen2.SetActive(false);
                break;
        }
    }

    void regresarImagen()
    {
        // Reactiva todas las imagenes desactivables
        imagen1.SetActive(true);
        imagen2.SetActive(true);
    }

    

    
}
