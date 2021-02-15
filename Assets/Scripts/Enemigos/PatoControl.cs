using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatoControl : MonoBehaviour
{
    public Animator ataques;
    private SonidosJuego sonidos;
    

    public int dificultad;
    public int dificultadSala;
    public int dificultadNoche;
    public float contador = 0;
    public float contadorAtaque = 0;
    public float contadorLlamado = 0;
    public bool estuvoLlamando = false;

    public int estado = 0;
    public bool activo = false;

    private CamaraController camaraPrincipal;
    public GameObject habitacionActual;
    public GameObject habitacionCamara;

    public GameObject destinoActual;

    public bool juegoActivo = true;


    void Start()
    {
        camaraPrincipal = GameObject.Find("Main Camera").GetComponent<CamaraController>();
        sonidos = GameObject.Find("Main Camera").GetComponent<SonidosJuego>();
        elegirDestino();
    }

    void Update()
    {
        if (juegoActivo)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                destinoActual = GameObject.Find("Sala Principal");
                cambioHabitacion(0);
            }
            verHabitacionMiraCamara();
            cuentaTiempo();
            prepararAtaque();
            prepararMolestia();
            cambioDificultad();

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
            if (contador > 5f && estado != 2 && darUnPaso())
            {
                estado++;
                contador = 0;
                if (estado == 2)
                {
                    activo = true;
                }
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
        if (habitacionCamara != habitacionActual || habitacionActual.name == "Sala Principal")
        {
            contador += Time.deltaTime;
        }
    }

    void moverse()
    {
        if (contador > 5)
        {
            if (darUnPaso())
            {
                switch (habitacionActual.name)
                {
                    case "Fuente":
                        switch (estado)
                        {
                            case 2:
                                estado = 3;
                                break;

                            case 3:
                                cambioHabitacion(0);
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

                    case "Nubes":
                        switch (estado)
                        {
                            case 0:
                                if (Random.Range(0, 10) < 2)
                                {
                                    estado = 1;
                                }
                                else
                                {
                                    estado = 2;
                                }
                                break;

                            case 1:
                                estado = 2;
                                break;

                            case 2:
                                cambioHabitacion(0);
                                break;
                        }
                        break;

                    case "Sala Principal":
                        if (contadorAtaque > (5 - dificultad / 4) && !camaraPrincipal.mirandoCamaras)
                        {
                            hacerAtaque();
                        }
                        else
                        {
                            //sonidoPatoTriste();
                            cambioHabitacion(0);
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
                destinoActual = GameObject.Find("Callejon");
                break;

            case "Callejon":
                if (eligeRandom < 66)
                {
                    destinoActual = GameObject.Find("Mesas");
                }
                else if (eligeRandom < 33)
                {
                    destinoActual = GameObject.Find("Fuente");
                }
                else
                {
                    destinoActual = GameObject.Find("Nubes");
                }

                break;

            case "Mesas":
                if (eligeRandom < 50)
                {
                    destinoActual = GameObject.Find("Callejon");
                }
                else
                {
                    destinoActual = GameObject.Find("Nubes");
                }
                break;

            case "Nubes":
                destinoActual = GameObject.Find("Sala Principal");
                break;

            case "Sala Principal":
                destinoActual = GameObject.Find("Mesas");
                break;
        }
    }

    void cambioHabitacion(int estadoNuevo)
    {
        if(habitacionActual.name == "Sala Principal" && estuvoLlamando && (Random.Range(0, 20) < 20 - dificultadNoche))
        {
            sonidos.reproducirPatoTriste();
        }
        else
        {
            sonidos.reproducirPasosPato();
        }        
        habitacionActual.GetComponent<PresenciaEnemigos>().patoPresente = false;
        habitacionActual = destinoActual;
        habitacionActual.GetComponent<PresenciaEnemigos>().patoPresente = true;
        estado = estadoNuevo;
    }

    public void hacerAtaque()
    {
        if (camaraPrincipal.mirandoCamaras)
        {
            camaraPrincipal.cambiarModo();
        }
        ataques.gameObject.SetActive(true);
        ataques = GameObject.Find("Ataques").GetComponent<Animator>();
        sonidos.reproducirAtaquePato();
        ataques.SetTrigger("PatoAtaca");
        GameObject.Find("Manager").GetComponent<GameManager>().lanzarFinal(true);
    }

    public void desactivar()
    {
        juegoActivo = false;
    }

    public void ponerDificultad(int intDificultad)
    {
        dificultad = intDificultad;
        dificultadSala = dificultad + 5;
        dificultadNoche = dificultad;
    }

    public void aumentarDificultad()
    {
        dificultadNoche++;
    }

    public void disminuirDificultad()
    {
        dificultadNoche--;
    }

    public void sonidoPatoTriste()
    {
        sonidos.reproducirPatoTriste();
    }

    void prepararAtaque()
    {
        if (habitacionActual.name == "Sala Principal" && !camaraPrincipal.mirandoCamaras)
        {
            contadorAtaque += Time.deltaTime;
        }
        else if (habitacionActual.name != "Sala Principal")
        {
            contadorAtaque = 0;
        }
    }

    void prepararMolestia()
    {
        if (habitacionActual.name == "Sala Principal")
        {
            contadorLlamado += Time.deltaTime;
        }
        else
        {
            contadorLlamado = 0;
            estuvoLlamando = false;
        }

        if (contadorLlamado > 7 && habitacionCamara.name != "Sala Principal")
        {
            sonidos.reproducirPatoLlamado();
            contadorLlamado = 0;
            estuvoLlamando = true;
        }
    }

    void cambioDificultad()
    {
        if(habitacionActual.name == "Sala Principal")
        {
            dificultad = dificultadSala;
        }
        else
        {
            dificultad = dificultadNoche;
        }
    }
}
