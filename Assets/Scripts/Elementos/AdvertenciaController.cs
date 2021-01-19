using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdvertenciaController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(tiempoAdvertencia());
    }
    
    IEnumerator tiempoAdvertencia()
    {
        yield return new WaitForSeconds(7);
        SceneManager.LoadScene("Titulo");
    }
}
