using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteHabitaciones : MonoBehaviour
{
    public List<Sprite> Fuente;
    public List<Sprite> Exterior;
    public List<Sprite> Callejon;
    public List<Sprite> Mesas;
    public List<Sprite> Nubes;
    public List<Sprite> Piscina;
    public List<Sprite> Puente;
    public List<Sprite> SalaPrincipal;

    public void cambiarSprite(string nombreHabitacion, int numeroLista)
    {
        switch (nombreHabitacion)
        {
            case "Fuente":
                GameObject.Find("Fuente").GetComponent<SpriteRenderer>().sprite = Fuente[numeroLista];
                break;

            case "Exterior":
                GameObject.Find("Exterior").GetComponent<SpriteRenderer>().sprite = Exterior[numeroLista];
                break;

            case "Callejon":
                GameObject.Find("Callejon").GetComponent<SpriteRenderer>().sprite = Callejon[numeroLista];
                break;

            case "Mesas":
                GameObject.Find("Mesas").GetComponent<SpriteRenderer>().sprite = Mesas[numeroLista];
                break;
        }
    }
}
