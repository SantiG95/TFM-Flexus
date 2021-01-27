using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DatosGuardado : MonoBehaviour
{
    public int ultimaNoche;
    
    public DatosGuardado (DatosPartida datos)
    {
        ultimaNoche = datos.ultimaNoche;
    }
}
