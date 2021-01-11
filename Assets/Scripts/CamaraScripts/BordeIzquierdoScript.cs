using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BordeIzquierdoScript : MonoBehaviour
{
    public float posicionX;
    void Start()
    {
        transform.position = new Vector3(Camera.main.orthographicSize * Screen.width / Screen.height * -1, 0, 0);
        
    }

    private void Update()
    {
        posicionX = transform.position.x;
    }

}
