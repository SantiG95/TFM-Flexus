using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidosMenu : MonoBehaviour
{
    private AudioSource sonidoMenu;
    public AudioClip sonidoClic;

    // Start is called before the first frame update
    void Start()
    {
        sonidoMenu = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void reproducirSonido()
    {
        sonidoMenu.PlayOneShot(sonidoClic, 1);
    }
}
