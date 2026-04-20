
using UnityEngine;
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float vidaMaxima = 100f;
    private float vidaActual;

    // Para que otros scripts puedan LEER la vida pero no MODIFICARLA, 
    // usamos una Propiedad de solo lectura:
    public float VidaActual => vidaActual; 

    void Start()
    {
        vidaActual = vidaMaxima;
    }

    // La única "puerta" de entrada para cambiar la vida es este método
    public void RecibirDanio(float cantidad)
    {
        if (cantidad < 0) return; // Seguridad: no permitimos daño negativo
        
        vidaActual -= cantidad;
        vidaActual = Mathf.Clamp(vidaActual, 0, vidaMaxima);
        
        if (vidaActual <= 0) Morir();
    }
}