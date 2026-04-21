using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    // Esta clase vive en el mismo objeto que PlayerHealth
    private PlayerHealth salud;

    void Awake()
    {
        salud = GetComponent<PlayerHealth>();
    }

    public void ProcesarDanio(DamageInfo info)
    {
        // Aquí podrías poner lógica extra, por ejemplo:
        // Si es daño de fuego, multiplicalo por 2
        if (info.tipoDeDanio == "Fuego") 
        {
            info.cantidad *= 2;
        }

        // Finalmente, le entregamos el daño final a la salud
        salud.RecibirDanio(info.cantidad);
    }
}