using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SistemaGuardado
{
    public static void guardarPartida (DatosPartida datosPartida)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/partida.data";
        FileStream stream = new FileStream(path, FileMode.Create);

        DatosGuardado datosGuardado = new DatosGuardado(datosPartida);

        formatter.Serialize(stream, datosGuardado);
        stream.Close();
    }

    public static object cargarDatos()
    {
        string path = Application.persistentDataPath + "/partida.data";
        if (!File.Exists(path))
        {
            Debug.Log("No hay partida");
            return null;
        }
        
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = File.Open(path, FileMode.Open);
        object datosPartida = formatter.Deserialize(stream);
        stream.Close();

        return datosPartida;
        
        
    }
}
