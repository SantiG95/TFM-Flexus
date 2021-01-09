using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CocoControl : MonoBehaviour
{
    public float contador = 0;

    public int estadoDespertando = 0;
    public bool activo = false;

    public GameObject habitacionActual;
    public GameObject habitacionCamara;


    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(cambiarEtapaDespertar());
    }

    // Update is called once per frame
    void Update()
    {
        verHabitacionMiraCamara();
        cuentaTiempo();

        cambiarEtapaDespertar();
    }

    void cambiarEtapaDespertar()
    {
        if (!activo)
        {
            if (contador > 5f && estadoDespertando != 3)
            {
                estadoDespertando++;
                contador = 0;
            }
            else if (estadoDespertando == 3)
            {
                activo = true;
            }
        }
        
        
        
    }

    void verHabitacionMiraCamara()
    {
        habitacionCamara = GameObject.Find("Main Camera").GetComponent<CamaraController>().camaraActual;
    }

    void cuentaTiempo()
    {
        if(habitacionCamara != habitacionActual)
        {
            contador += Time.deltaTime;
        }
        
    }
}
