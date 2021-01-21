using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotonController : MonoBehaviour
{
    private Image imagenBoton; 
    // Start is called before the first frame update
    void Start()
    {
        imagenBoton = GetComponent<Image>();
        StartCoroutine(hacerTransparente());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void botonPresionado()
    {
        GameObject.Find("Main Camera").GetComponent<CamaraController>().cambiarModo();
    }

    IEnumerator hacerTransparente()
    {
        yield return new WaitForSeconds(30);
        for (float i = 1; i >= 0; i -= Time.deltaTime)
        {
            // set color with i as alpha
            imagenBoton.color = new Color(1, 1, 1, i);
            yield return null;
        }
    }

}
