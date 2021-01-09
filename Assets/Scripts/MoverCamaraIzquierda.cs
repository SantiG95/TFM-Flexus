using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverCamaraIzquierda : MonoBehaviour
{
    public GameObject camara;
    public float velocidad = 5;

    // Limite
    public float limiteIzquierdo = -2.21f;
    
    private void OnMouseOver()
    {
        if (camara.transform.position.x > limiteIzquierdo)
        {
            camara.transform.Translate(Vector3.left * velocidad * Time.deltaTime);
        }

    }
}
