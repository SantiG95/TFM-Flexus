using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NubesScript : MonoBehaviour
{
    private CocoControl coco;
    private PatoControl pato;
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
        if (presenciaEnemigos.patoPresente)
        {
            Debug.Log("entro");
            switch (pato.estado)
            {
                case 0:
                    cambiaSprite.cambiarSprite("Nubes", 1);
                    break;

                case 1:
                    cambiaSprite.cambiarSprite("Nubes", 2);
                    break;

                case 2:
                    cambiaSprite.cambiarSprite("Nubes", 3);
                    break;
            }
        }
        else
        {
            cambiaSprite.cambiarSprite("Nubes", 0);
        }
    }
}
