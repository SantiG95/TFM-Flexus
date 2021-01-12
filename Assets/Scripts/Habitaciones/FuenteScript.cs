using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuenteScript : MonoBehaviour
{
    private CocoControl coco;
    public GameObject pato;
    public GameObject sinNombre;

    private SpriteHabitaciones cambiaSprite;
    private PresenciaEnemigos presenciaEnemigos;

    // Start is called before the first frame update
    void Start()
    {
        coco = GameObject.Find("Coco").GetComponent<CocoControl>();

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
        if (presenciaEnemigos.cocoPresente && presenciaEnemigos.patoPresente && presenciaEnemigos.sinNombrePresente)
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
        }
    }
}
