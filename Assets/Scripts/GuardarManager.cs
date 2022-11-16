using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class GuardarManager 
{
   public static void GuardarInventario(Inventario inventario)
    {
        Guardar guardar = new Guardar(inventario);
        string dataPath = Application.persistentDataPath + "/jugador.save";
        FileStream fileStream = new FileStream(dataPath, FileMode.Create);
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        binaryFormatter.Serialize(fileStream, guardar);
        fileStream.Close();
    }
}
