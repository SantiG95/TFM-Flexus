using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BotonIniciar : MonoBehaviour, IPointerDownHandler
{
    public GameObject UI;
    public GameObject carta;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("clicky");
        UI.SetActive(false);
        carta.SetActive(true);
    }

}
