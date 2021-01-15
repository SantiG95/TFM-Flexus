using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BotonSalir : MonoBehaviour, IPointerDownHandler
{
    private SonidosMenu sonidosMenu;

    // Start is called before the first frame update
    void Start()
    {
        sonidosMenu = GameObject.Find("Main Camera").GetComponent<SonidosMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        sonidosMenu.reproducirSonido();
        Application.Quit();
    }
    
}
