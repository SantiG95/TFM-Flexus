using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MesasScript : MonoBehaviour
{
    private CocoControl coco;
    public PatoControl pato;
    public GameObject sinNombre;

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
        if (presenciaEnemigos.cocoPresente && presenciaEnemigos.patoPresente)
        {
            switch (coco.estado)
            {
                case 0:
                    if (pato.estado == 0)
                    {
                        cambiaSprite.cambiarSprite("Mesas", 5);
                    }
                    else
                    {
                        cambiaSprite.cambiarSprite("Mesas", 7);
                    }
                    break;

                case 1:
                    if (pato.estado == 0)
                    {
                        cambiaSprite.cambiarSprite("Mesas", 6);
                    }
                    else
                    {
                        cambiaSprite.cambiarSprite("Mesas", 8);
                    }
                    break;
            }
        }
        else if (presenciaEnemigos.cocoPresente)
        {
            switch (coco.estado)
            {
                case 0:
                    cambiaSprite.cambiarSprite("Mesas", 1);
                    break;

                case 1:
                    cambiaSprite.cambiarSprite("Mesas", 2);
                    break;
            }

        }
        else if (presenciaEnemigos.patoPresente)
        {
            switch (pato.estado)
            {
                case 0:
                    cambiaSprite.cambiarSprite("Mesas", 3);
                    break;

                case 1:
                    cambiaSprite.cambiarSprite("Mesas", 4);
                    break;
            }
        }
        else
        {
            cambiaSprite.cambiarSprite("Mesas", 0);
        }
    }
}
