 [System.Serializable]

public class Guardar 
{
    public int cantidadCalaveras;

    public Guardar(Inventario inventario)
    {
        cantidadCalaveras = inventario.Calaveras;
    }
}
