using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BotonIniciar : MonoBehaviour, IPointerDownHandler
{
    public GameObject UI;
    public GameObject carta;
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
        UI.SetActive(false);
        carta.SetActive(true);
        sonidosMenu.reproducirSonido();
    }

}
