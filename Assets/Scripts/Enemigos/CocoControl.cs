using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CocoControl : MonoBehaviour
{
    public Animator ataques;
    private SonidosJuego sonidos;

    public int dificultad;
    public float contador = 0;

    public int estado = 0;
    public bool activo = false;

    private CamaraController camaraPrincipal;
    public GameObject habitacionActual;
    public GameObject habitacionCamara;

    public GameObject destinoActual;

    private PuertaController puerta;

    public bool juegoActivo = true;
        

    void Start()
    {
        camaraPrincipal = GameObject.Find("Main Camera").GetComponent<CamaraController>();
        sonidos = GameObject.Find("Main Camera").GetComponent<SonidosJuego>();
        puerta = GameObject.Find("Puerta").GetComponent<PuertaController>();
        elegirDestino();
    }

    void Update()
    {
        if (juegoActivo)
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
    }

    private bool llegoDestino()
    {
        return habitacionActual == destinoActual;

    }

    void cambiarEtapaDespertar()
    {
        if (!activo)
        {
            if (contador > 5f && estado != 3 && darUnPaso())
            {
                estado++;
                contador = 0;
            }
            else if (contador > 5f && estado == 3)
            {
                activo = true;
            }
            else if (contador > 5f)
            {
                contador = 0;
            }
        }
    }

    void verHabitacionMiraCamara()
    {
        habitacionCamara = camaraPrincipal.camaraActual;
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
        if(contador > 5)
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
                                if (Random.Range(0, 100) < 75)
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
                                if (Random.Range(0, 100) < 20)
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
                        if (puerta.puertaAbierta)
                        {
                            hacerAtaque();
                        }
                        else
                        {
                            puerta.sonidoPuertaGolpeada();
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
        return Random.Range(1, 21) < dificultad;
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
        if (habitacionActual.name != "Sala Principal")
        {
            sonidos.reproducirPasosCoco();
        }
        habitacionActual.GetComponent<PresenciaEnemigos>().cocoPresente = false;
        habitacionActual = destinoActual;
        habitacionActual.GetComponent<PresenciaEnemigos>().cocoPresente = true;
        estado = estadoNuevo;
    }

    public void hacerAtaque()
    {
        if(camaraPrincipal.mirandoCamaras)
        {
            camaraPrincipal.cambiarModo();
        }
        ataques.gameObject.SetActive(true);
        ataques = GameObject.Find("Ataques").GetComponent<Animator>();
        sonidos.reproducirAtaqueCoco();
        ataques.SetTrigger("CocoAtaca");
        GameObject.Find("Manager").GetComponent<GameManager>().lanzarFinal(true);
    }

    public void desactivar()
    {
        juegoActivo = false;
    }

    public void ponerDificultad(int intDificultad)
    {
        dificultad = intDificultad;
    }

    public void aumentarDificultad()
    {
        dificultad++;
    }
}
