using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BordeDerechoScript : MonoBehaviour
{
    public float posicionX;
    void Start()
    {
        transform.position = new Vector3(Camera.main.orthographicSize * Screen.width / Screen.height, 0, 0);
        
    }

    private void Update()
    {
        posicionX = transform.position.x;
    }
}
