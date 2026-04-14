using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Configuración de Vida")]
    public float vidaMaxima = 5f;
    private float vidaActual;

    [Header("Estado")]
    public bool esInvulnerable = false;

    void Start()
    {
        // Al empezar, el jugador tiene la vida al máximo
        vidaActual = vidaMaxima;
    }

    // Esta función la llamarás desde los obstáculos o enemigos
    public void RecibirDaño(float cantidad)
    {
        if (esInvulnerable) return;

        vidaActual -= cantidad;

        // Limitamos la vida para que no sea menor a 0
        vidaActual = Mathf.Clamp(vidaActual, 0, vidaMaxima);

        if (vidaActual <= 0)
        {
            Morir();
        }
    }

    private void Morir()
    {
        // Aquí puedes desactivar el movimiento, mostrar un menú de Game Over
        // o recargar la escena.
        gameObject.SetActive(false); 
    }
}