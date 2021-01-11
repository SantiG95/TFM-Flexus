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
                Debug.Log("cambio destino");
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
        if(contador > 5 && darUnPaso())
        {
            if (darUnPaso())
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
                                cambioHabitacion();
                                estado = 0;
                                break;

                            case 5:
                                cambioHabitacion();

                                if (Random.Range(0,100) < 50)
                                {
                                    estado = 0;
                                }
                                else
                                {
                                    estado = 1;
                                }
                                Debug.Log("Estado actual: " + estado);
                                break;
                        }
                        break;

                    case "Exterior":
                        switch (estado)
                        {
                            case 0:
                                if (Random.Range(0,100) < 20)
                                {
                                    estado = 1;
                                }
                                else
                                {
                                    cambioHabitacion();
                                    estado = 3;
                                }
                                break;

                            case 1:
                                if (Random.Range(0, 100) < 50)
                                {
                                    estado = 0;
                                }
                                else
                                {
                                    cambioHabitacion();
                                    estado = 3;
                                }
                            
                                break;
                        }
                        break;

                    case "Callejon":
                        switch (estado)
                        {
                            case 0:
                                if (destinoActual.name == "Fuente")
                                {
                                    cambioHabitacion();
                                    estado = 3;
                                }
                                else
                                {
                                    estado = 1;
                                }
                                break;

                            case 1:
                                cambioHabitacion();
                                estado = 0;
                                break;
                        }
                        break;

                    case "Mesas":
                        switch (estado)
                        {
                            case 0:
                                estado = 1;
                                break;

                            case 1:
                                cambioHabitacion();
                                estado = 0;
                                break;
                        }
                        break;


                }
            }
            contador = 0;
        }
        
    }

    bool darUnPaso()
    {
        return Random.Range(0, 100) < 50;
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

            case "Callejon":
                if (eligeRandom < 70)
                {
                    destinoActual = GameObject.Find("Mesas");
                }
                else
                {
                    destinoActual = GameObject.Find("Fuente");
                }
                break;

            case "Mesas":
                destinoActual = GameObject.Find("Sala Principal");
                break;
        }
    }

    void cambioHabitacion()
    {
        habitacionActual.GetComponent<PresenciaEnemigos>().cocoPresente = false;
        habitacionActual = destinoActual;
        habitacionActual.GetComponent<PresenciaEnemigos>().cocoPresente = true;
    }
}
