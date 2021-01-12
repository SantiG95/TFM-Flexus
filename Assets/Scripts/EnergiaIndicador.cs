using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergiaIndicador : MonoBehaviour
{
    public Text energiaTexto;
    public Image energiaImagen;
    public List<Sprite> indicadoresEnergia;
    public Text horaTexto;

    public float energia;
    public float tiempoConsumo;
    public int tiempoJuego;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        energia = GameObject.Find("Manager").GetComponent<GameManager>().cansancio;
        tiempoConsumo = GameObject.Find("Manager").GetComponent<GameManager>().tiempoDescuento;
        tiempoJuego = GameObject.Find("Manager").GetComponent<GameManager>().tiempo;

        if(energia == 0)
        {
            horaTexto.gameObject.SetActive(false);
            energiaTexto.gameObject.SetActive(false);
            energiaImagen.gameObject.SetActive(false);
        }
        actualizarPantalla();
    }

    void actualizarPantalla()
    {
        horaTexto.text = tiempoJuego/90 + " AM";
        energiaTexto.text = "Energía: " + energia;
        switch (tiempoConsumo)
        {
            case 0:
                energiaImagen.sprite = indicadoresEnergia[0];
                break;

            case 9.6f:
                energiaImagen.sprite = indicadoresEnergia[1];
                break;

            case 4.8f:
                energiaImagen.sprite = indicadoresEnergia[2];
                break;

            case 2.4f:
                energiaImagen.sprite = indicadoresEnergia[3];
                break;

            case 1.2f:
                energiaImagen.sprite = indicadoresEnergia[4];
                break;

            
        }
    }
}
