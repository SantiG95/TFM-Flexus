using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Titulo : MonoBehaviour
{
    GameObject camara;
    CamaraController camaraControl;
    // Start is called before the first frame update
    void Start()
    {
        camara = GameObject.Find("Main Camera");
        camaraControl = camara.GetComponent<CamaraController>();
        transform.position = new Vector2(Screen.width, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
