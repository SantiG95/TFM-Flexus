using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalaPrincipalScript : MonoBehaviour
{
    private CocoControl coco;
    public GameObject pato;
    public GameObject sinNombre;

    private SpriteHabitaciones cambiaSprite;
    private PuertaController puerta;
    private PresenciaEnemigos presenciaEnemigos;

    // Start is called before the first frame update
    void Start()
    {
        coco = GameObject.Find("Coco").GetComponent<CocoControl>();

        cambiaSprite = GameObject.Find("Lugares").GetComponent<SpriteHabitaciones>();
        puerta = GameObject.Find("Puerta").GetComponent<PuertaController>();
        presenciaEnemigos = GetComponent<PresenciaEnemigos>();
    }

    // Update is called once per frame
    void Update()
    {
        //detectarEnemigos();
    }

    /*void detectarEnemigos()
    {
        if (presenciaEnemigos.cocoPresente && patoPresente && sinNombrePresente)
        {
            switch (coco.estado)
            {
                case 0:
                    puerta.cambiarSprite(2);
                    break;
            }

        }
        else
        {
            cambiaSprite.cambiarSprite("Callejon", 0);
        }
    }*/
}