using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementosSprite : MonoBehaviour
{
    public List<Sprite> Puerta;
    public List<Sprite> Chapa;

    public void cambiarSprite(string nombreHabitacion, int numeroLista)
    {
        switch (nombreHabitacion)
        {
            case "Puerta":
                GameObject.Find("Puerta").GetComponent<SpriteRenderer>().sprite = Puerta[numeroLista];
                break;

            case "Chapa":
                GameObject.Find("Chapa").GetComponent<SpriteRenderer>().sprite = Chapa[numeroLista];
                break;
        }
    }
}
