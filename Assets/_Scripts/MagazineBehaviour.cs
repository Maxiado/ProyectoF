using UnityEngine;

public class MagazineBehaviour : ObstacleBehaviour
{
    // Usar un CompareTag o una variable constante para el Layer es más eficiente
    [SerializeField] private int playerLayer = 3; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 1. Optimización de Layer: Usar == con el entero del layer es más rápido que .Equals()
        if (other.gameObject.layer != playerLayer) return;

        // 2. Optimización de Componente: TryGetComponent es más eficiente y seguro 
        // ya que evita la asignación de memoria si el componente no existe.
        if (other.TryGetComponent<PlayerMovement>(out PlayerMovement jugador))
        {
            jugador.RecargarCompleto();

            // 3. Feedback (Opcional): A veces es bueno desactivar el collider 
            // inmediatamente para evitar que se dispare dos veces en el mismo frame.
            // GetComponent<Collider2D>().enabled = false;

            Destroy(gameObject);
        }
    }
}