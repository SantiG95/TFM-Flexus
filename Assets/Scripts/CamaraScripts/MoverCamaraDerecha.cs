using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverCamaraDerecha : MonoBehaviour
{
    public GameObject camara;
    public float velocidad = 5;
    public GameObject bordeDerecho;

    // Limite
    public float limiteDerecho = 11.1f;
    
    private void OnMouseOver()
    {
        if (bordeDerecho.transform.position.x < limiteDerecho)
        {
            camara.transform.Translate(Vector3.right * velocidad * Time.deltaTime);
        }
        
    }
}
