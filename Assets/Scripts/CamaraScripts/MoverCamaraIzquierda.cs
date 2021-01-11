using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverCamaraIzquierda : MonoBehaviour
{
    public GameObject camara;
    public float velocidad = 5;
    public GameObject bordeIzquierdo;

    // Limite
    public float limiteIzquierdo = -11.1f;
    
    private void OnMouseOver()
    {
        if (bordeIzquierdo.transform.position.x > limiteIzquierdo)
        {
            camara.transform.Translate(Vector3.left * velocidad * Time.deltaTime);
        }

    }
}
