using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerTitulo : MonoBehaviour
{
    public int mejorNocheSuperada;
    public Text mejorNocheTexto;

    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("Version") || PlayerPrefs.GetString("Version") != Application.version)
        {
            PlayerPrefs.DeleteAll();
        }


        if (!PlayerPrefs.HasKey("mejorNoche"))
        {
            PlayerPrefs.SetInt("mejorNoche", 1);
        }
        mejorNocheSuperada = PlayerPrefs.GetInt("mejorNoche");
        if(mejorNocheSuperada != 1)
        {
            mejorNocheTexto.text = "Noche " + mejorNocheSuperada;
        }
    }
}
