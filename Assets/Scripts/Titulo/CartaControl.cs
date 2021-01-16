using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CartaControl : MonoBehaviour
{
    private SpriteRenderer cartaSprite;
    // Start is called before the first frame update
    void Start()
    {
        cartaSprite = GameObject.Find("Carta").GetComponent<SpriteRenderer>();
        StartCoroutine(mostrarCarta());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator mostrarCarta()
    {
        for (float i = 0; i <= 1; i += Time.deltaTime)
        {
            cartaSprite.color = new Color(1, 1, 1, i);
            yield return null;
        }
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Juego");
    }
}
