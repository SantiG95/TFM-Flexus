using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CartaControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(mostrarCarta());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator mostrarCarta()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Juego");
        Debug.Log("Cargando");
    }
}
