using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverCamaraDerecha : MonoBehaviour
{
    public GameObject camara;
    public float velocidad = 5;

    // Limite
    public float limiteDerecho = 2.21f;
    
    private void OnMouseOver()
    {
        if (camara.transform.position.x < limiteDerecho)
        {
            camara.transform.Translate(Vector3.right * velocidad * Time.deltaTime);
        }
        
    }
}
