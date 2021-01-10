using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CocoControl : MonoBehaviour
{
    public float contador = 0;

    public int estado = 0;
    public bool activo = false;

    public GameObject habitacionActual;
    public GameObject habitacionCamara;

    public GameObject destinoActual;


    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(cambiarEtapaDespertar());
        elegirDestino();
    }

    // Update is called once per frame
    void Update()
    {
        verHabitacionMiraCamara();
        cuentaTiempo();

        if (!activo)
        {
            cambiarEtapaDespertar();
        }
        else
        {
            moverse();
            if (llegoDestino())
            {
                elegirDestino();
            }
        }
        
    }

    private bool llegoDestino()
    {
        return habitacionActual == destinoActual;

    }

    void cambiarEtapaDespertar()
    {
        if (!activo)
        {
            //TODO tiempo despertar random
            if (contador > 5f && estado != 3)
            {
                estado++;
                contador = 0;
            }
            else if (estado == 3)
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

    void moverse()
    {
        //TODO tiempo desicion random
        if(contador > 5)
        {
            switch (habitacionActual.name)
            {
                case "Fuente":
                    switch (estado)
                    {
                        case 3:
                            if (destinoActual.name == "Exterior")
                            {
                                estado = 5;
                            }
                            else
                            {
                                estado = 4;
                            }
                            break;

                        case 4:
                        case 5:
                            habitacionActual.GetComponent<FuenteScript>().cocoPresente = false;
                            habitacionActual = destinoActual;
                            //habitacionActual.GetComponent<FuenteScript>().cocoPresente = true;
                            break;
                    }
                    break;
            }
            contador = 0;
        }
        
    }

    void elegirDestino()
    {
        int eligeRandom = Random.Range(0, 100);
        switch (habitacionActual.name)
        {
            case "Fuente":
                if(eligeRandom < 50)
                {
                    destinoActual = GameObject.Find("Exterior");
                }
                else
                {
                    destinoActual = GameObject.Find("Callejon");
                }
                break;

            case "Exterior":
                destinoActual = GameObject.Find("Fuente");
                break;
        }
    }
}
