using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimeraCamara : MonoBehaviour
{
    public BotonMapa botonMapa;

    // Start is called before the first frame update
    void Start()
    {
        botonMapa.GetComponent<BotonMapa>().camaraActiva();
    }
}
