using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuenteScript : MonoBehaviour
{
    private CocoControl coco;
    public PatoControl pato;
    public GameObject sinNombre;
    private int sinNombreEstado = 0;

    private SpriteHabitaciones cambiaSprite;
    private PresenciaEnemigos presenciaEnemigos;

    // Start is called before the first frame update
    void Start()
    {
        coco = GameObject.Find("Coco").GetComponent<CocoControl>();
        pato = GameObject.Find("Pato").GetComponent<PatoControl>();

        cambiaSprite = GameObject.Find("Lugares").GetComponent<SpriteHabitaciones>();
        presenciaEnemigos = GetComponent<PresenciaEnemigos>();
    }

    // Update is called once per frame
    void Update()
    {
        detectarEnemigos();
    }

    void detectarEnemigos()
    {
        /*if (presenciaEnemigos.cocoPresente && presenciaEnemigos.patoPresente && presenciaEnemigos.sinNombrePresente)
        {
            switch (coco.estado)
               {
                case 0:
                    cambiaSprite.cambiarSprite("Fuente", 0);
                    break;

                case 1:
                    cambiaSprite.cambiarSprite("Fuente", 1);
                    break;

                case 2:
                    cambiaSprite.cambiarSprite("Fuente", 2);
                    break;
                
                case 3:
                    cambiaSprite.cambiarSprite("Fuente", 3);
                    break;

                case 4:
                    cambiaSprite.cambiarSprite("Fuente", 4);
                    break;

                case 5:
                    cambiaSprite.cambiarSprite("Fuente", 5);
                    break;
            }
            
        }
        else
        {
            cambiaSprite.cambiarSprite("Fuente", 0);
        }*/

        if (presenciaEnemigos.sinNombrePresente && sinNombreEstado != 0)
        {
            //TODO completar cuando tengamos a Sin Nombre
            switch (sinNombreEstado)
            {
                case 1:
                    break;
            }
        }
        else if (presenciaEnemigos.patoPresente)
        {
            switch (pato.estado)
            {
                case 0:
                    if (presenciaEnemigos.cocoPresente && coco.estado != 0)
                    {
                        switch (coco.estado)
                        {
                            case 1:
                                cambiaSprite.cambiarSprite("Fuente", 1);
                                break;

                            case 2:
                                cambiaSprite.cambiarSprite("Fuente", 2);
                                break;

                            case 3:
                                cambiaSprite.cambiarSprite("Fuente", 3);
                                break;

                            case 4:
                                cambiaSprite.cambiarSprite("Fuente", 4);
                                break;

                            case 5:
                                cambiaSprite.cambiarSprite("Fuente", 5);
                                break;
                        }
                    }
                    else
                    {
                        cambiaSprite.cambiarSprite("Fuente", 0);
                    }
                    break;

                case 1:
                    if (presenciaEnemigos.cocoPresente && coco.estado != 0)
                    {
                        switch (coco.estado)
                        {
                            case 1:
                                cambiaSprite.cambiarSprite("Fuente", 9);
                                break;

                            case 2:
                                cambiaSprite.cambiarSprite("Fuente", 10);
                                break;

                            case 3:
                                cambiaSprite.cambiarSprite("Fuente", 11);
                                break;

                            case 4:
                                cambiaSprite.cambiarSprite("Fuente", 12);
                                break;

                            case 5:
                                cambiaSprite.cambiarSprite("Fuente", 13);
                                break;

                        }
                    }
                    else
                    {
                        cambiaSprite.cambiarSprite("Fuente", 6);
                    }
                    break;

                case 2:
                    if (presenciaEnemigos.cocoPresente && coco.estado != 0)
                    {
                        switch (coco.estado)
                        {
                            case 1:
                                cambiaSprite.cambiarSprite("Fuente", 14);
                                break;

                            case 2:
                                cambiaSprite.cambiarSprite("Fuente", 15);
                                break;

                            case 3:
                                cambiaSprite.cambiarSprite("Fuente", 16);
                                break;

                            case 4:
                                cambiaSprite.cambiarSprite("Fuente", 17);
                                break;

                            case 5:
                                cambiaSprite.cambiarSprite("Fuente", 18);
                                break;

                        }
                    }
                    else
                    {
                        cambiaSprite.cambiarSprite("Fuente", 7);
                    }
                    break;

                case 3:
                    if (presenciaEnemigos.cocoPresente && coco.estado != 0)
                    {
                        switch (coco.estado)
                        {
                            case 1:
                                cambiaSprite.cambiarSprite("Fuente", 19);
                                break;

                            case 2:
                                cambiaSprite.cambiarSprite("Fuente", 20);
                                break;

                            case 3:
                                cambiaSprite.cambiarSprite("Fuente", 21);
                                break;

                            case 4:
                                cambiaSprite.cambiarSprite("Fuente", 22);
                                break;

                            case 5:
                                cambiaSprite.cambiarSprite("Fuente", 23);
                                break;

                        }
                    }
                    else
                    {
                        cambiaSprite.cambiarSprite("Fuente", 8);
                    }
                    break;
            }
        }
        else if (presenciaEnemigos.cocoPresente && coco.estado != 0)
        {
            switch (coco.estado)
            {
                case 1:
                    cambiaSprite.cambiarSprite("Fuente", 25);
                    break;

                case 2:
                    cambiaSprite.cambiarSprite("Fuente", 26);
                    break;

                case 3:
                    cambiaSprite.cambiarSprite("Fuente", 27);
                    break;

                case 4:
                    cambiaSprite.cambiarSprite("Fuente", 28);
                    break;

                case 5:
                    cambiaSprite.cambiarSprite("Fuente", 29);
                    break;
            }
        }
        else
        {
            if (presenciaEnemigos.patoPresente)
            {
                cambiaSprite.cambiarSprite("Fuente", 0);
            }
            else
            {
                cambiaSprite.cambiarSprite("Fuente", 24);
            }
            
        }
    }
}
