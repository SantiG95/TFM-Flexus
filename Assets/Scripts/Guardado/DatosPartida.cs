using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatosPartida : MonoBehaviour
{
    public int ultimaNoche;

    public void guardar()
    {
        ultimaNoche++;
        SistemaGuardado.guardarPartida(this);
    }

    public void cargar()
    {
        DatosPartida datos = SistemaGuardado.cargarDatos() as DatosPartida;
        ultimaNoche = datos.ultimaNoche;
    }
}
