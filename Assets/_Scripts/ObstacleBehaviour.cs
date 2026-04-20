using System;
using UnityEngine;

public class ObstacleBehaviour : MonoBehaviour
{
    public float speed;
    public Transform startPosition;

    private void Update()
    {
        transform.position += Vector3.up * (Time.deltaTime * speed);

        if (transform.position.y >= 6)
        {
            transform.position = startPosition.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<DamageHandler>(out DamageHandler dps))
        {
            // Pasamos los datos al crear la clase, y ya no se pueden alterar en el camino
            DamageInfo info = new DamageInfo(10f, "Fisico");
            dps.ProcesarDanio(info);
        }
    }
}

