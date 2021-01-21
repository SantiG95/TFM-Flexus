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

    private void Update()
    {
        if (Input.anyKey)
        {
            SceneManager.LoadScene("Titulo");
        }
    }

    IEnumerator tiempoAdvertencia()
    {
        yield return new WaitForSeconds(7);
        SceneManager.LoadScene("Titulo");
    }
}
