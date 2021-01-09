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
            if (!coco.activo)
            {
                switch (coco.estadoDespertando)
                {
                    case 0:
                        spriteFuente.sprite = fuente0;
                        break;

                    case 1:
                        spriteFuente.sprite = fuente1;
                        break;

                    case 2:
                        spriteFuente.sprite = fuente2;
                        break;
                }
            }
            else
            {
                spriteFuente.sprite = fuente3;
            }
            
        }
    }
}
