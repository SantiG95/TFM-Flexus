using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CocoControl : MonoBehaviour
{
    private Animator cocoAtaca;
    private SonidosJuego sonidos;

    public float contador = 0;

    public int estado = 0;
    public bool activo = false;

    public GameObject habitacionActual;
    public GameObject habitacionCamara;

    public GameObject destinoActual;

    public bool puertaAbierta;
    public int quieroMoverme = 0;

    public bool juegoActivo = true;


    void Start()
    {
        sonidos = GameObject.Find("Main Camera").GetComponent<SonidosJuego>();
        cocoAtaca = GameObject.Find("Sala Principal").GetComponent<Animator>();
        elegirDestino();
    }

    void Update()
    {
        juegoActivo = GameObject.Find("Manager").GetComponent<GameManager>().juegoContinua;
        if (juegoActivo)
        {
            verHabitacionMiraCamara();
            cuentaTiempo();
            puertaAbierta = GameObject.Find("Puerta").GetComponent<PuertaController>().puertaAbierta;

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
        if(habitacionCamara != habitacionActual || habitacionActual.name == "Sala Principal")
        {
            contador += Time.deltaTime;
        }

        
    }

    void moverse()
    {
        //TODO tiempo desicion random
        if(contador > 5 && darUnPaso() && juegoActivo)
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
                                cambioHabitacion(0);
                                break;

                            case 5:
                                if (Random.Range(0,100) < 50)
                                {
                                    cambioHabitacion(0);
                                }
                                else
                                {
                                    cambioHabitacion(1);
                                }
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
                                    cambioHabitacion(3);
                                }
                                break;

                            case 1:
                                if (Random.Range(0, 100) < 50)
                                {
                                    estado = 0;
                                }
                                else
                                {
                                    cambioHabitacion(3);
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
                                    cambioHabitacion(3);
                                }
                                else
                                {
                                    estado = 1;
                                }
                                break;

                            case 1:
                                cambioHabitacion(0);
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
                                cambioHabitacion(0);
                                break;
                        }
                        break;

                    case "Sala Principal":
                        if (puertaAbierta)
                        {
                            //TODO matar y terminar el juego
                            GameObject.Find("Sala Principal").GetComponent<SalaPrincipalScript>().cocoAtaca();
                        }
                        else
                        {
                            GameObject.Find("Puerta").GetComponent<PuertaController>().sonidoPuertaGolpeada();
                            if (destinoActual.name == "Fuente")
                            {
                                cambioHabitacion(3);
                            }
                            else
                            {
                                cambioHabitacion(0);

                            }
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

            case "Sala Principal":
                if (eligeRandom < 50)
                {
                    destinoActual = GameObject.Find("Fuente");
                }
                else
                {
                    destinoActual = GameObject.Find("Callejon");
                }
                break;
        }
    }

    void cambioHabitacion(int estadoNuevo)
    {
        habitacionActual.GetComponent<PresenciaEnemigos>().cocoPresente = false;
        habitacionActual = destinoActual;
        habitacionActual.GetComponent<PresenciaEnemigos>().cocoPresente = true;
        estado = estadoNuevo;
        sonidos.reproducirPasosCoco();

    }
}
