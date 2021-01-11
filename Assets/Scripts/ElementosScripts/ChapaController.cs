using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapaController : MonoBehaviour
{
    public bool puertaAbierta = true;

    private Animator animatorChapa;
    // Start is called before the first frame update
    void Start()
    {
        animatorChapa = GetComponent<Animator>();
        animatorChapa.SetBool("Abierto", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (puertaAbierta)
        {
            animatorChapa.SetTrigger("Moviendo");
            
            puertaAbierta = false;
            animatorChapa.SetBool("Abierto", false);
        }
        else
        {
            animatorChapa.SetTrigger("Moviendo");
            animatorChapa.SetBool("Abierto", true);
            puertaAbierta = true;
        }
        
    }
}
