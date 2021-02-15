using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiscinaScript : MonoBehaviour
{
    private CocoControl coco;
    public PatoControl pato;
    public GameObject sinNombre;
    public CamaraController camara; 

    private SpriteHabitaciones cambiaSprite;
    private PresenciaEnemigos presenciaEnemigos;

    private bool perroPresente = false;
    private bool continuaMirando = false;

    // Start is called before the first frame update
    void Start()
    {
        coco = GameObject.Find("Coco").GetComponent<CocoControl>();
        pato = GameObject.Find("Pato").GetComponent<PatoControl>();

        camara = GameObject.Find("Main Camera").GetComponent<CamaraController>();

        cambiaSprite = GameObject.Find("Lugares").GetComponent<SpriteHabitaciones>();
        presenciaEnemigos = GetComponent<PresenciaEnemigos>();
    }
   

    // Update is called once per frame
    void Update()
    {
        if (camaraMeMira() && ((Random.Range(0, 10) ==  0 && !continuaMirando) || perroPresente))
        {
            cambiaSprite.cambiarSprite("Piscina", 1);
            perroPresente = true;
            continuaMirando = true;
        }
        else if (camaraMeMira())
        {
            continuaMirando = true;
        }
        else
        {
            cambiaSprite.cambiarSprite("Piscina", 0);
            perroPresente = false;
            continuaMirando = false;
        }
    }

    bool camaraMeMira()
    {
        return camara.camaraActual.name == "Piscina";
    }
}
