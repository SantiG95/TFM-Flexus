using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuenteScript : MonoBehaviour
{

    private CocoControl coco;
    public GameObject pato;
    public GameObject sinNombre;

    public bool cocoPresente = true;
    public bool patoPresente = true;
    public bool sinNombrePresente = true;

    private SpriteRenderer spriteFuente;
    private GameObject fuenteGameObject;
    private SpriteHabitaciones cambiaSprite;

    public Sprite fuente0;
    public Sprite fuente1;
    public Sprite fuente2;
    public Sprite fuente3;
    public Sprite fuente4;
    public Sprite fuente5;


    // Start is called before the first frame update
    void Start()
    {
        coco = GameObject.Find("Coco").GetComponent<CocoControl>();

        spriteFuente = GetComponent<SpriteRenderer>();
        fuenteGameObject = GameObject.Find("Fuente");
        cambiaSprite = GameObject.Find("Lugares").GetComponent<SpriteHabitaciones>();
    }

    // Update is called once per frame
    void Update()
    {
        detectarEnemigos();
    }

    void detectarEnemigos()
    {
        if (cocoPresente && patoPresente && sinNombrePresente)
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
